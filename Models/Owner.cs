using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vet_Plus.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
