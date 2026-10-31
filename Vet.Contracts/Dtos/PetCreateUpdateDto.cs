using Vet.Domain.Enums;

namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO создания и обновления питомца для POST/PUT запросов
/// </summary>
/// <param name="Name">Кличка</param>
/// <param name="Species">Вид животного</param>
/// <param name="BreedId">Порода животного</param>
/// <param name="BirthDate">Дата рождения</param>
/// <param name="BodyWeight">Масса тела</param>
/// <param name="OwnerId">Идентификатор владельца</param>
public sealed record PetCreateUpdateDto(string Name, Species Species, int BreedId, DateOnly? BirthDate, double? BodyWeight, int OwnerId);