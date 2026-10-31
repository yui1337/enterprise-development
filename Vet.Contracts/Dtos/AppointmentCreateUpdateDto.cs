namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO создания и обновления записи на прием для POST/PUT запросов
/// </summary>
/// <param name="PetId">Идентификатор питомца</param>
/// <param name="VeterinarianId">Идентификатор ветеринара</param>
/// <param name="AppointmentDateTime">Дата и время приема</param>
/// <param name="RoomNumber">Номер кабинета</param>
/// <param name="IsRepeat">Флаг повторного приема</param>
public sealed record AppointmentCreateUpdateDto(int PetId, int VeterinarianId, DateTime AppointmentDateTime, int RoomNumber, bool IsRepeat);