package com.example.pupilx.managers

import com.example.pupilx.utils.PchipInterpolator
import kotlin.math.round
import kotlin.math.sqrt

class DiameterSmoothingManager {

    // All Arrays Here
    var array01: MutableList<Float> = mutableListOf()
    var array01TimestampsFirst: MutableList<Float> = mutableListOf()

    private var array01RemovedZero: MutableList<Float> = mutableListOf()
    private var array01TimeStamps: MutableList<Float> = mutableListOf()

    private var array02: MutableList<Float> = mutableListOf()
    private var array02TimeStamps: MutableList<Float> = mutableListOf()

    // values
    var LatencyValue: String = ""
    var amplitudeof_constrictionVal: String = ""
    var amplitudeof_DilationVal: String = ""
    var baseLine_Val: String = ""
    var constriction_Amount: String = ""
    var velocity_of_Constriction: String = ""
    var velocity_of_Dilation: String = ""

    var arrayInstantaneousVelocity: MutableList<String> = mutableListOf()
    var arrayInstantaneousVelocityTimestamps: MutableList<String> = mutableListOf()

    private var removingHighValue: MutableList<Float> = mutableListOf()
    private var removingHighValueTimestamp: MutableList<Float> = mutableListOf()

    fun CalculateMovingAverage(diameters: List<Float>, timeStamps: List<Float>, loop_count: Int) {
        ClearAllList()
        RemoveZerosFromList(diameters, timeStamps, loop_count)
    }

    private fun RemoveZerosFromList(diameters: List<Float>, timeStamps: List<Float>, loop_count: Int) {
        if (diameters.isNotEmpty()) {
            for (i in timeStamps.indices) {
                if (diameters[i] != 0f) {
                    array01RemovedZero.add(diameters[i])
                    array01TimeStamps.add(timeStamps[i])
                }
            }

            // not consider above 10 value
            for (i in array01TimeStamps.indices) {
                if (array01RemovedZero[i] <= 10f) {
                    removingHighValue.add(array01RemovedZero[i])
                    removingHighValueTimestamp.add(array01TimeStamps[i])
                }
            }

            if (array01RemovedZero.isNotEmpty() && array01RemovedZero.size == array01TimeStamps.size) {
                // Use PchipInterpolator instead of simpleMovingAverage.NewPchipp3
                val interpolator = PchipInterpolator(array01TimeStamps, array01RemovedZero)
                val tempTime = array01TimeStamps // Assuming we want to interpolate at original timestamps
                val temp = interpolator.interpolate(tempTime)

                array01.addAll(temp)
                array01TimestampsFirst.addAll(tempTime)
            }

            CalculateMovingDifference(array01, array01TimestampsFirst, loop_count)
        }
    }

    private fun CalculateMovingDifference(arryList: List<Float>, timeStamps: List<Float>, loop_count: Int) {
        if (arryList.isNotEmpty()) {
            for (i in 0 until arryList.size - 1) {
                array02.add(arryList[i + 1] - arryList[i])
                array02TimeStamps.add(timeStamps[i])
            }
        }
        CalculateLatency(loop_count)
        Instantaneousvelocity()
    }

    private fun Instantaneousvelocity() {
        if (array02.isNotEmpty()) {
            for (i in array02.indices) {
                val temp_newTimestamp = if (array02TimeStamps.size > 1) array02TimeStamps[1] - array02TimeStamps[0] else 1f
                val temp04 = (array02[i] / temp_newTimestamp)
                val temp05 = temp04 * 1000f
                arrayInstantaneousVelocity.add(temp05.toString())
                arrayInstantaneousVelocityTimestamps.add(array02TimeStamps[i].toString())
            }
        }
    }

    private fun CalculateLatency(loop_Count: Int) {
        var latencyValueA = 0f

        if (loop_Count == 6) {
            val tempBase = mutableListOf<Float>()
            for (i in array01TimestampsFirst.indices) {
                if (array01TimestampsFirst[i] > 0f && array01TimestampsFirst[i] <= 6000f) {
                    tempBase.add(array01[i])
                }
            }

            var baseValue = 0f
            var baseStandardValue = 0.0

            if (tempBase.isNotEmpty()) {
                baseValue = FindAverageValue(tempBase)
                baseStandardValue = FindStandardDeviation(tempBase)
            }

            val tempBaseValue = baseValue - (2 * baseStandardValue).toFloat()

            var temp3 = 0f
            if (array01TimestampsFirst.isNotEmpty()) {
                for (i in array01TimestampsFirst.indices) {
                    if (array01TimestampsFirst[i] > 6000f) {
                        if (array01[i] < tempBaseValue) {
                            temp3 = array01TimestampsFirst[i]
                            break
                        }
                    }
                }
                latencyValueA = temp3 - 6000f
                latencyValueA /= 1000f
                latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
            }
        } else if (loop_Count == 8) {
            val tempBase = mutableListOf<Float>()
            for (i in array01TimestampsFirst.indices) {
                if (array01TimestampsFirst[i] > 0f && array01TimestampsFirst[i] <= 6000f) {
                    tempBase.add(array01[i])
                }
            }

            var baseValue = 0f
            var baseStandardValue = 0.0

            if (tempBase.isNotEmpty()) {
                baseValue = FindAverageValue(tempBase)
                baseStandardValue = FindStandardDeviation(tempBase)
            }

            val tempBaseValue = baseValue - (2 * baseStandardValue).toFloat()

            var temp3 = 0f
            if (array01TimestampsFirst.isNotEmpty()) {
                for (i in array01TimestampsFirst.indices) {
                    if (array01TimestampsFirst[i] > 6000f) {
                        if (array01[i] < tempBaseValue) {
                            temp3 = array01TimestampsFirst[i]
                            break
                        }
                    }
                }
                latencyValueA = temp3 - 6000f
                latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
            }
        } else if (array02TimeStamps.isNotEmpty()) {
            for (i in array02TimeStamps.indices) {
                when (loop_Count) {
                    1 -> if (array02TimeStamps[i] > 5000f) {
                        latencyValueA = array02TimeStamps[i] - 5000f
                        latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                        LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
                        break
                    }
                    2 -> if (array02TimeStamps[i] > 0f) {
                        latencyValueA = array02TimeStamps[i]
                        latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                        LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
                        break
                    }
                    3 -> if (array02TimeStamps[i] > 10000f) {
                        latencyValueA = array02TimeStamps[i]
                        latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                        LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
                        break
                    }
                    4 -> if (array02TimeStamps[i] > 12000f) {
                        latencyValueA = array02TimeStamps[i]
                        latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                        LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
                        break
                    }
                    5 -> if (array02TimeStamps[i] > 19000f) {
                        latencyValueA = array02TimeStamps[i]
                        latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                        LatencyValue = if (latencyValueA != 0f) latencyValueA.toString() else "0"
                        break
                    }
                }
            }
        }
    }

    private fun ClearAllList() {
        array01.clear()
        array01TimestampsFirst.clear()
        array01RemovedZero.clear()
        array01TimeStamps.clear()
        array02.clear()
        array02TimeStamps.clear()
        arrayInstantaneousVelocity.clear()
        arrayInstantaneousVelocityTimestamps.clear()
        removingHighValueTimestamp.clear()
        removingHighValue.clear()

        LatencyValue = ""
        amplitudeof_constrictionVal = ""
        amplitudeof_DilationVal = ""
        baseLine_Val = ""
        constriction_Amount = ""
        velocity_of_Constriction = ""
        velocity_of_Dilation = ""
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
            val sum = diameters.sumOf { (it - avg) * (it - avg) }
            round(sqrt(sum / (diameters.size - 1)) * 1000.0) / 1000.0
        } else {
            0.0
        }
    }
}
