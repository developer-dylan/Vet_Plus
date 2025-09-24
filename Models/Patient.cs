namespace Vet_Plus.Models
{
    public class Patient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Species { get; set; } = string.Empty;
        public string Symptom { get; set; } = string.Empty;

        public Owner Owner { get; set; } = new Owner();
    }
}
