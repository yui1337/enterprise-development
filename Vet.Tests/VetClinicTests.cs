using Vet.Domain.DataSeed;
using Vet.Domain.Enums;

namespace Vet.Tests;

/// <summary>
/// Тесты запросов к данным ветеринарной клиники
/// </summary>
/// <param name="fixture">Тестовый набор данных</param>
public class VetClinicTest(VetClinicTestFixture fixture) : IClassFixture<VetClinicTestFixture>
{
    private readonly DateTime _referenceDate = VetClinicTestFixture.ReferenceDate;
    private readonly List<Domain.Entities.Veterinarian> _veterinarians = fixture.Veterinarians;
    private readonly List<Domain.Entities.Owner> _owners = fixture.Owners;
    private readonly List<Domain.Entities.Appointment> _appointments = fixture.Appointments;

    /// <summary>
    /// Проверяет получение ветеринаров, специализирующихся на выбранном виде животного
    /// </summary>
    [Fact]
    public void GetVeterinariansBySpecies_ReturnsVetsSpecializedOnCat()
    {
        var targetSpecies = Species.Cat;
        var expectedIds = new HashSet<int> { 0, 3, 4, 7, 8 };
        var excludedIds = new HashSet<int> { 1, 2, 5, 6, 9 };

        var resultVets = _veterinarians
            .Where(v => v.Specialization.Species.Contains(targetSpecies))
            .OrderBy(v => v.FullName)
            .ToList();

        Assert.Equal(expectedIds.Count, resultVets.Count);
        Assert.All(expectedIds, id => Assert.Contains(resultVets, v => v.Id == id));
        Assert.All(excludedIds, id => Assert.DoesNotContain(resultVets, v => v.Id == id));
    }

    /// <summary>
    /// Проверяет получение питомцев, записанных на приём к указанному врачу, упорядоченных по кличке
    /// </summary>
    [Fact]
    public void GetPetsByVeterinarian_OrderedByName_DistinctByPet()
    {
        var targetVetId = 0;

        var firstExpectedName = "Барсик";
        var secondExpectedName = "Рекс";

        var resultPets = _appointments
            .Where(a => a.Veterinarian.Id == targetVetId)
            .Select(a => a.Pet)
            .Distinct()
            .OrderBy(p => p.Name)
            .ToList();

        Assert.Equal(2, resultPets.Count);
        Assert.Equal(firstExpectedName, resultPets[0].Name);
        Assert.Equal(secondExpectedName, resultPets[1].Name);
    }

    /// <summary>
    /// Проверяет получение количества повторных приёмов у выбранной породы
    /// </summary>
    [Fact]
    public void GetRepeatAppointmentsCountByBreed_ReturnsExpected()
    {
        var labradorBreedId = 0;
        var corellaBreedId = 5;

        var expectedLabradorCount = 3;
        var expectedCorellaRepeatCount = 0;

        var labradorRepeatCount = _appointments
            .Count(a => a.IsRepeat && a.Pet.Breed.Id == labradorBreedId);

        var corellaRepeatCount = _appointments
            .Count(a => a.IsRepeat && a.Pet.Breed.Id == corellaBreedId);

        Assert.Equal(expectedLabradorCount, labradorRepeatCount);
        Assert.Equal(expectedCorellaRepeatCount, corellaRepeatCount);
    }

    /// <summary>
    /// Проверяет получение владельцев с более чем одним питомцем, упорядоченных по ФИО
    /// </summary>
    [Fact]
    public void GetOwnersWithMultiplePets_OrderedByFullName()
    {
        var expectedNames = new[]
        {
            "Иванов Иван Иванович",
            "Кузнецова Ольга Андреевна",
            "Сидоров Алексей Владимирович"
        };

        var resultOwners = _owners
            .Where(o => o.Pets.Count > 1)
            .OrderBy(o => o.FullName)
            .ToList();

        Assert.Equal(expectedNames.Length, resultOwners.Count);
        for (var i = 0; i < expectedNames.Length; i++)
            Assert.Equal(expectedNames[i], resultOwners[i].FullName);
    }

    /// <summary>
    /// Проверяет получение приёмов за текущий месяц в выбранном кабинете
    /// </summary>
    [Fact]
    public void GetAppointmentsByRoomThisMonth_Room101_ReturnsEight()
    {
        var targetRoom = 101;
        var expectedCount = 8;
        var expectedFirstAppointmentId = 0;
        var now = _referenceDate;

        var resultAppointments = _appointments
            .Where(a => a.RoomNumber == targetRoom
                     && a.AppointmentDateTime.Year == now.Year
                     && a.AppointmentDateTime.Month == now.Month)
            .OrderBy(a => a.AppointmentDateTime)
            .ToList();

        Assert.Equal(expectedCount, resultAppointments.Count);
        Assert.Equal(expectedFirstAppointmentId, resultAppointments[0].Id);
        Assert.All(resultAppointments, a => Assert.Equal(targetRoom, a.RoomNumber));
    }
}