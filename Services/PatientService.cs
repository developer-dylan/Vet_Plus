using Vet_Plus.Models;

namespace Vet_Plus.Services
{
    public static class PatientService
    {
        public static void RegisterPatient(List<Patient> patients)
        {
            try
            {
                Console.WriteLine("\n--- Registro de Paciente ---");

                Console.Write("Nombre: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Edad: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Edad inválida. Registro cancelado.");
                    return;
                }

                Console.Write("Especie (Perro, Gato, etc.): ");
                string species = Console.ReadLine() ?? "";

                Console.Write("Síntoma: ");
                string symptom = Console.ReadLine() ?? "";

                Console.WriteLine("\n--- Datos del Dueño ---");

                Console.Write("Nombres: ");
                string ownerName = Console.ReadLine() ?? "";

                Console.Write("Apellidos: ");
                string ownerLastName = Console.ReadLine() ?? "";

                Console.Write("Identificación: ");
                string identification = Console.ReadLine() ?? "";

                Console.Write("Dirección: ");
                string address = Console.ReadLine() ?? "";

                Console.Write("Teléfono: ");
                string phone = Console.ReadLine() ?? "";

                Console.Write("Email: ");
                string email = Console.ReadLine() ?? "";

                Owner owner = new Owner
                {
                    Name = ownerName,
                    LastName = ownerLastName,
                    Identification = int.TryParse(identification, out int id) ? id : 0,
                    Phone = phone,
                    Address = address,
                    Email = email
                };

                Patient newPatient = new Patient
                {
                    Name = name,
                    Age = age,
                    Species = species,
                    Symptom = symptom,
                    Owner = owner
                };

                patients.Add(newPatient);

                Console.WriteLine($"\nPaciente registrado con éxito. ID asignado: {newPatient.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el registro: {ex.Message}");
            }
        }


        public static void ListPatients(List<Patient> patients)
        {
            Console.WriteLine("\n--- Lista de Pacientes ---");

            if (patients.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"Mascota: {p.Name}, Edad: {p.Age}, Especie: {p.Species}, Síntoma: {p.Symptom}");
                Console.WriteLine($"Dueño: {p.Owner.Name} {p.Owner.LastName}, Identificación: {p.Owner.Identification}, Dirección: {p.Owner.Address},  Teléfono: {p.Owner.Phone}, Email: {p.Owner.Email}");
            }
        }

        public static void SearchPatientByName(List<Patient> patients, string name)
        {
            Console.WriteLine("\n--- Búsqueda de Paciente ---");

            var patient = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                Console.WriteLine($"Mascota: {patient.Name}, Edad: {patient.Age}, Especie: {patient.Species}, Síntoma: {patient.Symptom}");
                Console.WriteLine($"Dueño: {patient.Owner.Name} {patient.Owner.LastName}, Identificación: {patient.Owner.Identification}, Dirección: {patient.Owner.Address},  Teléfono: {patient.Owner.Phone}, Email: {patient.Owner.Email}");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }
}
