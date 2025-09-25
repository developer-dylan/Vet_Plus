using Vet_Plus.Models;
using Vet_Plus.Services;

class Program
{
    static void Main()
    {
        List<Patient> patients = new List<Patient>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Menú Principal ---");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Buscar paciente");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    PatientService.RegisterPatient(patients);
                    break;
                case "2":
                    PatientService.ListPatients(patients);
                    break;
                case "3":
                    Console.Write("Ingrese nombre a buscar: ");
                    string name = Console.ReadLine() ?? "";
                    PatientService.SearchPatientByName(patients, name);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
