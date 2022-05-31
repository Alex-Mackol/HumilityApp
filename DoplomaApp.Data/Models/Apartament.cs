using DiplomaApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Models
{
    public class Apartament
    {
        public int Id { get; set; }

        public TypeOfHouse TypeOfHouse { get; set; }

        public decimal Price { get; set; }

        public string Street { get; set; }

        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }

        public ushort RoomsAmount { get; set; }

        public ushort PeopleCount { get; set;  }
        public bool IsAvailable { get; set; }
    }
}
