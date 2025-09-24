using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vet_Plus.Models
{
    public class Owner
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public int Identification { get; set; }
        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
    }
}
