using RussianAddress.Enums;

namespace RussianAddress.Models;

public class RussianAddress
{
    public string Country { get; set; } = "Российская Федерация";
    public SubjectInfo? Subject { get; set; }
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
}