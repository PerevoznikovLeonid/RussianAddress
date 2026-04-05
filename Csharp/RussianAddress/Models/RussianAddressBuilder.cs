using System;
using RussianAddress.Enums;

namespace RussianAddress.Models;

public class RussianAddressBuilder
{
    private readonly RussianAddress _address;
    
    public RussianAddressBuilder(SubjectRfType subjectType, string subjectName)
    {
        var subjectInfo = new SubjectInfo { Type = subjectType, Name = subjectName };
        var address = new RussianAddress() { Subject =  subjectInfo };
        _address = address;
    }

    public void AddSubject(SubjectRfType type, string name)
    {
        _address.Subject = new SubjectInfo { Type = type, Name = name };
    }

    public void AddMunicipality(MunicipalityType type, string name)
    {
        _address.Municipality = new MunicipalityInfo { Type = type, Name = name };
    }

    public void AddSettlement(SettlementType type, string name)
    {
        _address.Settlement = new SettlementInfo { Type = type, Name = name };
    }

    public void AddLocality(InhabitedLocalityType type, string name)
    {
        _address.Locality = new LocalityInfo { Type = type, Name = name };
    }

    public void AddPlanningStructure(PlanningStructureType type, string name)
    {
        _address.PlanningStructure = new PlanningStructureInfo { Type = type, Name = name };
    }

    public void AddRoadNetwork(RoadNetworkType type, string name)
    {
        _address.RoadNetwork = new RoadNetworkInfo { Type = type, Name = name };
    }

    public void AddLandPlot(string number)
    {
        // При добавлении земельного участка сбрасываем все, что связано со зданием, помещением и машино-местом
        _address.AddressObjectType = AddressObjectType.LandPlot;
        _address.LandPlotNumber = number;

        _address.BuildingNumber = null;
        _address.BuildingBlock = null;
        _address.BuildingStructure = null;
        _address.BuildingEstate = null;
        _address.PremiseType = null;
        _address.PremiseNumber = null;
        _address.ParkingSpaceType = null;
        _address.ParkingSpaceNumber = null;
    }

    public void AddBuilding(string number, AddressObjectType type, string? block = null, string? structure = null, string? estate = null)
    {
        _address.AddressObjectType = type;
        _address.BuildingNumber = number;
        _address.BuildingBlock = block;
        _address.BuildingStructure = structure;
        _address.BuildingEstate = estate;

        _address.LandPlotNumber = null;
        _address.PremiseType = null;
        _address.PremiseNumber = null;
        _address.ParkingSpaceType = null;
        _address.ParkingSpaceNumber = null;
    }

    public void AddPremise(PremiseType type, string number)
    {
        if (_address.ParkingSpaceType != null)
            throw new InvalidOperationException("Нельзя добавить помещение, если уже добавлено машино-место.");
        _address.AddressObjectType ??= AddressObjectType.Building;

        _address.PremiseType = type;
        _address.PremiseNumber = number;
    }

    public void AddParkingSpace(ParkingSpaceType type, string number)
    {
        if (_address.PremiseType != null)
            throw new InvalidOperationException("Нельзя добавить машино-место, если уже добавлено помещение.");
        _address.AddressObjectType ??= AddressObjectType.Building;

        _address.ParkingSpaceType = type;
        _address.ParkingSpaceNumber = number;
    }

    public void AddPostalCode(string postalCode)
    {
        _address.PostalCode = postalCode;
    }

    public RussianAddress Build()
    {
        // Дополнительные проверки корректности (опционально)
        if (_address.AddressObjectType == AddressObjectType.LandPlot && string.IsNullOrWhiteSpace(_address.LandPlotNumber))
            throw new InvalidOperationException("Для земельного участка должен быть указан номер.");
        if (_address.AddressObjectType != AddressObjectType.LandPlot && _address.LandPlotNumber != null)
            throw new InvalidOperationException("Номер земельного участка может быть указан только для типа LandPlot.");

        if ((_address.AddressObjectType is AddressObjectType.Building or AddressObjectType.Structure ||
             _address.AddressObjectType == AddressObjectType.Construction) &&
            string.IsNullOrWhiteSpace(_address.BuildingNumber))
            throw new InvalidOperationException("Для здания/строения/сооружения должен быть указан номер.");

        if (_address.PremiseType != null && _address.ParkingSpaceType != null)
            throw new InvalidOperationException("Нельзя одновременно указать помещение и машино-место.");
        
        return _address;
    }
}