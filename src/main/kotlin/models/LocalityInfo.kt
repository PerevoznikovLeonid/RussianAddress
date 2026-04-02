package org.example.models

import org.example.enums.InhabitedLocalityType

data class LocalityInfo(
    val type: InhabitedLocalityType? = null,
    val name: String? = null
)
