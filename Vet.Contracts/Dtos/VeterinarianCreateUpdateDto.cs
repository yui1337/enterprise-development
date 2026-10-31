namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO ветеринара для POST/PUT запросов
/// </summary>
/// <param name="PassportNumber">Номер паспорта</param>
/// <param name="FullName">ФИО</param>
/// <param name="SpecializationId">Идентификатор специализации</param>
/// <param name="BirthYear">Год рождения</param>
/// <param name="WorkExperience">Опыт работы (в годах)</param>
public sealed record VeterinarianCreateUpdateDto(string PassportNumber, string FullName, int SpecializationId, int BirthYear, int WorkExperience);