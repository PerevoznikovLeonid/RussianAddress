using RussianAddress.Enums;

namespace RussianAddress.Models;

public class MunicipalityInfo: ValueObject<MunicipalityType>, IValueObject
{
    public override required MunicipalityType Type { get; init; }
    public override required string Name { get; init; }
}