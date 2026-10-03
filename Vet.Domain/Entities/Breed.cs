using Vet.Domain.Enums;

namespace Vet.Domain.Entities;

public sealed class Breed
{
    public int Id { get; set; }

    public required Species Species { get; set; }

    public required string Name { get; set; }
}