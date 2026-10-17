namespace Vet.Domain.Entities;

public sealed class Appointment
{
    public int Id { get; set; }

    public required Pet Pet { get; set; }

    public required Veterinarian Veterinarian { get; set; }

    public required DateTime AppointmentDateTime { get; set; }

    public required int RoomNumber { get; set; }

    public bool IsRepeat { get; set; }
}