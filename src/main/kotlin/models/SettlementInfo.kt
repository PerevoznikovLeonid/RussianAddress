package org.example.models

import org.example.enums.SettlementType

data class SettlementInfo(
    val type: SettlementType? = null,
    val name: String? = null
)
