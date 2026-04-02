using RussianAddress.Enums;

namespace RussianAddress.Models;

public class SettlementInfo
{
    public SettlementType? Type { get; set; }
    public string? Name { get; set; }
}