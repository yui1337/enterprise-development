using Vet.Domain.Enums;

namespace Vet.Domain.Entities;

public sealed class Specialization
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public List<Species> Species { get; set; } = [];
}