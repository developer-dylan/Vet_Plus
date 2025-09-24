using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vet_Plus.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Species { get; set; } = string.Empty;
        public string Symptom { get; set; } = string.Empty;

        public Owner Owner { get; set; } = new Owner();
    }
}
