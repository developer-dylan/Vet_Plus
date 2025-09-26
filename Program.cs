using Vet_Plus.Models;
using Vet_Plus.Services;

class Program
{
    static void Main()
    {
        // Colecciones en memoria
        List<Patient> patients = new List<Patient>();
        Dictionary<Guid, Patient> patientDictionary = new Dictionary<Guid, Patient>();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Buscar paciente por nombre");
            Console.WriteLine("4. Buscar paciente por ID");
            Console.WriteLine("5. Salir");
            Console.Write("Opción: ");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    var newPatient = PatientService.RegisterPatient(patients);
                    if (newPatient != null)
                    {
                        patientDictionary[newPatient.Id] = newPatient;
                    }
                    break;
                case "2":
                    PatientService.ListPatients(patients);
                    break;
                case "3":
                    Console.Write("Ingrese nombre de la mascota a buscar: ");
                    string name = Console.ReadLine() ?? "";
                    PatientService.SearchPatientByName(patients, name);
                    break;
                case "4":
                    Console.Write("Ingrese ID del paciente: ");
                    string idInput = Console.ReadLine() ?? "";
                    if (Guid.TryParse(idInput, out Guid id))
                    {
                        if (patientDictionary.TryGetValue(id, out Patient? found))
                        {
                            PatientService.ShowPatient(found);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró paciente con ese ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Formato de ID inválido.");
                    }
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
