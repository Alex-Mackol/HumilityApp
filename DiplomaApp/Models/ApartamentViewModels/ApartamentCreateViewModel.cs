namespace DiplomaApp.Models.ApartamentViewModels;

public class ApartamentCreateViewModel
{
    public string TypeOfHouse { get; set; }

    public decimal Price { get; set; }

    public string Street { get; set; }

    public int VolunteerId { get; set; }

    public ushort RoomsAmount { get; set; }

    public ushort PeopleCount { get; set; }
}