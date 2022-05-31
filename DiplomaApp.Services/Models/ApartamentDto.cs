using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Services.Models
{
    public class ApartamentDto
    {
        public int Id { get; set; }

        public string TypeOfHouse { get; set; }

        public decimal Price { get; set; }

        public string Street { get; set; }

        public string VolunteerPhone { get; set; }
        public string VolunterName { get; set; }

        public int VolunteerId { get; set; }

        public ushort RoomsAmount { get; set; }

        public ushort PeopleCount { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
