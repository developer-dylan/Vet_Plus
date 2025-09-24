using Vet_Plus.Models;
using Vet_Plus.Utils;

namespace Vet_Plus.Services
{
    public static class PatientService
    {
        public static void RegisterPatient(List<Patient> patients)
        {
            try
            {
                Console.WriteLine("\n--- Registro de Paciente ---");

                string name = InputValidator.ReadRequiredString("Nombre: ");
                int age = InputValidator.ReadInt("Edad: ");
                string species = InputValidator.ReadRequiredString("Especie (Perro, Gato, etc.): ");
                string symptom = InputValidator.ReadRequiredString("Síntoma: ");

                Console.WriteLine("\n--- Datos del Dueño ---");
                string ownerName = InputValidator.ReadRequiredString("Nombres: ");
                string ownerLastName = InputValidator.ReadRequiredString("Apellidos: ");
                int identification = InputValidator.ReadInt("Identificación: ");
                string address = InputValidator.ReadRequiredString("Dirección: ");
                string phone = InputValidator.ReadRequiredString("Teléfono: ");
                string email = InputValidator.ReadRequiredString("Email: ");

                Owner owner = new Owner
                {
                    Name = ownerName,
                    LastName = ownerLastName,
                    Identification = identification,
                    Address = address,
                    Phone = phone,
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
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
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
                Console.WriteLine($"Dueño: {p.Owner.Name} {p.Owner.LastName}, Identificación: {p.Owner.Identification}, Dirección: {p.Owner.Address}, Teléfono: {p.Owner.Phone}, Email: {p.Owner.Email}");
            }
        }

        public static void SearchPatientByName(List<Patient> patients, string name)
        {
            Console.WriteLine("\n--- Búsqueda de Paciente ---");

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Debe ingresar un nombre válido.");
                return;
            }

            var patient = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                Console.WriteLine($"Mascota: {patient.Name}, Edad: {patient.Age}, Especie: {patient.Species}, Síntoma: {patient.Symptom}");
                Console.WriteLine($"Dueño: {patient.Owner.Name} {patient.Owner.LastName}, Identificación: {patient.Owner.Identification}, Dirección: {patient.Owner.Address}, Teléfono: {patient.Owner.Phone}, Email: {patient.Owner.Email}");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }

    }
}
