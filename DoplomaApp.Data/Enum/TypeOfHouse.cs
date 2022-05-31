using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Enum
{
    public enum TypeOfHouse
    {

        [Display(Name = "Дім")]
        House = 1,
        [Display(Name = "Квартира")]
        Flat = 2
    }
}
