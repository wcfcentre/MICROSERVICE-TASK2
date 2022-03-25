using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookweb.Model
{
    public class book
    {
        public long Id { get; set; }
        //public string? Name { get; set; }
        //public long Age { get; set; }
        //public string? Address { get; set; }
        //public string? Department { get; set; }
        //public bool IsActive { get; set; }

        //public int BlogId { get; set; }
        //public Blog Blog { get; set; }
        //public List<Comment> Comments { get; set; }

        public DateTime BookingDate { get; set; }
        public string BookingTime { get; set; }
        public string PickUpPoint { get; set; }     // (Free text, for example: Ang Mo Kio Hub)
        public string Destination { get; set; }     // (Free text, for example: Sun Plaza)
        public double Current_Location_Latitude { get; set; }    // (for example: 1.3581)
        public double Current_Location_Longitude { get; set; }   // (for example: 103.8956)
    }
}
