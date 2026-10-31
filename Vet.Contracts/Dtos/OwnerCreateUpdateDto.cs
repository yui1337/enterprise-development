namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO владельца для POST/PUT запросов
/// </summary>
/// <param name="FullName">ФИО</param>
/// <param name="Address">Адрес</param>
/// <param name="PhoneNumber">Номер телефона</param>
public sealed record OwnerCreateUpdateDto(string FullName, string? Address, string PhoneNumber);
