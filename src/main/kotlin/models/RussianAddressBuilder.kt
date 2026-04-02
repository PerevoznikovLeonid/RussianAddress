package org.example.models

import org.example.enums.AddressObjectType
import org.example.enums.InhabitedLocalityType
import org.example.enums.MunicipalityType
import org.example.enums.ParkingSpaceType
import org.example.enums.PlanningStructureType
import org.example.enums.PremiseType
import org.example.enums.RoadNetworkType
import org.example.enums.SettlementType
import org.example.enums.SubjectRfType

class RussianAddressBuilder: IBuilder {
    private val address = RussianAddress()

    fun addSubject(type: SubjectRfType, name: String) {
        address.subject = SubjectInfo(type, name)
    }

    fun addMunicipality(type: MunicipalityType, name: String) {
        address.municipality = MunicipalityInfo(type, name)
    }

    fun addSettlement(type: SettlementType, name: String) {
        address.settlement = SettlementInfo(type, name)
    }

    fun addLocality(type: InhabitedLocalityType, name: String) {
        address.locality = LocalityInfo(type, name)
    }

    fun addPlanningStructure(type: PlanningStructureType, name: String) {
        address.planningStructure = PlanningStructureInfo(type, name)
    }

    fun addRoadNetwork(type: RoadNetworkType, name: String) {
        address.roadNetwork = RoadNetworkInfo(type, name)
    }

    fun addLandPlot(number: String) {
        address.addressObjectType = AddressObjectType.LandPlot
        address.landPlotNumber = number
        // Сброс несовместимых полей
        address.buildingNumber = null
        address.buildingBlock = null
        address.buildingStructure = null
        address.buildingEstate = null
        address.premiseType = null
        address.premiseNumber = null
        address.parkingSpaceType = null
        address.parkingSpaceNumber = null
    }

    fun addBuilding(number: String, block: String? = null, structure: String? = null, estate: String? = null) {
        address.addressObjectType = AddressObjectType.Building  // или Structure/Construction, но по умолчанию Building
        address.buildingNumber = number
        address.buildingBlock = block
        address.buildingStructure = structure
        address.buildingEstate = estate
        // Сброс несовместимых полей
        address.landPlotNumber = null
        address.premiseType = null
        address.premiseNumber = null
        address.parkingSpaceType = null
        address.parkingSpaceNumber = null
    }

    fun addPremise(type: PremiseType, number: String) {
        require(address.parkingSpaceType == null) { "Нельзя добавить помещение, если уже добавлено машино-место" }
        if (address.addressObjectType == null) {
            address.addressObjectType = AddressObjectType.Building
        }
        address.premiseType = type
        address.premiseNumber = number
    }

    fun addParkingSpace(type: ParkingSpaceType, number: String) {
        require(address.premiseType == null) { "Нельзя добавить машино-место, если уже добавлено помещение" }
        if (address.addressObjectType == null) {
            address.addressObjectType = AddressObjectType.Building
        }
        address.parkingSpaceType = type
        address.parkingSpaceNumber = number
    }

    fun addPostalCode(postalCode: String) {
        address.postalCode = postalCode
    }

    override fun build(): RussianAddress {
        // Валидация перед возвратом копии
        when (address.addressObjectType) {
            AddressObjectType.LandPlot -> {
                require(!address.landPlotNumber.isNullOrBlank()) { "Для земельного участка должен быть указан номер" }
                require(address.buildingNumber == null && address.premiseType == null && address.parkingSpaceType == null) {
                    "Для земельного участка не могут быть указаны buildingNumber, premiseType или parkingSpaceType"
                }
            }
            AddressObjectType.Building, AddressObjectType.Structure, AddressObjectType.Construction -> {
                require(!address.buildingNumber.isNullOrBlank()) { "Для здания/строения/сооружения должен быть указан номер" }
                require(address.landPlotNumber == null) { "Для здания/строения/сооружения не может быть указан landPlotNumber" }
            }
            null -> { /* нет дополнительных требований */ }
        }
        require(!(address.premiseType != null && address.parkingSpaceType != null)) {
            "Нельзя одновременно указать помещение и машино-место"
        }

        return address
    }
}