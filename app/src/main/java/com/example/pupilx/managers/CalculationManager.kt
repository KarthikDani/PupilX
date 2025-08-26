package com.example.pupilx.managers

import kotlin.math.pow
import kotlin.math.round
import kotlin.math.sqrt

class CalculationManager {

    var baseValue: String = ""
    var constrictedValue: String = ""
    var dilationValue: String = ""
    var constricted_Velocity_Value: String = ""
    var dilation_velocity_Value: String = ""
    var percentage_Change_Value: String = ""
    var Amplitude_Constriction: String = ""
    var Amplitude_Dilation: String = ""

    fun ClearAllVariables() {
        baseValue = ""
        constrictedValue = ""
        dilationValue = ""
        constricted_Velocity_Value = ""
        dilation_velocity_Value = ""
        percentage_Change_Value = ""
        Amplitude_Constriction = ""
        Amplitude_Dilation = ""
    }

    fun CalucationVelocityValue(
        baseList: List<Float>,
        constrictedList: List<Float>,
        dilationList: List<Float>,
        timeStamp_BaseList: List<Float>,
        timeStamp_ConstrictedList: List<Float>,
        timeStamp_DilationList: List<Float>
    ) {

        ClearAllVariables()

        var BaseValue = 0f
        var Base_Standard_Value = 0.0
        if (baseList.isNotEmpty()) {
            BaseValue = FindAverageValue(baseList)
            Base_Standard_Value = FindStandardDeviation(baseList)
        }

        var ConstrictedValue = 0f
        var Constricted_Standard_Value = 0.0
        if (constrictedList.isNotEmpty()) {
            Constricted_Standard_Value = FindStandardDeviation(constrictedList)
        }

        var DilationValue = 0f
        var Dilation_Standard_Value = 0.0
        if (dilationList.isNotEmpty()) {
            Dilation_Standard_Value = FindStandardDeviation(dilationList)
        }

        val temp = " +/- "

        if (baseList.isNotEmpty() && constrictedList.isNotEmpty() && dilationList.isNotEmpty()) {
            // Constriction velocity Value Start here............
            val lastBaseValue_TimeStamp = timeStamp_BaseList.last()

            val smallestConstrictedValue = constrictedList.filter { it != 0f }.minOrNull() ?: 0f
            val smallestConstrictedValue_index = constrictedList.indexOf(smallestConstrictedValue)
            val smallestConstrictedValue_Timestamp = timeStamp_ConstrictedList[smallestConstrictedValue_index]

            val tempCon = round(smallestConstrictedValue * 1000.0f) * 0.001f
            ConstrictedValue = tempCon

            // Dilation velocity Value Start here............
            val largeDilationValue = dilationList.filter { it != 0f }.maxOrNull() ?: 0f
            val largeDilationValue_index = dilationList.indexOf(largeDilationValue)
            val largeDilationValue_Timestamp = timeStamp_DilationList[largeDilationValue_index]

            val tempDila = round(largeDilationValue * 1000.0f) * 0.001f
            DilationValue = tempDila

            // Amplitude Constriction Value
            val temp2 = (BaseValue - ConstrictedValue)
            val tempACon = round(temp2 * 1000.0f) * 0.001f
            Amplitude_Constriction = tempACon.toString()

            var temp3 = (lastBaseValue_TimeStamp - smallestConstrictedValue_Timestamp)
            temp3 /= 1000f

            var constrictedVelocity = temp2 / temp3
            val newTemp1 = round(constrictedVelocity * 1000.0f) * 0.001f
            constrictedVelocity = newTemp1

            // Amplitude Dilation Value
            val temp5 = (smallestConstrictedValue - largeDilationValue)
            val tempADila = round(temp5 * 1000.0f) * 0.001f
            Amplitude_Dilation = tempADila.toString()

            var temp4 = (smallestConstrictedValue_Timestamp - largeDilationValue_Timestamp)
            temp4 /= 1000f

            var dilationVelocity = temp5 / temp4
            dilationVelocity = round(dilationVelocity * 1000.0f) * 0.001f

            if (constrictedVelocity == 0f) {
                constrictedVelocity = 0f
            }
            if (dilationVelocity == 0f) {
                dilationVelocity = 0f
            }

            baseValue = BaseValue.toString() + temp + Base_Standard_Value.toString()
            constrictedValue = ConstrictedValue.toString() + temp + Constricted_Standard_Value.toString()
            dilationValue = DilationValue.toString() + temp + Dilation_Standard_Value.toString()
            constricted_Velocity_Value = constrictedVelocity.toString()
            dilation_velocity_Value = dilationVelocity.toString()
        }

        // new percentage Change Value............................
        val tempPercent = (BaseValue - ConstrictedValue) / BaseValue
        val newTemp = tempPercent * 100
        val tempPercen = round(newTemp * 1000.0f) * 0.001f
        percentage_Change_Value = tempPercen.toString()
    }

    fun FindAverageValue(diameters: List<Float>): Float {
        return if (diameters.isNotEmpty()) {
            val average = diameters.average().toFloat()
            round(average * 100.0f) * 0.01f
        } else {
            0.0f
        }
    }

    fun FindStandardDeviation(diameters: List<Float>): Double {
        return if (diameters.size > 1) {
            val avg = diameters.average()
            val sum = diameters.sumOf { (it - avg).pow(2) }
            round(sqrt(sum / (diameters.size - 1)) * 1000.0) / 1000.0
        } else {
            0.0
        }
    }
}
