package com.example.pupilx.managers

import com.example.pupilx.models.PatientResultData

class MainAppManager {
    private val fixedIntensityProtocolManager = FixedIntensityProtocolManager()
    private val variableIntensityProtocolManager = VariableIntensityProtocolManager()
    private val piprMonocular = PIPRMonocular()
    private val extendedPIPRMonocular = ExtendedPIPRMonocular()
    private val emergencyCareProtocolMonocular = EmergencyCareProtocolMonocular()
    private val whiteLightMonocular = WhiteLightMonocular()
    
    private val androidDataManager = AndroidDataManager()
    
    var patientResultData: PatientResultData = PatientResultData()
    
    enum class EyeProtocolType {
        FixedIntensity_Bino,
        VariableIntensity_Bino,
        QuickTest_Bino,
        ExtendedPIPR_Bino,
        PIPR_Mono,
        ExtendedPIPR_Mono,
        EmergencyCare_Mono,
        WhiteLight_Mono
    }
    
    var currentProtocol: EyeProtocolType = EyeProtocolType.FixedIntensity_Bino
    
    fun getProtocolData() {
        // Clear previous results
        patientResultData.velocityCalculations.clear()
        patientResultData.graphValueCalculation.clear()
        patientResultData.graphValueCalculation.clear()
        
        when (currentProtocol) {
            EyeProtocolType.ExtendedPIPR_Bino -> {
                // Implementation would go here
            }
            EyeProtocolType.FixedIntensity_Bino -> {
                fixedIntensityProtocolManager.fixedIntensityTestBinocular()
            }
            EyeProtocolType.QuickTest_Bino -> {
                // Implementation would go here
            }
            EyeProtocolType.VariableIntensity_Bino -> {
                variableIntensityProtocolManager.variableIntensityTestBinocular()
            }
            EyeProtocolType.PIPR_Mono -> {
                piprMonocular.piprMonocularTest()
            }
            EyeProtocolType.ExtendedPIPR_Mono -> {
                extendedPIPRMonocular.extendedPIPRMonocularTest()
            }
            EyeProtocolType.EmergencyCare_Mono -> {
                emergencyCareProtocolMonocular.emergencyCareProtocolTest()
            }
            EyeProtocolType.WhiteLight_Mono -> {
                whiteLightMonocular.whiteLightPIPRTest()
            }
        }
    }
    
    fun saveResultsToFile(filePath: String) {
        // Implementation would go here
        // This would use the JsonUtils to save the results
    }
}