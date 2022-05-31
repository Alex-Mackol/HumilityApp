using System.ComponentModel.DataAnnotations;
using DiplomaApp.Data.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiplomaApp.Controllers
{
    [Authorize(Roles = "refugee")]
    public class HelpController : Controller
    {
        private readonly TypeOfHelp typeOfHelp;

        public HelpController()
        {
            typeOfHelp = new TypeOfHelp();
        }
        public IActionResult HelpIndex()
        {
            return View();
        }

        private void GetTypeSelectLists()
        {
            var typeList = GetTypeHelpDisplayNames();
            var typeSelectList = new SelectList(typeList);
            ViewData["TypeList"] = typeSelectList;
        }
        private List<string> GetTypeHelpDisplayNames()
        {
            var type = typeOfHelp.GetType();
            var displaynames = new List<string>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DisplayAttribute), true);

                if (fds.Length == 0)
                {
                    displaynames.Add(name);
                }

                foreach (DisplayAttribute fd in fds)
                {
                    displaynames.Add(fd.Name);
                }
            }
            return displaynames;
        }
    }
}
