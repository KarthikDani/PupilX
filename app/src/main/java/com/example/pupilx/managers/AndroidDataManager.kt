package com.example.pupilx.managers

import com.example.pupilx.models.PatientTestDataList
import com.example.pupilx.models.PatientResultData

class AndroidDataManager {
    // Old structure of data
    var patientTestDataList: PatientTestDataList = PatientTestDataList(emptyList())
    var patientResultData: PatientResultData = PatientResultData()

    fun getTopicData1() {
        // In a real implementation, this would load data from resources
        // For now, we'll just initialize with empty data
    }

    fun getTopicData(data: String) {
        // In a real implementation, this would parse JSON data
        // For now, we'll just initialize with empty data
    }
}