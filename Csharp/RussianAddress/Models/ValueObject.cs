using System;
using System.Text.Json;

namespace RussianAddress.Models;

public interface IValueObject
{
    
}

public abstract class ValueObject<TValueType> where TValueType : struct, Enum
{
    public abstract required TValueType Type { get; init; }
    public abstract required string Name { get; init; }
}