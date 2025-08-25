package com.example.pupilx.utils

import com.example.pupilx.managers.CalculationManager
import com.example.pupilx.managers.DiameterSmoothingManager

class TestUtils {
    companion object {
        fun runBasicTests(): Boolean {
            try {
                // Test CalculationManager
                val calculationManager = CalculationManager()
                val testList = listOf(1.0f, 2.0f, 3.0f, 4.0f, 5.0f)
                val average = calculationManager.findAverageValue(testList)
                val stdDev = calculationManager.findStandardDeviation(testList)
                
                // Test DiameterSmoothingManager
                val diameterSmoothingManager = DiameterSmoothingManager(calculationManager)
                
                // Test ImageProcessor
                val imageProcessor = ImageProcessor()
                imageProcessor.releaseBuffers()
                
                // If we reach here, tests passed
                return true
            } catch (e: Exception) {
                e.printStackTrace()
                return false
            }
        }
    }
}