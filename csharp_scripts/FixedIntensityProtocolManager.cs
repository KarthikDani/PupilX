using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixedIntensityProtocolManager : MonoBehaviour
{
    public AndroidDataManager androidDataManager;
    public CalculationManager calculationManager;
    public ShowResult resultManagerA;


    public DiameterSmoothingManger diameterSmoothBinoLeftManager;
    public DiameterSmoothingManger diameterSmoothBinoRightManager;



    public string low, medium, high;

    // Main Lists

    [Header("MAIN List")]
    public List<float> ostimeStampValues_smooth = new List<float>();
    public List<float> odtimeStampValues__smooth = new List<float>();

    public List<float> osDiameters_Smooth = new List<float>();
    public List<float> oDDiameters_Smooth = new List<float>();

    //raw data
    public List<float> timeStampValues = new List<float>();
    public List<float> osDiameters = new List<float>();
    public List<float> oDDiameters = new List<float>();

    // BINOCULAR LIST BELOW--------------------------
    [Header("BINOCULAR List")]
    public List<float> leftbaseValue = new List<float>();
    public List<float> rightbaseValue = new List<float>();
    public List<float> baseValueTimestamp = new List<float>();
    public List<float> Right_baseValueTimestamp = new List<float>();

    public List<float> leftConstrictedValue = new List<float>();
    public List<float> rightConstrictedValue = new List<float>();
    public List<float> leftConstrictedTimestamp = new List<float>();
    public List<float> rightConstrictedTimeStamp = new List<float>();


    public List<float> leftDilationValue = new List<float>();
    public List<float> rightDilationValue = new List<float>();
    public List<float> leftDilationTimestamp = new List<float>();
    public List<float> rightDilationTimestamp = new List<float>();




    private void Start()
    {

    }

    void ClearAllList()
    {

        low = "";
        medium = "";
        high = "";
        //result list
        resultManagerA.patientResultData.velocityCalculations.Clear();
        resultManagerA.patientResultData.graphValueCalculation.Clear();


        // main list 
        ostimeStampValues_smooth.Clear();
        odtimeStampValues__smooth.Clear();
        osDiameters_Smooth.Clear();
        oDDiameters_Smooth.Clear();

        //Raw Data
        osDiameters.Clear();
        oDDiameters.Clear();
        timeStampValues.Clear();

        // time stamps-----
        baseValueTimestamp.Clear();
        Right_baseValueTimestamp.Clear();
        leftConstrictedTimestamp.Clear();
        rightConstrictedTimeStamp.Clear();
        leftDilationTimestamp.Clear();
        rightDilationTimestamp.Clear();


        // Binocular List

        leftbaseValue.Clear();
        rightbaseValue.Clear();
        leftConstrictedValue.Clear();
        rightConstrictedValue.Clear();
        leftDilationValue.Clear();
        rightDilationValue.Clear();
    }



    // FixedIntensity (Binocular)
    public void FixedIntensityTestBinocular()
    {



        ClearAllList();

        low = androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle;

        #region Local Data Check

        // local checking ---------------------------

        for (int i = 0; i < androidDataManager.patientTestDataList.patientDataManagerList.Count; i++)
        {
            if (androidDataManager.patientTestDataList.patientDataManagerList[i].testTitle == low)
            {
                for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                {
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            osDiameters.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            oDDiameters.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                }
                for (int j = 0; j < androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps.Count; j++)
                {
                    timeStampValues.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                }
            }
        }
        #endregion

        //OS Table Creating =============================================

        v3OsAlgorithm();
        osDiameters_Smooth = diameterSmoothBinoLeftManager.Array_01;
        ostimeStampValues_smooth = diameterSmoothBinoLeftManager.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {
            if (ostimeStampValues_smooth[j] >= 0 && ostimeStampValues_smooth[j] <= 5000)
            {
                leftbaseValue.Add(osDiameters_Smooth[j]);
                baseValueTimestamp.Add(ostimeStampValues_smooth[j]);
            }

            if (ostimeStampValues_smooth[j] > 5000 && ostimeStampValues_smooth[j] <= 6000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);
            }


            if (ostimeStampValues_smooth[j] > 6000 && ostimeStampValues_smooth[j] <= 12000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);
            }
        }

        //OD  Table Creating =============================================

        V3OdAlgorithm();
        oDDiameters_Smooth = diameterSmoothBinoRightManager.Array_01;
        odtimeStampValues__smooth = diameterSmoothBinoRightManager.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] >= 0 && odtimeStampValues__smooth[j] <= 5000)
            {
                rightbaseValue.Add(oDDiameters_Smooth[j]);
                Right_baseValueTimestamp.Add(odtimeStampValues__smooth[j]);
            }

            if (odtimeStampValues__smooth[j] > 12000 && odtimeStampValues__smooth[j] <= 13000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);
            }

            if (odtimeStampValues__smooth[j] > 13000 && odtimeStampValues__smooth[j] <= 19000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);
            }
        }

        // Caluculation Start Here----------------

        // Algorithm V2 OS Values Add Values--------------------
        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data1 = new VelocityCalculationData(androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);


        //// Algorithm V2  OD Values Add Values--------------------
        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data3 = new VelocityCalculationData(androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data3);

    }


    void V3OdAlgorithm()
    {
        // Algorithm V3 OD Values Add Values--------------------
        diameterSmoothBinoRightManager.CalculateMovingAverage(oDDiameters, timeStampValues,1);
        var data2 = new GraphValueCalculation(androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothBinoRightManager.amplitudeof_constrictionVal, diameterSmoothBinoRightManager.amplitudeof_DilationVal, diameterSmoothBinoRightManager.LatencyValue, diameterSmoothBinoRightManager.baseLine_Val, diameterSmoothBinoRightManager.constriction_Amount, diameterSmoothBinoRightManager.velocity_of_Constriction, diameterSmoothBinoRightManager.velocity_of_Dilation, diameterSmoothBinoRightManager.Array_Instantaneousvelocity, diameterSmoothBinoRightManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoRightManager.Array_01, diameterSmoothBinoRightManager.Array_01_Timestamps_first)
        {

        };
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

    }


    void v3OsAlgorithm()
    {
        // Algorithm V3 OS Values Add Values--------------------
        diameterSmoothBinoLeftManager.CalculateMovingAverage(osDiameters, timeStampValues,1);
        var data = new GraphValueCalculation(androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothBinoLeftManager.amplitudeof_constrictionVal, diameterSmoothBinoLeftManager.amplitudeof_DilationVal, diameterSmoothBinoLeftManager.LatencyValue, diameterSmoothBinoLeftManager.baseLine_Val, diameterSmoothBinoLeftManager.constriction_Amount, diameterSmoothBinoLeftManager.velocity_of_Constriction, diameterSmoothBinoLeftManager.velocity_of_Dilation, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoLeftManager.Array_01, diameterSmoothBinoLeftManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data);

    }
}
