using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableIntensityProtocolManager : MonoBehaviour
{
    public AndroidDataManager androidDataManager;
    public CalculationManager calculationManager;
    public ShowResult resultManagerA;


    public DiameterSmoothingManger diameterSmoothBinoLeftManager;
    public DiameterSmoothingManger diameterSmoothBinoRightManager;


    public string low, medium, high;

    // Main Lists

    [Header("Temp List")]
  
    public List<float> ostimeStampValues_smooth = new List<float>();
    public List<float> odtimeStampValues__smooth = new List<float>();

    public List<float> osDiameters_Smooth = new List<float>();
    public List<float> oDDiameters_Smooth = new List<float>();

    [Header("Low")]
    public List<float> timeStampValues_Low = new List<float>();
    public List<float> osDiameters_low = new List<float>();
    public List<float> oDDiameters_low = new List<float>();

    [Header("Medium")]
    public List<float> timeStampValues_Medium = new List<float>();
    public List<float> osDiameters_Medium = new List<float>();
    public List<float> oDDiameters_Medium = new List<float>();

    [Header("High")]
    public List<float> timeStampValues_High = new List<float>();
    public List<float> osDiameters_High = new List<float>();
    public List<float> oDDiameters_High = new List<float>();

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


    // Start is called before the first frame update
    void Start()
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


        timeStampValues_Low.Clear();
        osDiameters_low.Clear();
        oDDiameters_low.Clear();

        timeStampValues_Medium.Clear();
        osDiameters_Medium.Clear();
        oDDiameters_Medium.Clear();

        timeStampValues_High.Clear();
        osDiameters_High.Clear();
        oDDiameters_High.Clear();


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

    public void VariableIntensityTestBinocular()
    {
        ClearAllList();

        low = androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle;
        medium = androidDataManager.patientTestDataList.patientDataManagerList[1].testTitle;
        high = androidDataManager.patientTestDataList.patientDataManagerList[2].testTitle;

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
                            osDiameters_low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            oDDiameters_low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                }
                for (int j = 0; j < androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps.Count; j++)
                {
                    timeStampValues_Low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                }

                //  diameterSmoothingManger.CalculateMovingAverage(osDiameters_low, timeStampValues_Low);


            }
            if (androidDataManager.patientTestDataList.patientDataManagerList[i].testTitle == medium)
            {
                for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                {
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            osDiameters_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            oDDiameters_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                }
                for (int j = 0; j < androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps.Count; j++)
                {
                    timeStampValues_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                }
            }
            if (androidDataManager.patientTestDataList.patientDataManagerList[i].testTitle == high)
            {
                for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                {
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            osDiameters_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                    {
                        for (int l = 0; l < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters.Count; l++)
                        {
                            oDDiameters_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[l]);
                        }
                    }
                }
                for (int j = 0; j < androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps.Count; j++)
                {
                    timeStampValues_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                }
            }
        }

        LowVariableIntensity();

    }


    void LowVariableIntensity()
    {

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add--------------------
        diameterSmoothBinoLeftManager.CalculateMovingAverage(osDiameters_low, timeStampValues_Low,3);
        var data = new GraphValueCalculation(low, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothBinoLeftManager.amplitudeof_constrictionVal, diameterSmoothBinoLeftManager.amplitudeof_DilationVal, diameterSmoothBinoLeftManager.LatencyValue, diameterSmoothBinoLeftManager.baseLine_Val, diameterSmoothBinoLeftManager.constriction_Amount, diameterSmoothBinoLeftManager.velocity_of_Constriction, diameterSmoothBinoLeftManager.velocity_of_Dilation, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoLeftManager.Array_01, diameterSmoothBinoLeftManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data);

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

        // Algorithm V3 OD Values Add Values--------------------
        diameterSmoothBinoRightManager.CalculateMovingAverage(oDDiameters_low, timeStampValues_Low,3);
        var data2 = new GraphValueCalculation(low, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothBinoRightManager.amplitudeof_constrictionVal, diameterSmoothBinoRightManager.amplitudeof_DilationVal, diameterSmoothBinoRightManager.LatencyValue, diameterSmoothBinoRightManager.baseLine_Val, diameterSmoothBinoRightManager.constriction_Amount, diameterSmoothBinoRightManager.velocity_of_Constriction, diameterSmoothBinoRightManager.velocity_of_Dilation, diameterSmoothBinoRightManager.Array_Instantaneousvelocity, diameterSmoothBinoRightManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoRightManager.Array_01, diameterSmoothBinoRightManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);


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



        // Algorithm V2 OS Values Add --------------------
        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data1 = new VelocityCalculationData(low, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

      
        // Algorithm V2  OD Values Add --------------------
        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data3 = new VelocityCalculationData(low, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data3);

        MediumVariableIntensity();
    }

    void MediumVariableIntensity()
    {

        ClearOnlyDeviLists();

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add --------------------
        diameterSmoothBinoLeftManager.CalculateMovingAverage(osDiameters_Medium, timeStampValues_Medium,3);
        var data = new GraphValueCalculation(medium, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothBinoLeftManager.amplitudeof_constrictionVal, diameterSmoothBinoLeftManager.amplitudeof_DilationVal, diameterSmoothBinoLeftManager.LatencyValue, diameterSmoothBinoLeftManager.baseLine_Val, diameterSmoothBinoLeftManager.constriction_Amount, diameterSmoothBinoLeftManager.velocity_of_Constriction, diameterSmoothBinoLeftManager.velocity_of_Dilation, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoLeftManager.Array_01, diameterSmoothBinoLeftManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data);

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

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothBinoRightManager.CalculateMovingAverage(oDDiameters_Medium, timeStampValues_Medium,3);
        var data2 = new GraphValueCalculation(medium, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothBinoRightManager.amplitudeof_constrictionVal, diameterSmoothBinoRightManager.amplitudeof_DilationVal, diameterSmoothBinoRightManager.LatencyValue, diameterSmoothBinoRightManager.baseLine_Val, diameterSmoothBinoRightManager.constriction_Amount, diameterSmoothBinoRightManager.velocity_of_Constriction, diameterSmoothBinoRightManager.velocity_of_Dilation, diameterSmoothBinoRightManager.Array_Instantaneousvelocity, diameterSmoothBinoRightManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoRightManager.Array_01, diameterSmoothBinoRightManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

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

        // Algorithm V2 OS Values Add --------------------
        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data1 = new VelocityCalculationData(medium, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);  

        // Algorithm V2 OD Values Add --------------------
        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data3 = new VelocityCalculationData(medium, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data3);

        HighVariableIntensity();

    }

    void HighVariableIntensity()
    {

        ClearOnlyDeviLists();

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add --------------------
        diameterSmoothBinoLeftManager.CalculateMovingAverage(osDiameters_High, timeStampValues_High,3);
        var data = new GraphValueCalculation(high, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothBinoLeftManager.amplitudeof_constrictionVal, diameterSmoothBinoLeftManager.amplitudeof_DilationVal, diameterSmoothBinoLeftManager.LatencyValue, diameterSmoothBinoLeftManager.baseLine_Val, diameterSmoothBinoLeftManager.constriction_Amount, diameterSmoothBinoLeftManager.velocity_of_Constriction, diameterSmoothBinoLeftManager.velocity_of_Dilation, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity, diameterSmoothBinoLeftManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoLeftManager.Array_01, diameterSmoothBinoLeftManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data);

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

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothBinoRightManager.CalculateMovingAverage(oDDiameters_High, timeStampValues_High,3);
        var data2 = new GraphValueCalculation(high, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothBinoRightManager.amplitudeof_constrictionVal, diameterSmoothBinoRightManager.amplitudeof_DilationVal, diameterSmoothBinoRightManager.LatencyValue, diameterSmoothBinoRightManager.baseLine_Val, diameterSmoothBinoRightManager.constriction_Amount, diameterSmoothBinoRightManager.velocity_of_Constriction, diameterSmoothBinoRightManager.velocity_of_Dilation, diameterSmoothBinoRightManager.Array_Instantaneousvelocity, diameterSmoothBinoRightManager.Array_Instantaneousvelocity_Timestamps, diameterSmoothBinoRightManager.Array_01, diameterSmoothBinoRightManager.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

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

        // Algorithm V2 OS Values Add --------------------
        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data1 = new VelocityCalculationData(high, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

        // Algorithm V2 OD Values Add --------------------
        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data3 = new VelocityCalculationData(high, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data3);

    }


    void ClearOnlyDeviLists()
    {
        // time stamps-----
        baseValueTimestamp.Clear();
        Right_baseValueTimestamp.Clear();
        leftConstrictedTimestamp.Clear();
        rightConstrictedTimeStamp.Clear();
        leftDilationTimestamp.Clear();
        rightDilationTimestamp.Clear();

        ostimeStampValues_smooth.Clear();
        odtimeStampValues__smooth.Clear();
        osDiameters_Smooth.Clear();
        oDDiameters_Smooth.Clear();


        // Binocular List

        leftbaseValue.Clear();
        rightbaseValue.Clear();
        leftConstrictedValue.Clear();
        rightConstrictedValue.Clear();
        leftDilationValue.Clear();
        rightDilationValue.Clear();
    }
}
