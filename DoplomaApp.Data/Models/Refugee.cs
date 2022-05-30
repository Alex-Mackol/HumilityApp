using DiplomaApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Models
{
    public class Refugee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ushort FamilyAmount { get; set; }

        public TypeOfHelp Helps { get; set; }

        public bool HasAnimal { get; set; }
    }
}
