using RussianAddress.Enums;

namespace RussianAddress.Models;

public class PlanningStructureInfo: ValueObject<PlanningStructureType>, IValueObject
{
    public override required PlanningStructureType Type { get; init; }
    public override required string Name { get; init; }
}