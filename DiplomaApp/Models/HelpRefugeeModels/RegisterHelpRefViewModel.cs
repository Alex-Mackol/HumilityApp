namespace DiplomaApp.Models.HelpRefugeeModels;

public class RegisterHelpRefViewModel
{
    public ushort FamilyAmount { get; set; }

    public ICollection<string> Helps { get; set; }

    public bool HasAnimal { get; set; }
}