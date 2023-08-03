using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CargoApp.Models
{
    public enum Status
    {
        InTransit,
        Delivered,
        Cancelled
    }
    public class Cargo
    {   

        public int Id { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Source Address")]
        public string SourceAddress { get; set; }
        [Display(Name = "Destination Address")]
        public string DestinationAddress { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public Status Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }
        public virtual Customer Customer { get; set; }
    }
}