using Vet.Domain.Enums;

namespace Vet.Contracts.Dtos;

/// <summary>
/// DTO специализации для POST/PUT запросов
/// </summary>
/// <param name="Name">Название</param>
/// <param name="Species">Виды животных</param>
public sealed record SpecializationCreateUpdateDto(string Name, IReadOnlyList<Species> Species);