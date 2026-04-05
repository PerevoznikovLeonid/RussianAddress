using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using RussianAddress.Enums;

namespace RussianAddress.Models;

public class RussianAddress: IEnumerable<IValueObject>
{
    public string Country { get; } = "Российская Федерация";
    public required SubjectInfo Subject { get; set; }
    public MunicipalityInfo? Municipality { get; set; }
    public SettlementInfo? Settlement { get; set; }
    public LocalityInfo? Locality { get; set; }
    public PlanningStructureInfo? PlanningStructure { get; set; }
    public RoadNetworkInfo? RoadNetwork { get; set; }
    public AddressObjectType? AddressObjectType { get; set; }

    // Поля для земельного участка
    public string? LandPlotNumber { get; set; }

    // Поля для здания / строения / сооружения
    public string? BuildingNumber { get; set; }
    public string? BuildingBlock { get; set; }
    public string? BuildingStructure { get; set; }
    public string? BuildingEstate { get; set; }

    // Помещение
    public PremiseType? PremiseType { get; set; }
    public string? PremiseNumber { get; set; }

    // Машино-место
    public ParkingSpaceType? ParkingSpaceType { get; set; }
    public string? ParkingSpaceNumber { get; set; }

    // Служебные поля
    public string? PostalCode { get; set; }
    
    public IEnumerator<IValueObject> GetEnumerator()
    {
        var properties = this.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(this) is IValueObject value)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}