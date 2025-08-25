package com.example.pupilx

import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import com.example.pupilx.managers.MainAppManager
import com.example.pupilx.utils.TestUtils

class MainActivity : AppCompatActivity() {
    private lateinit var mainAppManager: MainAppManager
    
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        
        // Run basic tests to validate functionality
        runTests()
        
        // Initialize the main app manager
        mainAppManager = MainAppManager()
        
        // For demonstration, we'll just call the protocol data method
        // In a real app, this would be triggered by user actions
        mainAppManager.getProtocolData()
    }
    
    private fun runTests() {
        val testResult = TestUtils.runBasicTests()
        if (testResult) {
            Log.d("MainActivity", "All tests passed successfully!")
        } else {
            Log.e("MainActivity", "Some tests failed!")
        }
    }
}