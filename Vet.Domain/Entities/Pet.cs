using Vet.Domain.Enums;

namespace Vet.Domain.Entities;

public sealed class Pet
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required Species Species { get; set; }

    public required Breed Breed { get; set; }

    public DateOnly? BirthDate { get; set; }

    public double? BodyWeight { get; set; }

    public required Owner Owner { get; set; }

    public List<Appointment> Appointments { get; set; } = [];
}