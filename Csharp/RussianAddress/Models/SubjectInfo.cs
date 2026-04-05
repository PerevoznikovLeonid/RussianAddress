using RussianAddress.Enums;

namespace RussianAddress.Models;

public class SubjectInfo: ValueObject<SubjectRfType>, IValueObject
{
    public override required SubjectRfType Type { get; init; }
    public override required string Name { get; init; }
}