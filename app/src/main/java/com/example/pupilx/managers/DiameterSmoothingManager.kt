package com.example.pupilx.managers

import com.example.pupilx.models.GraphValueCalculation
import com.example.pupilx.models.GraphValueCalculationNew
import kotlin.math.*

class DiameterSmoothingManager(private val calculationManager: CalculationManager) {
    // All Arrays Here
    val array01 = ArrayList<Float>()
    val array01TimestampsFirst = ArrayList<Float>()

    private val array01RemovedZero = ArrayList<Float>()
    private val array01TimeStamps = ArrayList<Float>()
    private val array02 = ArrayList<Float>()
    private val array02TimeStamps = ArrayList<Float>()

    // Values
    private var latencyValueA = 0f
    var latencyValue: String = ""

    var amplitudeofConstrictionVal: String = ""
    var amplitudeofDilationVal: String = ""
    var baseLineVal: String = ""
    var constrictionAmount: String = ""
    var velocityOfConstriction: String = ""
    var velocityOfDilation: String = ""

    val instantaneousVelocity = ArrayList<String>()
    val instantaneousVelocityTimestamps = ArrayList<String>()

    private val removingHighValue = ArrayList<Float>()
    private val removingHighValueTimestamp = ArrayList<Float>()
    
    // Performance optimization: Pre-allocate collections with initial capacity
    private var initialized = false
    
    private fun initializeCollections() {
        if (!initialized) {
            array01RemovedZero.ensureCapacity(1000)
            array01TimeStamps.ensureCapacity(1000)
            array02.ensureCapacity(1000)
            array02TimeStamps.ensureCapacity(1000)
            removingHighValue.ensureCapacity(1000)
            removingHighValueTimestamp.ensureCapacity(1000)
            initialized = true
        }
    }

    fun calculateMovingAverage(diameters: List<Float>, timeStamps: List<Float>, loopCount: Int) {
        initializeCollections()
        clearAllList()

        // Remove zeros from list
        removeZerosFromList(diameters, timeStamps, loopCount)
    }

    private fun removeZerosFromList(diameters: List<Float>, timeStamps: List<Float>, loopCount: Int) {
        if (diameters.isNotEmpty()) {
            // Performance optimization: Use indexed access instead of iterator
            for (i in timeStamps.indices) {
                if (diameters[i] != 0f) {
                    array01RemovedZero.add(diameters[i])
                    array01TimeStamps.add(timeStamps[i])
                }
            }

            // Not consider above 10 value
            for (i in array01RemovedZero.indices) {
                if (array01RemovedZero[i] <= 10) {
                    removingHighValue.add(array01RemovedZero[i])
                    removingHighValueTimestamp.add(array01TimeStamps[i])
                }
            }

            if (array01RemovedZero.isNotEmpty() && array01RemovedZero.size == array01TimeStamps.size) {
                // Simple moving average implementation would go here
                // For now, we'll just copy the values
                array01.addAll(removingHighValue)
                array01TimestampsFirst.addAll(removingHighValueTimestamp)
            }

            calculateMovingDifference(array01, array01TimestampsFirst, loopCount)
        }
    }

    private fun calculateMovingDifference(arryList: List<Float>, timeStamps: List<Float>, loopCount: Int) {
        // Doing Moving difference and removing the last value from array as it not useful
        if (arryList.isNotEmpty()) {
            // Performance optimization: Pre-allocate array02 and array02TimeStamps
            array02.ensureCapacity(arryList.size - 1)
            array02TimeStamps.ensureCapacity(arryList.size - 1)
            
            for (i in 0 until arryList.size - 1) {
                array02.add(arryList[i + 1] - arryList[i])
                array02TimeStamps.add(timeStamps[i])
            }
        }

        calculateLatency(loopCount)
        instantaneousVelocity()
    }

    private fun instantaneousVelocity() {
        // Calculate instantaneous velocity
        if (array02.isNotEmpty()) {
            // Performance optimization: Pre-allocate collections
            instantaneousVelocity.ensureCapacity(array02.size)
            instantaneousVelocityTimestamps.ensureCapacity(array02.size)
            
            val tempNewTimestamp = if (array02TimeStamps.size > 1) {
                array02TimeStamps[1] - array02TimeStamps[0]
            } else {
                1f
            }
            
            for (i in array02.indices) {
                val temp04 = array02[i] / tempNewTimestamp
                val temp05 = temp04 * 1000f
                instantaneousVelocity.add(temp05.toString())
                instantaneousVelocityTimestamps.add(array02TimeStamps[i].toString())
            }
        }
    }

    private fun calculateLatency(loopCount: Int) {
        latencyValueA = 0f
        latencyValue = ""

        when (loopCount) {
            6, 8 -> {
                // Temp solution needs change later................................
                var baseValue = 0f
                var baseStandardValue = 0.0

                val tempBase = mutableListOf<Float>()
                for (i in array01TimestampsFirst.indices) {
                    if (array01TimestampsFirst[i] > 0f && array01TimestampsFirst[i] <= 6000f) {
                        tempBase.add(array01[i])
                    }
                }

                if (tempBase.isNotEmpty()) {
                    baseValue = calculationManager.findAverageValueOptimized(tempBase)
                    baseStandardValue = calculationManager.findStandardDeviationOptimized(tempBase)
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
                    latencyValueA = latencyValueA / 1000f
                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                    latencyValue = if (latencyValueA != 0f) {
                        latencyValueA.toString()
                    } else {
                        "0"
                    }
                }
            }
            else -> {
                if (array02TimeStamps.isNotEmpty()) {
                    for (i in array02TimeStamps.indices) {
                        when (loopCount) {
                            1 -> {
                                if (array02TimeStamps[i] > 5000f) {
                                    latencyValueA = array02TimeStamps[i] - 5000f
                                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                                    latencyValue = if (latencyValueA != 0f) {
                                        latencyValueA.toString()
                                    } else {
                                        "0"
                                    }
                                    break
                                }
                            }
                            2 -> {
                                if (array02TimeStamps[i] > 0f) {
                                    latencyValueA = array02TimeStamps[i]
                                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                                    latencyValue = if (latencyValueA != 0f) {
                                        latencyValueA.toString()
                                    } else {
                                        "0"
                                    }
                                    break
                                }
                            }
                            3 -> {
                                if (array02TimeStamps[i] > 10000f) {
                                    latencyValueA = array02TimeStamps[i]
                                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                                    latencyValue = if (latencyValueA != 0f) {
                                        latencyValueA.toString()
                                    } else {
                                        "0"
                                    }
                                    break
                                }
                            }
                            4 -> {
                                if (array02TimeStamps[i] > 12000f) {
                                    latencyValueA = array02TimeStamps[i]
                                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                                    latencyValue = if (latencyValueA != 0f) {
                                        latencyValueA.toString()
                                    } else {
                                        "0"
                                    }
                                    break
                                }
                            }
                            5 -> {
                                if (array02TimeStamps[i] > 19000f) {
                                    latencyValueA = array02TimeStamps[i]
                                    latencyValueA = round(latencyValueA * 100.0f) * 0.01f
                                    latencyValue = if (latencyValueA != 0f) {
                                        latencyValueA.toString()
                                    } else {
                                        "0"
                                    }
                                    break
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private fun clearAllList() {
        array01.clear()
        array01TimestampsFirst.clear()
        array01RemovedZero.clear()
        array01TimeStamps.clear()
        array02.clear()
        array02TimeStamps.clear()
        instantaneousVelocity.clear()
        instantaneousVelocityTimestamps.clear()
        removingHighValueTimestamp.clear()
        removingHighValue.clear()

        latencyValueA = 0f
        latencyValue = ""

        amplitudeofConstrictionVal = ""
        amplitudeofDilationVal = ""
        baseLineVal = ""
        constrictionAmount = ""
        velocityOfConstriction = ""
        velocityOfDilation = ""
    }
}