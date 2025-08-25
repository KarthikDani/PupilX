using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIPRMonocolar : MonoBehaviour
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

    public void PIPRMonocularTest()
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


       // GetBaseDiameters();

        LowVariableIntensity();

    }



    void GetBaseDiameters()
    {
        for (int j = 0; j < timeStampValues_Low.Count; j++)
        {

            //OS Base Value for low and meduim, High here...........

            if (timeStampValues_Low[j] >= 0 && timeStampValues_Low[j] <= 5000)
            {
                F5secDiameters_os.Add(osDiameters_low[j]);
                F5secDiameters_od.Add(oDDiameters_low[j]);
                F5secDiameters_Timestamps.Add(timeStampValues_Low[j]);
            }
        }
    }

    void LowVariableIntensity()
    {
        //OS  Table Creating =============================================
        // Algorithm V3 OS Values Add Values--------------------
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_low, timeStampValues_Low, 1);
        var data2 = new GraphValueCalculation(low, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            //OS Base Value for low and meduim, High here...........

            if (ostimeStampValues_smooth[j] >= 0 && ostimeStampValues_smooth[j] <= 5000)
            {
                leftbaseValue.Add(osDiameters_Smooth[j]);
                baseValueTimestamp.Add(ostimeStampValues_smooth[j]);
            }

            ///////////////////////////////////////////

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
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_low, timeStampValues_Low, 1);
        var data3 = new GraphValueCalculation(low, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            //OD Base Value for low and meduim, High here...........
            if (odtimeStampValues__smooth[j] >= 0 && odtimeStampValues__smooth[j] <= 5000)
            {
                rightbaseValue.Add(oDDiameters_Smooth[j]);
                Right_baseValueTimestamp.Add(odtimeStampValues__smooth[j]);
            }
            /////////////////////////////////

            if (odtimeStampValues__smooth[j] > 5000 && odtimeStampValues__smooth[j] <= 6000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 6000 && odtimeStampValues__smooth[j] <= 12000)
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
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_Medium, timeStampValues_Medium, 2);
        var data2 = new GraphValueCalculation(medium, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            if (ostimeStampValues_smooth[j] >= 0 && ostimeStampValues_smooth[j] <= 1000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 1000 && ostimeStampValues_smooth[j] <= 7000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }

        }

        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_Medium, timeStampValues_Medium, 2);
        var data3 = new GraphValueCalculation(medium, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] >= 0 && odtimeStampValues__smooth[j] <= 1000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 1000 && odtimeStampValues__smooth[j] <= 7000)
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
        diameterSmoothingManger.CalculateMovingAverage(osDiameters_High, timeStampValues_High, 2);
        var data2 = new GraphValueCalculation(high, "LightFlashOnSequence LeftEyeResponse", "OS", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data2);

        osDiameters_Smooth = diameterSmoothingManger.Array_01;
        ostimeStampValues_smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < ostimeStampValues_smooth.Count; j++)
        {

            if (ostimeStampValues_smooth[j] >= 0 && ostimeStampValues_smooth[j] <= 1000)
            {
                leftConstrictedValue.Add(osDiameters_Smooth[j]);
                leftConstrictedTimestamp.Add(ostimeStampValues_smooth[j]);

            }
            if (ostimeStampValues_smooth[j] > 1000 && ostimeStampValues_smooth[j] <= 7000)
            {
                leftDilationValue.Add(osDiameters_Smooth[j]);
                leftDilationTimestamp.Add(ostimeStampValues_smooth[j]);

            }

        }


        //OD  Table Creating =============================================

        // Algorithm V3 OD Values Add --------------------
        diameterSmoothingManger.CalculateMovingAverage(oDDiameters_High, timeStampValues_High, 2);
        var data3 = new GraphValueCalculation(high, "LightFlashOnSequence RightEyeResponse", "OD", diameterSmoothingManger.amplitudeof_constrictionVal, diameterSmoothingManger.amplitudeof_DilationVal, diameterSmoothingManger.LatencyValue, diameterSmoothingManger.baseLine_Val, diameterSmoothingManger.constriction_Amount, diameterSmoothingManger.velocity_of_Constriction, diameterSmoothingManger.velocity_of_Dilation, diameterSmoothingManger.Array_Instantaneousvelocity, diameterSmoothingManger.Array_Instantaneousvelocity_Timestamps, diameterSmoothingManger.Array_01, diameterSmoothingManger.Array_01_Timestamps_first);
        resultManagerA.patientResultData.graphValueCalculation.Add(data3);

        oDDiameters_Smooth = diameterSmoothingManger.Array_01;
        odtimeStampValues__smooth = diameterSmoothingManger.Array_01_Timestamps_first;

        for (int j = 0; j < odtimeStampValues__smooth.Count; j++)
        {
            if (odtimeStampValues__smooth[j] >= 0 && odtimeStampValues__smooth[j] <= 1000)
            {
                rightConstrictedValue.Add(oDDiameters_Smooth[j]);
                rightConstrictedTimeStamp.Add(odtimeStampValues__smooth[j]);

            }
            if (odtimeStampValues__smooth[j] > 1000 && odtimeStampValues__smooth[j] <= 7000)
            {
                rightDilationValue.Add(oDDiameters_Smooth[j]);
                rightDilationTimestamp.Add(odtimeStampValues__smooth[j]);

            }

        }

        // Caluculation Start Here----------------

        calculationManager.CalucationVelocityValue(leftbaseValue, leftConstrictedValue, leftDilationValue, baseValueTimestamp, leftConstrictedTimestamp, leftDilationTimestamp);
        var data = new VelocityCalculationData(high, "LightFlashOnSequence LeftEyeResponse", "OS", calculationManager.baseValue, calculationManager.constrictedValue, calculationManager.dilationValue, calculationManager.constricted_Velocity_Value, calculationManager.dilation_velocity_Value, calculationManager.percentage_Change_Value,calculationManager.Amplitude_Constriction,calculationManager.Amplitude_Dilation);
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
}
