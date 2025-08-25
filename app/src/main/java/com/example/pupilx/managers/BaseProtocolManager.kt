package com.example.pupilx.managers

import com.example.pupilx.models.*

abstract class BaseProtocolManager {
    protected val androidDataManager = AndroidDataManager()
    protected val calculationManager = CalculationManager()
    
    // Main Lists
    protected val timeStampValues = mutableListOf<Float>()
    protected val osDiameters = mutableListOf<Float>()
    protected val odDiameters = mutableListOf<Float>()
    
    // BINOCULAR LIST BELOW
    protected val leftBaseValue = mutableListOf<Float>()
    protected val rightBaseValue = mutableListOf<Float>()
    protected val baseValueTimestamp = mutableListOf<Float>()
    protected val rightBaseValueTimestamp = mutableListOf<Float>()
    
    protected val leftConstrictedValue = mutableListOf<Float>()
    protected val rightConstrictedValue = mutableListOf<Float>()
    protected val leftConstrictedTimestamp = mutableListOf<Float>()
    protected val rightConstrictedTimeStamp = mutableListOf<Float>()
    
    protected val leftDilationValue = mutableListOf<Float>()
    protected val rightDilationValue = mutableListOf<Float>()
    protected val leftDilationTimestamp = mutableListOf<Float>()
    protected val rightDilationTimestamp = mutableListOf<Float>()
    
    protected fun clearAllList() {
        // Raw Data
        osDiameters.clear()
        odDiameters.clear()
        timeStampValues.clear()
        
        // Time stamps
        baseValueTimestamp.clear()
        rightBaseValueTimestamp.clear()
        leftConstrictedTimestamp.clear()
        rightConstrictedTimeStamp.clear()
        leftDilationTimestamp.clear()
        rightDilationTimestamp.clear()
        
        // Binocular List
        leftBaseValue.clear()
        rightBaseValue.clear()
        leftConstrictedValue.clear()
        rightConstrictedValue.clear()
        leftDilationValue.clear()
        rightDilationValue.clear()
    }
    
    protected fun clearOnlyDeviLists() {
        // Time stamps
        baseValueTimestamp.clear()
        rightBaseValueTimestamp.clear()
        leftConstrictedTimestamp.clear()
        rightConstrictedTimeStamp.clear()
        leftDilationTimestamp.clear()
        rightDilationTimestamp.clear()
        
        // Binocular List
        leftBaseValue.clear()
        rightBaseValue.clear()
        leftConstrictedValue.clear()
        rightConstrictedValue.clear()
        leftDilationValue.clear()
        rightDilationValue.clear()
    }
}