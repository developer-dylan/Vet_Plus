using Vet_Plus.Models;
using Vet_Plus.Utils;

namespace Vet_Plus.Services
{
    public static class PatientService
    {
        public static Patient? RegisterPatient(List<Patient> patients)
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

                return newPatient;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return null;
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

        public static void ShowPatient(Patient patient)
        {
            Console.WriteLine($"Mascota: {patient.Name}, Edad: {patient.Age}, Especie: {patient.Species}, Síntoma: {patient.Symptom}");
            Console.WriteLine($"Dueño: {patient.Owner.Name} {patient.Owner.LastName}, ID: {patient.Owner.Identification}, Dirección: {patient.Owner.Address}, Teléfono: {patient.Owner.Phone}, Email: {patient.Owner.Email}");
        }

        public static void RunLinqQueries(List<Patient> patients)
        {
            Console.WriteLine("\n--- Consultas LINQ ---");

            // 1. Pacientes mayores de 5 años
            var mayores = patients.Where(p => p.Age > 5).ToList();
            Console.WriteLine("\nPacientes mayores de 5 años:");
            foreach (var p in mayores)
            {
                Console.WriteLine($"- {p.Name} ({p.Age} años)");
            }

            // 2. Nombres de todos los pacientes
            var nombres = patients.Select(p => p.Name).ToList();
            Console.WriteLine("\nNombres de pacientes:");
            nombres.ForEach(n => Console.WriteLine($"- {n}"));

            // 3. Pacientes agrupados por especie
            var groups = patients.GroupBy(p => p.Species);
            Console.WriteLine("\nPacientes agrupados por especie:");
            foreach (var g in groups)
            {
                Console.WriteLine($"Especie: {g.Key} ({g.Count()} pacientes)");
                foreach (var p in g)
                {
                    Console.WriteLine($"  - {p.Name}");
                }
            }

            // 4. Perros ordenados por edad
            var dogssortedbyage = patients
                .Where(p => p.Species == "Perro")
                .OrderBy(p => p.Age)
                .ToList();

            Console.WriteLine("\nPerros ordenados por edad:");
            foreach (var p in dogssortedbyage)
            {
                Console.WriteLine($"- {p.Name} ({p.Age} años)");
            }

            // --- Task 3: Métodos fundamentales LINQ ---

            // 5. Primer paciente registrado
            var firstpatient = patients.FirstOrDefault();
            if (firstpatient != null)
            {
                Console.WriteLine($"\nPrimer paciente registrado: {firstpatient.Name} ({firstpatient.Age} años)");
            }
            else
            {
                Console.WriteLine("\nNo hay pacientes registrados.");
            }

            // 6. Verificar si hay algún gato
            bool hayGatos = patients.Any(p => p.Species == "Gato");
            Console.WriteLine($"\n¿Hay gatos registrados?: {(hayGatos ? "Sí" : "No")}");

            // 7. Verificar si todos los dueños tienen teléfono
            bool todosConTelefono = patients.All(p => !string.IsNullOrWhiteSpace(p.Owner.Phone));
            Console.WriteLine($"¿Todos los dueños tienen teléfono?: {(todosConTelefono ? "Sí" : "No")}");

            // 8. Contar pacientes
            int totalPacientes = patients.Count();
            Console.WriteLine($"\nTotal de pacientes registrados: {totalPacientes}");

            // 9. Edad mínima y máxima
            if (patients.Any())
            {
                int edadMinima = patients.Min(p => p.Age);
                int edadMaxima = patients.Max(p => p.Age);
                Console.WriteLine($"Edad mínima: {edadMinima}, Edad máxima: {edadMaxima}");
            }
        }

    }
}
