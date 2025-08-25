using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteLightMonocular : MonoBehaviour
{
    public AndroidDataManager androidDataManager;
    public CalculationManager calculationManager;
    public ShowResult resultManagerA;

    public DiameterSmoothingManger diameterSmoothingManger;




    public string low, medium, high;

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

    [Header("High1")]
    public List<float> timeStampValues_High1 = new List<float>();
    public List<float> osDiameters_High1 = new List<float>();
    public List<float> oDDiameters_High1 = new List<float>();

    // BINOCULAR LIST BELOW--------------------------
    [Header("MONOCULAR List")]
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


    public List<float> F5secDiameters_os = new List<float>();
    public List<float> F5secDiameters_od = new List<float>();
    public List<float> F5secDiameters_Timestamps = new List<float>();


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
        // 

        ostimeStampValues_smooth.Clear();
        odtimeStampValues__smooth.Clear();
        osDiameters_Smooth.Clear();
        oDDiameters_Smooth.Clear();

        F5secDiameters_os.Clear();
        F5secDiameters_od.Clear();
        F5secDiameters_Timestamps.Clear();


        timeStampValues_Low.Clear();
        osDiameters_low.Clear();
        oDDiameters_low.Clear();

        timeStampValues_Medium.Clear();
        osDiameters_Medium.Clear();
        oDDiameters_Medium.Clear();

        timeStampValues_High.Clear();
        osDiameters_High.Clear();
        oDDiameters_High.Clear();

        timeStampValues_High1.Clear();
        osDiameters_High1.Clear();
        oDDiameters_High1.Clear();


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

    public void WhiteLightPIPRTest()
    {
        ClearAllList();



        low = androidDataManager.patientTestDataList.patientDataManagerList[0].testTitle;
        medium = androidDataManager.patientTestDataList.patientDataManagerList[1].testTitle;
        high = androidDataManager.patientTestDataList.patientDataManagerList[2].testTitle;

        for (int i = 0; i < androidDataManager.patientTestDataList.patientDataManagerList.Count; i++)
        {
            if (androidDataManager.patientTestDataList.patientDataManagerList[i].testTitle == low)
            {

                for (int j = 0; j < androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps.Count; j++)
                {
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] >= 0 && androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] <= 13000)
                    {
                        for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                        {
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                            {
                                osDiameters_low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                            {
                                oDDiameters_low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                        }

                        timeStampValues_Low.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] >= 13000 && androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] <= 20000)
                    {
                        for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                        {
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                            {
                                osDiameters_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                            {
                                oDDiameters_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                        }
                        timeStampValues_Medium.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);
                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] >= 20000 && androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] <= 27000)
                    {
                        for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                        {
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                            {
                                osDiameters_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                            {
                                oDDiameters_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                        }

                        timeStampValues_High.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);

                    }
                    if (androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] >= 27000 && androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j] <= 34000)
                    {
                        for (int k = 0; k < androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList.Count; k++)
                        {
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OS")
                            {
                                osDiameters_High1.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                            if (androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].eye == "OD")
                            {
                                oDDiameters_High1.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].eyeInfoList[k].diameters[j]);
                            }
                        }

                        timeStampValues_High1.Add(androidDataManager.patientTestDataList.patientDataManagerList[i].timeStamps[j]);

                    }

                }
            }

        }
        LowVariableIntensity();
    }

    void LowVariableIntensity()
    {
        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add Values--------------------
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_low, timeStampValues_Low, 6);
        var data2 = new GraphValueCalculation(low, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            //OS Base Value for low and meduim, High here...........

            if (ostimeStampValues_smooth[j] >= 0 && ostimeStampValues_smooth[j] <= 6000)
            {
                leftbaseValue.Add(osDiameters_Smooth[j]);
                baseValueTimestamp.Add(ostimeStampValues_smooth[j]);
            }

            ///////////////////////////////////////////

            if (ostimeStampValues_smooth[j] > 6000 && ostimeStampValues_smooth[j] <= 7000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 7000 && ostimeStampValues_smooth[j] <= 13000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }
        }


        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add Values--------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_low, timeStampValues_Low, 6);
        var data3 = new GraphValueCalculation(low, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            //OD Base Value for low and meduim, High here...........
            if (odtimeStampValues__smooth[j] >= 0 && odtimeStampValues__smooth[j] <= 6000)
            {
                rightbaseValue.Add(oDDiameters_Smooth[j]);
                Right_baseValueTimestamp.Add(odtimeStampValues__smooth[j]);
            }
            /////////////////////////////////

            if (odtimeStampValues__smooth[j] > 6000 && odtimeStampValues__smooth[j] <= 7000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 7000 && odtimeStampValues__smooth[j] <= 13000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);

            }

        }

        // Caluculation Start Here----------------

        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data = new VelocityCalculationData(low, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data);


        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data1 = new VelocityCalculationData(low, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

        MediumVariableIntensity();
    }

    void MediumVariableIntensity()
    {

        ClearOnlyDeviLists01();

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_Medium, timeStampValues_Medium, 7);
        var data2 = new GraphValueCalculation(medium, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            if (ostimeStampValues_smooth[j] > 13000 && ostimeStampValues_smooth[j] <= 14000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 14000 && ostimeStampValues_smooth[j] <= 20000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }

        }

        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_Medium, timeStampValues_Medium, 7);
        var data3 = new GraphValueCalculation(medium, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] > 13000 && odtimeStampValues__smooth[j] <= 14000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 14000 && odtimeStampValues__smooth[j] <= 20000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);

            }

        }

        // Caluculation Start Here----------------      

        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data = new VelocityCalculationData(medium, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data);


        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data1 = new VelocityCalculationData(medium, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

        HighVariableIntensity();
    }

    void HighVariableIntensity()
    {

        ClearOnlyDeviLists01();

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_High, timeStampValues_High, 8);
        var data2 = new GraphValueCalculation(high, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            if (ostimeStampValues_smooth[j] > 20000 && ostimeStampValues_smooth[j] <= 21000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 21000 && ostimeStampValues_smooth[j] <= 27000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }

        }


        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_High, timeStampValues_High, 8);
        var data3 = new GraphValueCalculation(high, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] >= 20000 && odtimeStampValues__smooth[j] <= 21000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 21000 && odtimeStampValues__smooth[j] <= 27000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);

            }

        }

        // Caluculation Start Here----------------

        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data = new VelocityCalculationData(high, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data);



        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data1 = new VelocityCalculationData(high, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

        HighVariableIntensity4thLoop();

    }

    void HighVariableIntensity4thLoop()
    {

        ClearOnlyDeviLists01();

        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_High1, timeStampValues_High1, 9);
        var data2 = new GraphValueCalculation(high, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            if (ostimeStampValues_smooth[j] > 27000 && ostimeStampValues_smooth[j] <= 28000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 28000 && ostimeStampValues_smooth[j] <= 34000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }

        }


        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_High1, timeStampValues_High1, 9);
        var data3 = new GraphValueCalculation(high, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] >= 27000 && odtimeStampValues__smooth[j] <= 28000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 28000 && odtimeStampValues__smooth[j] <= 34000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);

            }

        }

        // Caluculation Start Here----------------

        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data = new VelocityCalculationData(high, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data);



        calculationManager.CalucationVelocityValue(rightbaseValue, rightConstrictedValue, rightDilationValue, Right_baseValueTimestamp, rightConstrictedTimeStamp, rightDilationTimestamp);
        var data1 = new VelocityCalculationData(high, "LightFlashOnSequence RightEyeResponse", "OD", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value, calculationManager.Amplitude_Constriction, calculationManager.Amplitude_Dilation);
        resultManagerA.patientResultData.velocityCalculations.Add(data1);

    }

    void ClearOnlyDeviLists01()
    {
        leftConstrictedTimestamp.Clear();
        rightConstrictedTimeStamp.Clear();
        leftDilationTimestamp.Clear();
        rightDilationTimestamp.Clear();

        leftConstrictedValue.Clear();
        rightConstrictedValue.Clear();
        leftDilationValue.Clear();
        rightDilationValue.Clear();


        ostimeStampValues_smooth.Clear();
        odtimeStampValues__smooth.Clear();
        osDiameters_Smooth.Clear();
        oDDiameters_Smooth.Clear();
    }

    /// <summary>
    /// /////////////combine the array start 
    /// </summary>

    public List<float> finalArry_01_diameters = new List<float>();
    public List<float> finalArry_01_timestamps = new List<float>();

    public List<float> final_Smooth_diameters = new List<float>();
    public List<float> final_Smooth_timestamps = new List<float>();

    public List<float> finalArry_01_diameters_od = new List<float>();
    public List<float> finalArry_01_timestamps_od = new List<float>();

    public List<float> final_Smooth_diameters_od = new List<float>();
    public List<float> final_Smooth_timestamps_od = new List<float>();


    public List<float> latency_Value_os = new List<float>();
    public List<float> latency_Value_od = new List<float>();

    /// <summary>
    /// //////////////////   OS   ////////////////////////////////////////////
    /// </summary>

    public List<float> base_Value = new List<float>();
    public List<float> base_Value_stand = new List<float>();

    public List<float> constr_Value = new List<float>();
    public List<float> constr_Value_stand = new List<float>();

    public List<float> dialation_Value = new List<float>();
    public List<float> dialation_Value_stand = new List<float>();

    public List<float> constrictionVelocity = new List<float>();
    public List<float> dilationVelocity = new List<float>();
    public List<float> percentageChangeValue = new List<float>();
    public List<float> amplitudeConstriction = new List<float>();
    public List<float> amplitudeDilatation = new List<float>();

    /// <summary>
    /// //////////////////   OD   ////////////////////////////////////////////
    /// </summary>
    /// 

    public List<float> base_Value_od = new List<float>();
    public List<float> base_Value_stand_od = new List<float>();

    public List<float> constr_Value_od = new List<float>();
    public List<float> constr_Value_stand_od = new List<float>();

    public List<float> dialation_Value_od = new List<float>();
    public List<float> dialation_Value_stand_od = new List<float>();

    public List<float> constrictionVelocity_od = new List<float>();
    public List<float> dilationVelocity_od = new List<float>();
    public List<float> percentageChangeValue_od = new List<float>();
    public List<float> amplitudeConstriction_od = new List<float>();
    public List<float> amplitudeDilatation_od = new List<float>();

    public void CombineTheArrays()
    {
        ClearCombineArrayList();

        for (int i = 0; i < resultManagerA.patientResultData.graphValueCalculation.Count; i++)
        {
            if (resultManagerA.patientResultData.graphValueCalculation[i].eye == "OS")
            {
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].Array01Diameters.Count; j++)
                {
                    finalArry_01_diameters.Add(resultManagerA.patientResultData.graphValueCalculation[i].Array01Diameters[j]);
                }
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].Array01TimeStamps.Count; j++)
                {
                    finalArry_01_timestamps.Add(resultManagerA.patientResultData.graphValueCalculation[i].Array01TimeStamps[j]);
                }

                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].smoothDiameters.Count; j++)
                {
                    float tmp = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].smoothDiameters[j]);
                    final_Smooth_diameters.Add(tmp);
                }
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].smoothTimeStamps.Count; j++)
                {
                    float tmp1 = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].smoothTimeStamps[j]);
                    final_Smooth_timestamps.Add(tmp1);
                }

                if (!string.IsNullOrEmpty(resultManagerA.patientResultData.graphValueCalculation[i].latencyValue))
                {
                    float temp_latency = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].latencyValue);
                    latency_Value_os.Add(temp_latency);
                }



            }
            else if (resultManagerA.patientResultData.graphValueCalculation[i].eye == "OD")
            {
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].Array01Diameters.Count; j++)
                {
                    finalArry_01_diameters_od.Add(resultManagerA.patientResultData.graphValueCalculation[i].Array01Diameters[j]);
                }
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].Array01TimeStamps.Count; j++)
                {
                    finalArry_01_timestamps_od.Add(resultManagerA.patientResultData.graphValueCalculation[i].Array01TimeStamps[j]);
                }

                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].smoothDiameters.Count; j++)
                {
                    float tmp = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].smoothDiameters[j]);
                    final_Smooth_diameters_od.Add(tmp);
                }
                for (int j = 0; j < resultManagerA.patientResultData.graphValueCalculation[i].smoothTimeStamps.Count; j++)
                {
                    float tmp1 = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].smoothTimeStamps[j]);
                    final_Smooth_timestamps_od.Add(tmp1);
                }

                if (!string.IsNullOrEmpty(resultManagerA.patientResultData.graphValueCalculation[i].latencyValue))
                {
                    float temp_latency = (float.Parse)(resultManagerA.patientResultData.graphValueCalculation[i].latencyValue);
                    latency_Value_od.Add(temp_latency);
                }



            }
        }

        for (int i = 0; i < resultManagerA.patientResultData.velocityCalculations.Count; i++)
        {
            if (resultManagerA.patientResultData.velocityCalculations[i].eye == "OS")
            {
                string temp_base = resultManagerA.patientResultData.velocityCalculations[i].baseValue;
                string temp_constrictedValue = resultManagerA.patientResultData.velocityCalculations[i].constrictedValue;
                string temp_dilationValue = resultManagerA.patientResultData.velocityCalculations[i].dilationValue;

                float tmp_base = 0;
                float tmp_base_stand = 0;
                float tmp_con = 0;
                float tmp_con_stand = 0;
                float tmp_dia = 0;
                float tmp_dia_stand = 0;

                if (temp_base != "")
                {
                    string[] os_base = temp_base.Replace("+/-", "-").Split('-');
                    tmp_base = (float.Parse)(os_base[0]);
                    tmp_base_stand = (float.Parse)(os_base[1]);
                }
                if (temp_constrictedValue != "")
                {
                    string[] os_constri = temp_constrictedValue.Replace("+/-", "-").Split('-');
                    tmp_con = (float.Parse)(os_constri[0]);
                    tmp_con_stand = (float.Parse)(os_constri[1]);
                }
                if (temp_dilationValue != "")
                {
                    string[] os_dilation = temp_dilationValue.Replace("+/-", "-").Split('-');
                    tmp_dia = (float.Parse)(os_dilation[0]);
                    tmp_dia_stand = (float.Parse)(os_dilation[1]);
                }
                base_Value.Add(tmp_base);
                base_Value_stand.Add(tmp_base_stand);
                constr_Value.Add(tmp_con);
                constr_Value_stand.Add(tmp_con_stand);
                dialation_Value.Add(tmp_dia);
                dialation_Value_stand.Add(tmp_dia_stand);

                if (resultManagerA.patientResultData.velocityCalculations[i].constrictionVelocity != "")
                {
                    float temp_con_velocity = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].constrictionVelocity);
                    constrictionVelocity.Add(temp_con_velocity);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].dilationVelocity != "")
                {
                    float temp_dia_velocity = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].dilationVelocity);
                    dilationVelocity.Add(temp_dia_velocity);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].percentageChangeValue != "")
                {
                    float temp_percent = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].percentageChangeValue);
                    percentageChangeValue.Add(temp_percent);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].amplitudeConstriction != "")
                {
                    float temp_amp_con = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].amplitudeConstriction);
                    amplitudeConstriction.Add(temp_amp_con);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].amplitudeDilatation != "")
                {
                    float temp_amp_dia = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].amplitudeDilatation);
                    amplitudeDilatation.Add(temp_amp_dia);
                }

            }
            if (resultManagerA.patientResultData.velocityCalculations[i].eye == "OD")
            {
                string temp_base = resultManagerA.patientResultData.velocityCalculations[i].baseValue;
                string temp_constrictedValue = resultManagerA.patientResultData.velocityCalculations[i].constrictedValue;
                string temp_dilationValue = resultManagerA.patientResultData.velocityCalculations[i].dilationValue;

                float tmp_base = 0;
                float tmp_base_stand = 0;
                float tmp_con = 0;
                float tmp_con_stand = 0;
                float tmp_dia = 0;
                float tmp_dia_stand = 0;

                if (temp_base != "")
                {
                    string[] os_base = temp_base.Replace("+/-", "-").Split('-');
                    tmp_base = (float.Parse)(os_base[0]);
                    tmp_base_stand = (float.Parse)(os_base[1]);
                }
                if (temp_constrictedValue != "")
                {
                    string[] os_constri = temp_constrictedValue.Replace("+/-", "-").Split('-');
                    tmp_con = (float.Parse)(os_constri[0]);
                    tmp_con_stand = (float.Parse)(os_constri[1]);
                }
                if (temp_dilationValue != "")
                {
                    string[] os_dilation = temp_dilationValue.Replace("+/-", "-").Split('-');
                    tmp_dia = (float.Parse)(os_dilation[0]);
                    tmp_dia_stand = (float.Parse)(os_dilation[1]);
                }
                base_Value_od.Add(tmp_base);
                base_Value_stand_od.Add(tmp_base_stand);
                constr_Value_od.Add(tmp_con);
                constr_Value_stand_od.Add(tmp_con_stand);
                dialation_Value_od.Add(tmp_dia);
                dialation_Value_stand_od.Add(tmp_dia_stand);

                if (resultManagerA.patientResultData.velocityCalculations[i].constrictionVelocity != "")
                {
                    float temp_con_velocity = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].constrictionVelocity);
                    constrictionVelocity_od.Add(temp_con_velocity);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].dilationVelocity != "")
                {
                    float temp_dia_velocity = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].dilationVelocity);
                    dilationVelocity_od.Add(temp_dia_velocity);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].percentageChangeValue != "")
                {
                    float temp_percent = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].percentageChangeValue);
                    percentageChangeValue_od.Add(temp_percent);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].amplitudeConstriction != "")
                {
                    float temp_amp_con = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].amplitudeConstriction);
                    amplitudeConstriction_od.Add(temp_amp_con);
                }
                if (resultManagerA.patientResultData.velocityCalculations[i].amplitudeDilatation != "")
                {
                    float temp_amp_dia = (float.Parse)(resultManagerA.patientResultData.velocityCalculations[i].amplitudeDilatation);
                    amplitudeDilatation_od.Add(temp_amp_dia);
                }

            }
        }

        CalculateTheAvarageValues();
    }

    public void CalculateTheAvarageValues()
    {

        //os
        float base_os = FindAverageValue(base_Value);
        float base_stand_os = FindAverageValue(base_Value_stand);
        float con_os = FindAverageValue(constr_Value);
        float con_stand_os = FindAverageValue(constr_Value_stand);
        float dia_os = FindAverageValue(dialation_Value);
        float dia_stand_os = FindAverageValue(dialation_Value_stand);

        float con_velo_os = FindAverageValue(constrictionVelocity);
        float dia_velo_os = FindAverageValue(dilationVelocity);
        float percen_os = FindAverageValue(percentageChangeValue);
        float con_ampli_os = FindAverageValue(amplitudeConstriction);
        float dia_ampli_os = FindAverageValue(amplitudeDilatation);

        //od
        float base_od = FindAverageValue(base_Value_od);
        float base_stand_od = FindAverageValue(base_Value_stand_od);
        float con_od = FindAverageValue(constr_Value_od);
        float con_stand_od = FindAverageValue(constr_Value_stand_od);
        float dia_od = FindAverageValue(dialation_Value_od);
        float dia_stand_od = FindAverageValue(dialation_Value_stand_od);

        float con_velo_od = FindAverageValue(constrictionVelocity_od);
        float dia_velo_od = FindAverageValue(dilationVelocity_od);
        float percen_od = FindAverageValue(percentageChangeValue_od);
        float con_ampli_od = FindAverageValue(amplitudeConstriction_od);
        float dia_ampli_od = FindAverageValue(amplitudeDilatation_od);

        // latency 
        float latency_os = FindAverageValue(latency_Value_os);
        float latency_od = FindAverageValue(latency_Value_od);

        //  con_ampli_os.ToString()

        List<string> temp_smooth_dia = new List<string>();
        List<string> temp_smooth_time = new List<string>();

        for (int i = 0; i < final_Smooth_diameters.Count; i++)
        {
            string temp = final_Smooth_diameters[i].ToString();
            temp_smooth_dia.Add(temp);
        }
        for (int i = 0; i < final_Smooth_timestamps.Count; i++)
        {
            string temp = final_Smooth_timestamps[i].ToString();
            temp_smooth_time.Add(temp);
        }

        List<string> temp_smooth_dia_od = new List<string>();
        List<string> temp_smooth_time_od = new List<string>();

        for (int i = 0; i < final_Smooth_diameters_od.Count; i++)
        {
            string temp = final_Smooth_diameters_od[i].ToString();
            temp_smooth_dia_od.Add(temp);
        }
        for (int i = 0; i < final_Smooth_timestamps_od.Count; i++)
        {
            string temp = final_Smooth_timestamps_od[i].ToString();
            temp_smooth_time_od.Add(temp);
        }


        var data3 = new GraphValueCalculation("AverageValues", "LightFlashOnSequence LeftEyeResponse", "OS", "", "", latency_os.ToString(), "", "", "", "", temp_smooth_dia, temp_smooth_time, finalArry_01_diameters, finalArry_01_timestamps);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);
        var data4 = new GraphValueCalculation("AverageValues", "LightFlashOnSequence RightEyeResponse", "OD", "", "", latency_od.ToString(), "", "", "", "", temp_smooth_dia_od, temp_smooth_time_od, finalArry_01_diameters_od, finalArry_01_timestamps_od);
        resultManagerA.patientResultData.graphValueCalculation.Add(data4);

        string tempp = " +/- ";
        string base_string_os = base_os + tempp + base_stand_os;
        string con_string_os = con_os + tempp + con_stand_os;
        string dia_string_os = dia_os + tempp + dia_stand_os;

        string base_string_od = base_od + tempp + base_stand_od;
        string con_string_od = con_od + tempp + con_stand_od;
        string dia_string_od = dia_od + tempp + dia_stand_od;


        var data5 = new VelocityCalculationData("AverageValues", "LightFlashOnSequence LeftEyeResponse", "OS", base_string_os, con_string_os, dia_string_os, con_velo_os.ToString(), dia_velo_os.ToString(), percen_os.ToString(), con_ampli_os.ToString(), dia_ampli_os.ToString());
        resultManagerA.patientResultData.velocityCalculations.Add(data5);

        var data6 = new VelocityCalculationData("AverageValues", "LightFlashOnSequence RightEyeResponse", "OD", base_string_od, con_string_od, dia_string_od, con_velo_od.ToString(), dia_velo_od.ToString(), percen_od.ToString(), con_ampli_od.ToString(), dia_ampli_od.ToString());
        resultManagerA.patientResultData.velocityCalculations.Add(data6);



        temp_smooth_dia.Clear();
        temp_smooth_time.Clear();
        temp_smooth_dia_od.Clear();
        temp_smooth_time_od.Clear();
    }




    float FindAverageValue(List<float> diameters)
    {
        // float average = diameters.Count > 0 ? diameters.Average() : 0.0;
        float average;

        if (diameters.Count > 0)
        {
            average = diameters.Average();
            average = Mathf.Round(average * 100.0f) * 0.01f;
        }
        else
        {
            average = 0.0f;
        }
        //  Debug.Log("FindAverageValue :" + average);

        return average;
    }

    void ClearCombineArrayList()
    {
        finalArry_01_diameters.Clear();
        finalArry_01_timestamps.Clear();
        final_Smooth_diameters.Clear();
        final_Smooth_timestamps.Clear();

        finalArry_01_diameters_od.Clear();
        finalArry_01_timestamps_od.Clear();
        final_Smooth_diameters_od.Clear();
        final_Smooth_timestamps_od.Clear();

        latency_Value_os.Clear();
        latency_Value_od.Clear();

        //os
        base_Value.Clear();
        base_Value_stand.Clear();
        constr_Value.Clear();
        constr_Value_stand.Clear();
        dialation_Value.Clear();
        dialation_Value_stand.Clear();

        constrictionVelocity.Clear();
        dilationVelocity.Clear();
        percentageChangeValue.Clear();
        amplitudeConstriction.Clear();
        amplitudeDilatation.Clear();

        //od
        base_Value_od.Clear();
        base_Value_stand_od.Clear();
        constr_Value_od.Clear();
        constr_Value_stand_od.Clear();
        dialation_Value_od.Clear();
        dialation_Value_stand_od.Clear();

        constrictionVelocity_od.Clear();
        dilationVelocity_od.Clear();
        percentageChangeValue_od.Clear();
        amplitudeConstriction_od.Clear();
        amplitudeDilatation_od.Clear();
    }

}