package com.example.pupilx.managers

import com.example.pupilx.data.PatientDataRepository
import com.example.pupilx.models.GraphValueCalculation
import com.example.pupilx.models.VelocityCalculationData

class FixedIntensityProtocolManager : BaseProtocolManager() {
    private val diameterSmoothBinoLeftManager = DiameterSmoothingManager()
    private val diameterSmoothBinoRightManager = DiameterSmoothingManager()
    private val patientDataRepository = PatientDataRepository() // New instance for data loading
    private val resultManager = ResultManager() // New instance for result storage

    private var low: String = ""
    private var medium: String = ""
    private var high: String = ""

    // Main Lists
    private val osTimeStampValuesSmooth = mutableListOf<Float>()
    private val odTimeStampValuesSmooth = mutableListOf<Float>()
    private val osDiametersSmooth = mutableListOf<Float>()
    private val odDiametersSmooth = mutableListOf<Float>()

    

    fun fixedIntensityTestBinocular() {
        clearAllList()

        val patientTestData = patientDataRepository.getDummyPatientTestData()
        val patientDataManager = patientTestData.patientDataManagerList[0]

        low = patientDataManager.testTitle

        // Local Data Check
        for (i in patientTestData.patientDataManagerList.indices) {
            if (patientTestData.patientDataManagerList[i].testTitle == low) {
                for (k in patientTestData.patientDataManagerList[i].eyeInfoList.indices) {
                    if (patientTestData.patientDataManagerList[i].eyeInfoList[k].eye == "OS") {
                        osDiameters.addAll(patientTestData.patientDataManagerList[i].eyeInfoList[k].diameters)
                    }
                    if (patientTestData.patientDataManagerList[i].eyeInfoList[k].eye == "OD") {
                        odDiameters.addAll(patientTestData.patientDataManagerList[i].eyeInfoList[k].diameters)
                    }
                }
                timeStampValues.addAll(patientTestData.patientDataManagerList[i].timeStamps)
            }
        }

        // OS Table Creating
        v3OsAlgorithm()
        osDiametersSmooth.addAll(diameterSmoothBinoLeftManager.array01)
        osTimeStampValuesSmooth.addAll(diameterSmoothBinoLeftManager.array01TimestampsFirst)

        for (j in osTimeStampValuesSmooth.indices) {
            when {
                osTimeStampValuesSmooth[j] >= 0 && osTimeStampValuesSmooth[j] <= 5000 -> {
                    leftBaseValue.add(osDiametersSmooth[j])
                    baseValueTimestamp.add(osTimeStampValuesSmooth[j])
                }
                osTimeStampValuesSmooth[j] > 5000 && osTimeStampValuesSmooth[j] <= 6000 -> {
                    leftConstrictedValue.add(osDiametersSmooth[j])
                    leftConstrictedTimestamp.add(osTimeStampValuesSmooth[j])
                }
                osTimeStampValuesSmooth[j] > 6000 && osTimeStampValuesSmooth[j] <= 12000 -> {
                    leftDilationValue.add(osDiametersSmooth[j])
                    leftDilationTimestamp.add(osTimeStampValuesSmooth[j])
                }
            }
        }

        // OD Table Creating
        v3OdAlgorithm()
        odDiametersSmooth.addAll(diameterSmoothBinoRightManager.array01)
        odTimeStampValuesSmooth.addAll(diameterSmoothBinoRightManager.array01TimestampsFirst)

        for (j in odTimeStampValuesSmooth.indices) {
            when {
                odTimeStampValuesSmooth[j] >= 0 && odTimeStampValuesSmooth[j] <= 5000 -> {
                    rightBaseValue.add(odDiametersSmooth[j])
                    rightBaseValueTimestamp.add(odTimeStampValuesSmooth[j])
                }
                odTimeStampValuesSmooth[j] > 12000 && odTimeStampValuesSmooth[j] <= 13000 -> {
                    rightConstrictedValue.add(odDiametersSmooth[j])
                    rightConstrictedTimeStamp.add(odTimeStampValuesSmooth[j])
                }
                odTimeStampValuesSmooth[j] > 13000 && odTimeStampValuesSmooth[j] <= 19000 -> {
                    rightDilationValue.add(odDiametersSmooth[j])
                    rightDilationTimestamp.add(odTimeStampValuesSmooth[j])
                }
            }
        }

        // Calculation Start Here
        // Algorithm V2 OS Values Add Values
        calculationManager.CalucationVelocityValue(
            leftBaseValue, leftConstrictedValue, leftDilationValue,
            baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp
        )
        val data1 = VelocityCalculationData(
            patientDataManager.testTitle,
            "LightFlashOnSequence LeftEyeResponse",
            "OS",
            calculationManager.baseValue,
            calculationManager.constrictedValue,
            calculationManager.dilationValue,
            calculationManager.constricted_Velocity_Value,
            calculationManager.dilation_velocity_Value,
            calculationManager.percentage_Change_Value,
            calculationManager.Amplitude_Constriction,
            calculationManager.Amplitude_Dilation
        )
        resultManager.patientResultData.velocityCalculations.add(data1)

        // Algorithm V2 OD Values Add Values
        calculationManager.CalucationVelocityValue(
            rightBaseValue, rightConstrictedValue, rightDilationValue,
            rightBaseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp
        )
        val data3 = VelocityCalculationData(
            patientDataManager.testTitle,
            "LightFlashOnSequence RightEyeResponse",
            "OD",
            calculationManager.baseValue,
            calculationManager.constrictedValue,
            calculationManager.dilationValue,
            calculationManager.constricted_Velocity_Value,
            calculationManager.dilation_velocity_Value,
            calculationManager.percentage_Change_Value,
            calculationManager.Amplitude_Constriction,
            calculationManager.Amplitude_Dilation
        )
        resultManager.patientResultData.velocityCalculations.add(data3)
    }

    private fun v3OdAlgorithm() {
        // Algorithm V3 OD Values Add Values
        diameterSmoothBinoRightManager.CalculateMovingAverage(odDiameters, timeStampValues, 1)
        val data2 = GraphValueCalculation(
            patientDataRepository.getDummyPatientTestData().patientDataManagerList[0].testTitle,
            "LightFlashOnSequence RightEyeResponse",
            "OD",
            diameterSmoothBinoRightManager.amplitudeof_constrictionVal,
            diameterSmoothBinoRightManager.amplitudeof_DilationVal,
            diameterSmoothBinoRightManager.LatencyValue,
            diameterSmoothBinoRightManager.baseLine_Val,
            diameterSmoothBinoRightManager.constriction_Amount,
            diameterSmoothBinoRightManager.velocity_of_Constriction,
            diameterSmoothBinoRightManager.velocity_of_Dilation,
            diameterSmoothBinoRightManager.arrayInstantaneousVelocity,
            diameterSmoothBinoRightManager.arrayInstantaneousVelocityTimestamps,
            diameterSmoothBinoRightManager.array01,
            diameterSmoothBinoRightManager.array01TimestampsFirst
        )
        resultManager.patientResultData.graphValueCalculation.add(data2)
    }

    private fun v3OsAlgorithm() {
        // Algorithm V3 OS Values Add Values
        diameterSmoothBinoLeftManager.CalculateMovingAverage(osDiameters, timeStampValues, 1)
        val data = GraphValueCalculation(
            patientDataRepository.getDummyPatientTestData().patientDataManagerList[0].testTitle,
            "LightFlashOnSequence LeftEyeResponse",
            "OS",
            diameterSmoothBinoLeftManager.amplitudeof_constrictionVal,
            diameterSmoothBinoLeftManager.amplitudeof_DilationVal,
            diameterSmoothBinoLeftManager.LatencyValue,
            diameterSmoothBinoLeftManager.baseLine_Val,
            diameterSmoothBinoLeftManager.constriction_Amount,
            diameterSmoothBinoLeftManager.velocity_of_Constriction,
            diameterSmoothBinoLeftManager.velocity_of_Dilation,
            diameterSmoothBinoLeftManager.arrayInstantaneousVelocity,
            diameterSmoothBinoLeftManager.arrayInstantaneousVelocityTimestamps,
            diameterSmoothBinoLeftManager.array01,
            diameterSmoothBinoLeftManager.array01TimestampsFirst
        )
        resultManager.patientResultData.graphValueCalculation.add(data)
    }
}