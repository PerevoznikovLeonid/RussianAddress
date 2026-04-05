using RussianAddress.Enums;

namespace RussianAddress.Models;

public class RoadNetworkInfo: ValueObject<RoadNetworkType>, IValueObject
{
    public override required RoadNetworkType Type { get; init; }
    public override required string Name { get; init; }
}