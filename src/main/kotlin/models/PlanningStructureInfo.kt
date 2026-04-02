package org.example.models

import org.example.enums.PlanningStructureType

data class PlanningStructureInfo(
    val type: PlanningStructureType? = null,
    val name: String? = null
)