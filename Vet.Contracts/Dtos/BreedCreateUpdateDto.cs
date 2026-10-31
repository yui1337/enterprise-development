using Vet.Domain.Enums;

namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO породы для POST/PUT запросов
/// </summary>
/// <param name="Species">Вид животного</param>
/// <param name="Name">Название</param>
public sealed record BreedCreateUpdateDto(Species Species, string Name);