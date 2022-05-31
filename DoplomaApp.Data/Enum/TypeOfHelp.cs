using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Enum
{
    public enum TypeOfHelp
    {
        [Display(Name ="Допомога із іжею")]
        Food = 1,
        [Display(Name = "Допомога із пошуком житла")]
        Apartaments = 2,
        [Display(Name = "Допомога з одягом")]
        Clothes = 3,
        [Display(Name = "Допомога з лікування")]
        Medicines = 4,
        [Display(Name = "Допомога для дітей")]
        ChildrenGoods = 5,
        [Display(Name = "Допомога іх тваринами")]
        AnimalGoods = 6  
    }
}
