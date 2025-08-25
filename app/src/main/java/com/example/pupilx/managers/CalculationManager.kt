package com.example.pupilx.managers

import com.example.pupilx.models.VelocityCalculationData
import kotlin.math.*

class CalculationManager {
    var baseValue: String = ""
    var constrictedValue: String = ""
    var dilationValue: String = ""
    var constrictedVelocityValue: String = ""
    var dilationVelocityValue: String = ""
    var percentageChangeValue: String = ""
    var amplitudeConstriction: String = ""
    var amplitudeDilation: String = ""

    fun clearAllVariables() {
        baseValue = ""
        constrictedValue = ""
        dilationValue = ""
        constrictedVelocityValue = ""
        dilationVelocityValue = ""
        percentageChangeValue = ""
        amplitudeConstriction = ""
        amplitudeDilation = ""
    }

    fun calculateVelocityValue(
        baseList: List<Float>,
        constrictedList: List<Float>,
        dilationList: List<Float>,
        timeStampBaseList: List<Float>,
        timeStampConstrictedList: List<Float>,
        timeStampDilationList: List<Float>
    ) {
        // First clear all variables here
        clearAllVariables()

        var baseValueFloat = 0f
        var baseStandardValue = 0.0
        if (baseList.isNotEmpty()) {
            baseValueFloat = findAverageValue(baseList)
            baseStandardValue = findStandardDeviation(baseList)
        }

        var constrictedValueFloat = 0f
        var constrictedStandardValue = 0.0
        if (constrictedList.isNotEmpty()) {
            constrictedStandardValue = findStandardDeviation(constrictedList)
        }

        var dilationValueFloat = 0f
        var dilationStandardValue = 0.0
        if (dilationList.isNotEmpty()) {
            dilationStandardValue = findStandardDeviation(dilationList)
        }

        val temp = " +/- "

        if (baseList.isNotEmpty() && constrictedList.isNotEmpty() && dilationList.isNotEmpty()) {
            // Constriction velocity Value Start here............
            val lastBaseValueTimeStamp = timeStampBaseList[timeStampBaseList.size - 1]

            val smallestConstrictedValue = constrictedList.filter { it != 0f }.minOrNull() ?: 0f
            val smallestConstrictedValueIndex = constrictedList.indexOf(smallestConstrictedValue)
            val smallestConstrictedValueTimestamp = if (smallestConstrictedValueIndex >= 0 && smallestConstrictedValueIndex < timeStampConstrictedList.size) {
                timeStampConstrictedList[smallestConstrictedValueIndex]
            } else {
                0f
            }

            val tempCon = round(smallestConstrictedValue * 1000.0f) * 0.001f
            constrictedValueFloat = tempCon

            // Dilation velocity Value Start here............
            val largeDilationValue = dilationList.filter { it != 0f }.maxOrNull() ?: 0f
            val largeDilationValueIndex = dilationList.indexOf(largeDilationValue)
            val largeDilationValueTimestamp = if (largeDilationValueIndex >= 0 && largeDilationValueIndex < timeStampDilationList.size) {
                timeStampDilationList[largeDilationValueIndex]
            } else {
                0f
            }

            val tempDila = round(largeDilationValue * 1000.0f) * 0.001f
            dilationValueFloat = tempDila

            // Amplitude Constriction Value
            val temp2 = baseValueFloat - constrictedValueFloat

            val tempACon = round(temp2 * 1000.0f) * 0.001f
            amplitudeConstriction = tempACon.toString()

            val temp3 = lastBaseValueTimeStamp - smallestConstrictedValueTimestamp
            val temp3Sec = temp3 / 1000

            var constrictedVelocity = temp2 / temp3Sec

            val newTemp1 = round(constrictedVelocity * 1000.0f) * 0.001f
            constrictedVelocity = newTemp1

            // Amplitude Dilation Value
            val temp5 = smallestConstrictedValue - largeDilationValue

            val tempADila = round(temp5 * 1000.0f) * 0.001f
            amplitudeDilation = tempADila.toString()

            val temp4 = smallestConstrictedValueTimestamp - largeDilationValueTimestamp
            val temp4Sec = temp4 / 1000

            var dilationVelocity = temp5 / temp4Sec
            dilationVelocity = round(dilationVelocity * 1000.0f) * 0.001f

            if (constrictedVelocity != 0f) {
                // Do nothing
            } else {
                constrictedVelocity = 0f
            }

            if (dilationVelocity != 0f) {
                // Do nothing
            } else {
                dilationVelocity = 0f
            }

            baseValue = "$baseValueFloat$temp$baseStandardValue"
            constrictedValue = "$constrictedValueFloat$temp$constrictedStandardValue"
            dilationValue = "$dilationValueFloat$temp$dilationStandardValue"
            constrictedVelocityValue = constrictedVelocity.toString()
            dilationVelocityValue = dilationVelocity.toString()
        }

        // New percentage Change Value............................
        val tempPercent = (baseValueFloat - constrictedValueFloat) / baseValueFloat
        val newTemp = tempPercent * 100
        val tempPercentRounded = round(newTemp * 1000.0f) * 0.001f
        percentageChangeValue = tempPercentRounded.toString()
    }

    fun findAverageValue(diameters: List<Float>): Float {
        return if (diameters.isNotEmpty()) {
            val average = diameters.average().toFloat()
            round(average * 100.0f) * 0.01f
        } else {
            0.0f
        }
    }

    fun findStandardDeviation(diameters: List<Float>): Double {
        return if (diameters.isNotEmpty()) {
            val avg = diameters.average()
            // Perform the Sum of (value-avg)^2
            val sum = diameters.sumOf { d -> (d - avg).pow(2.0) }
            // Put it all together
            val stdDev = sqrt(sum / (diameters.size - 1))
            round(stdDev * 1000) / 1000
        } else {
            0.0
        }
    }
    
    // Performance optimization: Cache results to avoid recalculation
    private val averageCache = mutableMapOf<List<Float>, Float>()
    private val stdDevCache = mutableMapOf<List<Float>, Double>()
    
    fun findAverageValueOptimized(diameters: List<Float>): Float {
        return averageCache.getOrPut(diameters) {
            if (diameters.isNotEmpty()) {
                val average = diameters.average().toFloat()
                round(average * 100.0f) * 0.01f
            } else {
                0.0f
            }
        }
    }
    
    fun findStandardDeviationOptimized(diameters: List<Float>): Double {
        return stdDevCache.getOrPut(diameters) {
            if (diameters.isNotEmpty()) {
                val avg = diameters.average()
                // Perform the Sum of (value-avg)^2
                val sum = diameters.sumOf { d -> (d - avg).pow(2.0) }
                // Put it all together
                val stdDev = sqrt(sum / (diameters.size - 1))
                round(stdDev * 1000) / 1000
            } else {
                0.0
            }
        }
    }
    
    // Clear cache when needed to prevent memory leaks
    fun clearCache() {
        averageCache.clear()
        stdDevCache.clear()
    }
}