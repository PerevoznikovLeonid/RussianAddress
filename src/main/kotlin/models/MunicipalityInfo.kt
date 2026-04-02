package org.example.models

import org.example.enums.MunicipalityType

data class MunicipalityInfo(
    val type: MunicipalityType? = null,
    val name: String? = null
)
