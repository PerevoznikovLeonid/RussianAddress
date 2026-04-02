package org.example.models

import org.example.enums.RoadNetworkType

data class RoadNetworkInfo(
    val type: RoadNetworkType? = null,
    val name: String? = null
)
