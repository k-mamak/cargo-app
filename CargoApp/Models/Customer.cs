using System.Collections.Generic;

namespace CargoApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}