using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces
{
    public interface IApartamentService
    {
        IEnumerable<ApartamentDto> GetAparatments();
        IEnumerable<ApartamentDto> GetAparatments(int volunteerId);
        void CreateApart(ApartamentDto apartamentDto);
        ApartamentDto Delete(int id);
    }
}
