package com.example.pupilx.data

import com.example.pupilx.models.EyeInfo
import com.example.pupilx.models.PatientDataManager
import com.example.pupilx.models.PatientTestDataList

class PatientDataRepository {

    fun getDummyPatientTestData(): PatientTestDataList {
        // Create dummy data for demonstration purposes
        val eyeInfoOS = EyeInfo(
            eye = "OS",
            diameters = listOf(5.0f, 4.8f, 4.5f, 4.2f, 4.0f, 3.8f, 3.5f, 3.2f, 3.0f, 3.2f, 3.5f, 3.8f, 4.0f, 4.2f, 4.5f, 4.8f, 5.0f)
        )
        val eyeInfoOD = EyeInfo(
            eye = "OD",
            diameters = listOf(5.1f, 4.9f, 4.6f, 4.3f, 4.1f, 3.9f, 3.6f, 3.3f, 3.1f, 3.3f, 3.6f, 3.9f, 4.1f, 4.3f, 4.6f, 4.9f, 5.1f)
        )

        val patientDataManager = PatientDataManager(
            testTitle = "FixedIntensity_Bino",
            eyeInfoList = listOf(eyeInfoOS, eyeInfoOD),
            timeStamps = listOf(0f, 1000f, 2000f, 3000f, 4000f, 5000f, 6000f, 7000f, 8000f, 9000f, 10000f, 11000f, 12000f, 13000f, 14000f, 15000f, 16000f)
        )

        return PatientTestDataList(listOf(patientDataManager))
    }
}