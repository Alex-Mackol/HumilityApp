using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Services.Models
{
    public class RefugeesDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ushort FamilyAmount { get; set; }

        public ICollection<string> Helps { get; set; }

        public bool HasAnimal { get; set; }
    }
}
