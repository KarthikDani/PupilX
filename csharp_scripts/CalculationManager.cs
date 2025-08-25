using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CalculationManager : MonoBehaviour
{


    public string baseValue;
    public string constrictedValue;
    public string dilationValue;
    public string constricted_Velocity_Value;
    public string dilation_velocity_Value;
    public string percentage_Change_Value;
    public string Amplitude_Constriction;
    public string Amplitude_Dilation;


    //  float SmallestConstrictedValue;
    //  float largeDilationValue;
    //  float ConstrictedVelocity;
    //  float DilationVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ClearAllVariables()
    {
        baseValue = "";
        constrictedValue = "";
        dilationValue = "";
        constricted_Velocity_Value = "";
        dilation_velocity_Value = "";

        percentage_Change_Value = "";
        Amplitude_Constriction = "";
        Amplitude_Dilation = "";
    }



    public void CalucationVelocityValue(List<float> baseList, List<float> constrictedList, List<float> dilationList, List<float> timeStamp_BaseList, List<float> timeStamp_ConstrictedList, List<float> timeStamp_DilationList)
    {

        // first clear all variables here 
        ClearAllVariables();


        float BaseValue = 0;
        double Base_Standard_Value = 0;
        if (baseList.Count > 0)
        {
            BaseValue = FindAverageValue(baseList);
            Base_Standard_Value = FindStandardDeviation(baseList);
        }

        float ConstrictedValue = 0;
        double Constricted_Standard_Value = 0;
        if (constrictedList.Count > 0)
        {
            // ConstrictedValue = FindAverageValue(constrictedList);
            Constricted_Standard_Value = FindStandardDeviation(constrictedList);
        }

        float DilationValue = 0;
        double Dilation_Standard_Value = 0;
        if (dilationList.Count > 0)
        {
            // DilationValue = FindAverageValue(dilationList);
            Dilation_Standard_Value = FindStandardDeviation(dilationList);
        }


        string temp = " +/- ";

        if (baseList.Count > 0 && constrictedList.Count > 0 && dilationList.Count > 0)
        {
            //Constrion velocity Value Start here............
            float lastBaseValue_TimeStamp = timeStamp_BaseList[timeStamp_BaseList.Count - 1];

            float SmallestConstrictedValue = constrictedList.Where(x => x != 0).DefaultIfEmpty().Min();
            int SmallestConstrictedValue_index = constrictedList.IndexOf(SmallestConstrictedValue);
            float SmallestConstrictedValue_Timestamp = timeStamp_ConstrictedList[SmallestConstrictedValue_index];


            float Temp_con = Mathf.Round(SmallestConstrictedValue * 1000.0f) * 0.001f;
            ConstrictedValue = Temp_con;


            //Dilation velocity Value Start here............
            float largeDilationValue = dilationList.Where(x => x != 0).DefaultIfEmpty().Max();
            int largeDilationValue_index = dilationList.IndexOf(largeDilationValue);
            float largeDilationValue_Timestamp = timeStamp_DilationList[largeDilationValue_index];

            float Temp_dila = Mathf.Round(largeDilationValue * 1000.0f) * 0.001f;
            DilationValue = Temp_dila;

            //Amplitude Constriction Value
            float temp2 = (BaseValue - ConstrictedValue);

            float Temp_A_Con = Mathf.Round(temp2 * 1000.0f) * 0.001f;
            Amplitude_Constriction = Temp_A_Con.ToString();

            float temp3 = (lastBaseValue_TimeStamp - SmallestConstrictedValue_Timestamp);

            temp3 = temp3 / 1000;

            float ConstrictedVelocity = temp2 / temp3;

            float newTemp1 = Mathf.Round(ConstrictedVelocity * 1000.0f) * 0.001f;

             ConstrictedVelocity = newTemp1;


            //Amplitude Dialation Value
            float temp5 = (SmallestConstrictedValue - largeDilationValue);

            float Temp_A_Dila = Mathf.Round(temp5 * 1000.0f) * 0.001f;
            Amplitude_Dilation = Temp_A_Dila.ToString();

            float temp4 = (SmallestConstrictedValue_Timestamp - largeDilationValue_Timestamp);

            temp4 = temp4 / 1000;

            float DilationVelocity = temp5 / temp4;

               DilationVelocity = Mathf.Round(DilationVelocity * 1000.0f) * 0.001f;


            if (ConstrictedVelocity != 0)
            {

            }
            else
            {
                ConstrictedVelocity = 0;
            }
            if (DilationVelocity != 0)
            {

            }
            else
            {
                DilationVelocity = 0;
            }

            baseValue = BaseValue + temp + Base_Standard_Value;
            constrictedValue = ConstrictedValue + temp + Constricted_Standard_Value;
            dilationValue = DilationValue + temp + Dilation_Standard_Value;
            constricted_Velocity_Value = "" + ConstrictedVelocity;
            dilation_velocity_Value = "" + DilationVelocity;

        }

        // neww percentage Change Value............................

        float Temp = (BaseValue - ConstrictedValue) / BaseValue;

        float newTemp = Temp * 100;

        float temp_percen =  Mathf.Round(newTemp * 1000.0f) * 0.001f;

        percentage_Change_Value = "" + temp_percen;

    }


    public float FindAverageValue(List<float> diameters)
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
    public double FindStandardDeviation(List<float> diameters)
    {
        double average;
        if (diameters.Count > 0)
        {
            double avg = diameters.Average();

            // Perform the Sum of (value-avg)_2_2.      
            double sum = diameters.Sum(d => Math.Pow(d - avg, 2));

            // Put it all together.      
            average = Math.Sqrt((sum) / (diameters.Count() - 1));

            average = Math.Round(average, 3, MidpointRounding.AwayFromZero);
            //  Debug.Log("avarage stand =" + average);
        }
        else
        {
            average = 0.0f;
        }

        //   Debug.Log("FindStandardDeviation_v2 :" + average);
        return average;


    }
}

