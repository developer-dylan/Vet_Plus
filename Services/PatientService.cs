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

                Console.Write("Ingrese ID de la mascota: ");
                int id = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingrese Nombre de la mascota: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Ingrese Edad de la mascota: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Edad inválida. Registro cancelado.");
                    return;
                }

                Console.Write("Ingrese Especie (Perro, Gato, etc.): ");
                string species = Console.ReadLine() ?? "";

                Console.Write("Ingrese Síntoma: ");
                string symptom = Console.ReadLine() ?? "";

                Console.WriteLine("\n--- Datos del Dueño ---");

                Console.Write("Ingrese Nombre completo del dueño: ");
                string ownerName = Console.ReadLine() ?? "";

                Console.Write("Ingrese Teléfono del dueño: ");
                string phone = Console.ReadLine() ?? "";

                Console.Write("Ingrese Dirección del dueño: ");
                string address = Console.ReadLine() ?? "";

                Owner owner = new Owner
                {
                    Id = id, // usamos el mismo ID de la mascota para simplificar
                    FullName = ownerName,
                    Phone = phone,
                    Address = address
                };

                Patient newPatient = new Patient
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Species = species,
                    Symptom = symptom,
                    Owner = owner
                };

                patients.Add(newPatient);

                Console.WriteLine("\nPaciente registrado con éxito.");
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
                Console.WriteLine($"  Dueño: {p.Owner.FullName}, Teléfono: {p.Owner.Phone}, Dirección: {p.Owner.Address}");
            }
        }

        public static void SearchPatientByName(List<Patient> patients, string name)
        {
            Console.WriteLine("\n--- Búsqueda de Paciente ---");

            var patient = patients.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                Console.WriteLine($"Mascota: {patient.Name}, Edad: {patient.Age}, Especie: {patient.Species}, Síntoma: {patient.Symptom}");
                Console.WriteLine($"Dueño: {patient.Owner.FullName}, Teléfono: {patient.Owner.Phone}, Dirección: {patient.Owner.Address}");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
    }
}
