using Vet_Plus.Models;

class Program
{
    static void Main()
    {
        Owner owner = new Owner
        {
            Id = 1,
            FullName = "Juan Pérez",
            Phone = "555-1234",
            Address = "Calle Falsa 123"
        };

        Patient patient = new Patient
        {
            Id = 1,
            Name = "Firulais",
            Age = 4,
            Species = "Perro",
            Symptom = "No quiere comer",
            Owner = owner
        };

        Console.WriteLine($"Mascota: {patient.Name}, Edad: {patient.Age}, Especie: {patient.Species}, Síntoma: {patient.Symptom}");
        Console.WriteLine($"Dueño: {patient.Owner.FullName}, Teléfono: {patient.Owner.Phone}, Dirección: {patient.Owner.Address}");
    }
}
