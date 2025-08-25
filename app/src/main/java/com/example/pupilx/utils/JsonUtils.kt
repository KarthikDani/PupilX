package com.example.pupilx.utils

import com.example.pupilx.models.PatientResultData
import com.google.gson.Gson
import com.google.gson.GsonBuilder
import java.io.File
import java.io.FileWriter
import java.io.IOException

class JsonUtils {
    private val gson: Gson = GsonBuilder().setPrettyPrinting().create()
    
    /**
     * Converts PatientResultData to JSON string
     */
    fun toJson(patientResultData: PatientResultData): String {
        return gson.toJson(patientResultData)
    }
    
    /**
     * Converts JSON string to PatientResultData
     */
    fun fromJson(json: String): PatientResultData {
        return gson.fromJson(json, PatientResultData::class.java)
    }
    
    /**
     * Saves PatientResultData to a JSON file
     */
    fun saveToJsonFile(patientResultData: PatientResultData, filePath: String) {
        try {
            val json = toJson(patientResultData)
            val file = File(filePath)
            
            // Create parent directories if they don't exist
            file.parentFile?.mkdirs()
            
            val writer = FileWriter(file)
            writer.write(json)
            writer.close()
        } catch (e: IOException) {
            e.printStackTrace()
        }
    }
    
    /**
     * Loads PatientResultData from a JSON file
     */
    fun loadFromJsonFile(filePath: String): PatientResultData? {
        return try {
            val file = File(filePath)
            if (file.exists()) {
                val json = file.readText()
                fromJson(json)
            } else {
                null
            }
        } catch (e: Exception) {
            e.printStackTrace()
            null
        }
    }
}