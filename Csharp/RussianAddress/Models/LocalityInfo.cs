using RussianAddress.Enums;

namespace RussianAddress.Models;

public class LocalityInfo
{
    public InhabitedLocalityType? Type { get; set; }
    public string? Name { get; set; }
}