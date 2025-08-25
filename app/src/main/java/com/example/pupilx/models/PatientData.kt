package com.example.pupilx.models

data class PatientTestDataList(
    var patientDataManagerList: MutableList<PatientDataManager> = mutableListOf()
)

data class PatientDataManager(
    var testTitle: String = "",
    var mainTitle: String = "",
    var timeStamps: MutableList<Float> = mutableListOf(),
    var eyeInfoList: MutableList<EyeInfo> = mutableListOf()
)

data class EyeInfo(
    var eye: String = "",
    var diameters: MutableList<Float> = mutableListOf(),
    var timeStamps: MutableList<Float> = mutableListOf()
)

data class VelocityCalculationData(
    var testTitle: String = "",
    var response: String = "",
    var eye: String = "",
    var baseValue: String = "",
    var constrictedValue: String = "",
    var dilationValue: String = "",
    var constrictionVelocity: String = "",
    var dilationVelocity: String = "",
    var percentageChangeValue: String = "",
    var amplitudeConstriction: String = "",
    var amplitudeDilatation: String = ""
)

data class GraphValueCalculation(
    var testTitle: String = "",
    var response: String = "",
    var eye: String = "",
    var amplitudeofConstrictionVal: String = "",
    var amplitudeofDilationVal: String = "",
    var latencyValue: String = "",
    var baseLineVal: String = "",
    var constrictionAmount: String = "",
    var velocityOfConstriction: String = "",
    var velocityOfDilation: String = "",
    var instantaneousVelocity: MutableList<String> = mutableListOf(),
    var instantaneousVelocityTimestamps: MutableList<String> = mutableListOf(),
    var array01Diameters: MutableList<Float> = mutableListOf(),
    var array01TimestampsFirst: MutableList<Float> = mutableListOf()
)

data class GraphValueCalculationNew(
    var testTitle: String = "",
    var response: String = "",
    var eye: String = "",
    var amplitudeofConstrictionVal: String = "",
    var amplitudeofDilationVal: String = "",
    var latencyValue: String = "",
    var baseLineVal: String = "",
    var constrictionAmount: String = "",
    var velocityOfConstriction: String = "",
    var velocityOfDilation: String = "",
    var instantaneousVelocity: MutableList<String> = mutableListOf(),
    var instantaneousVelocityTimestamps: MutableList<String> = mutableListOf(),
    var smoothDiameters: MutableList<Float> = mutableListOf(),
    var smoothTimeStamps: MutableList<Float> = mutableListOf()
)

data class PatientResultData(
    var velocityCalculations: MutableList<VelocityCalculationData> = mutableListOf(),
    var graphValueCalculation: MutableList<GraphValueCalculation> = mutableListOf(),
    var graphValueCalculationNew: MutableList<GraphValueCalculationNew> = mutableListOf()
)