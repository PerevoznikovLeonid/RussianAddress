using RussianAddress.Enums;

namespace RussianAddress.Models;

public class SettlementInfo: ValueObject<SettlementType>, IValueObject
{
    public override required SettlementType Type { get; init; }
    public override required string Name { get; init; }
}