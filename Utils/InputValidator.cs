namespace Vet_Plus.Utils
{
    public static class InputValidator
    {
        public static string ReadRequiredString(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("El valor no puede estar vacío.");
            }

            return input;
        }

        public static int ReadInt(string message)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                throw new ArgumentException("El valor debe ser un número entero.");
            }

            return value;
        }
    }
}
