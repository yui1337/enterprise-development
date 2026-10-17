namespace Vet.Domain.Entities;

public sealed class Owner
{
    public int Id { get; set; }

    public required string FullName { get; set; }

    public string? Address { get; set; }
        
    public required string PhoneNumber { get; set; }

    public List<Pet> Pets { get; set; } = [];
}