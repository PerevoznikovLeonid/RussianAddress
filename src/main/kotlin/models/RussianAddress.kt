package org.example.models

import org.example.enums.AddressObjectType
import org.example.enums.ParkingSpaceType
import org.example.enums.PremiseType

class RussianAddress(
    val country: String = "Российская Федерация",
    var subject: SubjectInfo? = null,
    var municipality: MunicipalityInfo? = null,
    var settlement: SettlementInfo? = null,
    var locality: LocalityInfo? = null,
    var planningStructure: PlanningStructureInfo? = null,
    var roadNetwork: RoadNetworkInfo? = null,
    var addressObjectType: AddressObjectType? = null,
    // ---- Поля для земельного участка ----
    var landPlotNumber: String? = null,
    // ---- Поля для здания / строения / сооружения ----
    var buildingNumber: String? = null,
    var buildingBlock: String? = null,
    var buildingStructure: String? = null,
    var buildingEstate: String? = null,
    // ---- Помещение ----
    var premiseType: PremiseType? = null,
    var premiseNumber: String? = null,
    // ---- Машино-место ----
    var parkingSpaceType: ParkingSpaceType? = null,
    var parkingSpaceNumber: String? = null,
    // ---- Служебные поля ----
    var postalCode: String? = null
)