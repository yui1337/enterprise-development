using Vet.Domain.Enums;

namespace Vet.Domain.Entities;

public sealed class Pet
{
    public required string Name { get; set; }

    public required Species Species { get; set; }

    public required Breed Breed { get; set; }

    public DateOnly BirthDate { get; set; }

    public double BodyWeight { get; set; }
}