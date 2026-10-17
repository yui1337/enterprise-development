namespace Vet.Domain.Entities;

public sealed class Veterinarian
{
    public int Id { get; set; }

    public required string PassportNumber { get; set; }

    public required string FullName { get; set; }

    public required Specialization Specialization { get; set; }
    
    public required int BirthYear { get; set; }

    public required int WorkExperience { get; set; }

    public List<Appointment> Appointments { get; set; } = [];
}