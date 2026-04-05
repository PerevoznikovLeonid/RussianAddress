using RussianAddress.Enums;

namespace RussianAddress.Models;

public class LocalityInfo: ValueObject<InhabitedLocalityType>, IValueObject
{
    public override required InhabitedLocalityType Type { get; init; }
    public override required string Name { get; init; }
}