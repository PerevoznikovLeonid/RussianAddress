package org.example.models

import org.example.enums.SubjectRfType

data class SubjectInfo(
    val type: SubjectRfType? = null,
    val name: String? = null
)
