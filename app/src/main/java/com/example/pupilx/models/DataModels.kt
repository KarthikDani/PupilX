package com.example.pupilx.models

data class PatientTestDataList(
    val patientDataManagerList: List<PatientDataManager>
)

data class PatientDataManager(
    val testTitle: String,
    val eyeInfoList: List<EyeInfo>,
    val timeStamps: List<Float>
)

data class EyeInfo(
    val eye: String, // "OS" or "OD"
    val diameters: List<Float>
)

data class VelocityCalculationData(
    val testTitle: String,
    val responseType: String,
    val eye: String,
    val baseValue: String,
    val constrictedValue: String,
    val dilationValue: String,
    val constrictedVelocity: String,
    val dilationVelocity: String,
    val percentageChangeValue: String,
    val amplitudeConstriction: String,
    val amplitudeDilation: String
)

data class GraphValueCalculation(
    val testTitle: String,
    val responseType: String,
    val eye: String,
    val amplitudeOfConstrictionVal: String,
    val amplitudeOfDilationVal: String,
    val latencyValue: String,
    val baseLineVal: String,
    val constrictionAmount: String,
    val velocityOfConstriction: String,
    val velocityOfDilation: String,
    val arrayInstantaneousVelocity: List<String>,
    val arrayInstantaneousVelocityTimestamps: List<String>,
    val array01Diameters: List<Float>,
    val array01TimeStamps: List<Float>
)

data class PatientResultData(
    val velocityCalculations: MutableList<VelocityCalculationData> = mutableListOf(),
    val graphValueCalculation: MutableList<GraphValueCalculation> = mutableListOf()
)