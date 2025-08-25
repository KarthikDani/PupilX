package com.example.pupilx.managers

import android.content.Context
import com.example.pupilx.models.PatientTestDataList
import com.example.pupilx.models.PatientResultData
import com.example.pupilx.utils.JsonUtils
import java.io.File

class DataManager(private val context: Context) {
    private val jsonUtils = JsonUtils()
    private val fileName = "patient_data.json"
    
    /**
     * Save patient test data to internal storage
     */
    fun savePatientData(patientTestDataList: PatientTestDataList): Boolean {
        return try {
            val json = jsonUtils.toJson(PatientResultData()) // Simplified for now
            val file = File(context.filesDir, fileName)
            file.writeText(json)
            true
        } catch (e: Exception) {
            e.printStackTrace()
            false
        }
    }
    
    /**
     * Load patient test data from internal storage
     */
    fun loadPatientData(): PatientTestDataList? {
        return try {
            val file = File(context.filesDir, fileName)
            if (file.exists()) {
                val json = file.readText()
                // In a real implementation, this would convert from JSON
                PatientTestDataList()
            } else {
                null
            }
        } catch (e: Exception) {
            e.printStackTrace()
            null
        }
    }
    
    /**
     * Clear all saved data
     */
    fun clearData() {
        try {
            val file = File(context.filesDir, fileName)
            if (file.exists()) {
                file.delete()
            }
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }
}