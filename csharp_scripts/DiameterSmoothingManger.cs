using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
using System;

public class DiameterSmoothingManger : MonoBehaviour
{
    public SimpleMovingAverage simpleMovingAverage;
    public CalculationManager calculationManager;


    // All Arrays Here 


    public List<float> Array_01 = new List<float>();
    public List<float> Array_01_Timestamps_first = new List<float>();


    [SerializeField]
    List<float> Array_01_removed_zero = new List<float>();
    [SerializeField]
    List<float> Array_01_TimeStamps = new List<float>();

    [SerializeField]
    List<float> Array_02 = new List<float>();
    [SerializeField]
    List<float> Array_02_TimeStamps = new List<float>();


    // values ================

    float LatencyValuea;


    //strings..............

    public string LatencyValue;

    public string amplitudeof_constrictionVal;
    public string amplitudeof_DilationVal;
    public string baseLine_Val;
    public string constriction_Amount;

    public string velocity_of_Constriction;
    public string velocity_of_Dilation;

    public List<string> Array_Instantaneousvelocity = new List<string>();
    public List<string> Array_Instantaneousvelocity_Timestamps = new List<string>();


    List<float> RemovingHighValue = new List<float>();
    List<float> RemovingHighValue_timestamp = new List<float>();



    private void Start()
    {

    }


    public void CalculateMovingAverage(List<float> diameters, List<float> timeStamps, int loop_count)
    {
        ClearAllList();

        // RemoveZerosFromList(Array_01, timeStamps);
        RemoveZerosFromList(diameters, timeStamps, loop_count);
    }

    void RemoveZerosFromList(List<float> diameters, List<float> timeStamps, int loop_count)
    {
        if (diameters.Count > 0)
        {
            for (int i = 0; i < timeStamps.Count; i++)
            {
                if (diameters[i] != 0)
                {
                    Array_01_removed_zero.Add(diameters[i]);
                    Array_01_TimeStamps.Add(timeStamps[i]);
                }
                else
                {
                    // diameters.Remove(diameters[i]);//array1
                }
            }


            // not consider above 10 value    
            for (int i = 0; i < Array_01_TimeStamps.Count; i++)
            {
                if (Array_01_removed_zero[i] <= 10)
                {
                    RemovingHighValue.Add(Array_01_removed_zero[i]);
                    RemovingHighValue_timestamp.Add(Array_01_TimeStamps[i]);
                }
                else
                {
                    // diameters.Remove(diameters[i]);//array1
                }
            }


            if (Array_01_removed_zero.Count > 0 && Array_01_removed_zero.Count == Array_01_TimeStamps.Count)
            {
                // List<float> temp = simpleMovingAverage.CalculateMovingAverage(diameters);

                simpleMovingAverage.NewPchipp3(Array_01_TimeStamps, Array_01_removed_zero);

                List<double> temp = simpleMovingAverage.interpolatedValues.ToList();
                List<double> tempTime = simpleMovingAverage.newX.ToList();


                for (int i = 0; i < temp.Count; i++)
                {
                    Array_01.Add((float)temp[i]);
                }


                //  Array_01_Timestamps_first = new List<float>(timeStamps);

                for (int i = 0; i < tempTime.Count; i++)
                {
                    Array_01_Timestamps_first.Add((float)tempTime[i]);
                }
            }

            CalculateMovingDifference(Array_01, Array_01_Timestamps_first, loop_count);

        }

    }

    void CalculateMovingDifference(List<float> arryList, List<float> timeStamps, int loop_count)
    {
        //Doing Moving difference and removing the last value from array as it not useful
        if (arryList.Count > 0)
        {
            for (int i = 0; i < arryList.Count - 1; i++)
            {
                Array_02.Add(arryList[i + 1] - arryList[i]);
                Array_02_TimeStamps.Add(timeStamps[i]);
            }
        }

        CalculateLatency(loop_count);
        Instantaneousvelocity();
    }

    void Instantaneousvelocity()
    {
        // Calculate Array_Instantaneousvelocity------------------------------------------------------------------------
        if (Array_02.Count > 0)
        {
            for (int i = 0; i < Array_02.Count; i++)
            {
                float temp_newTimestamp = Array_02_TimeStamps[1] - Array_02_TimeStamps[0];
                float temp04 = (Array_02[i] / temp_newTimestamp);
                float temp05 = temp04 * 1000f;
                Array_Instantaneousvelocity.Add(temp05.ToString());
                Array_Instantaneousvelocity_Timestamps.Add(Array_02_TimeStamps[i].ToString());
            }
        }
    }


    // Calculate Latency ........................
    void CalculateLatency(int loop_Count)
    {

        if (loop_Count == 6)
        {
            #region Temp Splution 
            //temp solution needs change later................................

            float BaseValue = 0;
            double Base_Standard_Value = 0;

            List<float> temp_base = new List<float>();
            for (int i = 0; i < Array_01_Timestamps_first.Count; i++)
            {
                if (Array_01_Timestamps_first[i] > 0f && Array_01_Timestamps_first[i] <= 6000f)
                {
                    temp_base.Add(Array_01[i]);

                }

            }

            if (temp_base.Count > 0)
            {
                BaseValue = FindAverageValue(temp_base);
                Base_Standard_Value = FindStandardDeviation(temp_base);
            }

            double temp_baseVlue = BaseValue - (2 * Base_Standard_Value);

            float temp3 = 0;

            if (Array_01_Timestamps_first.Count > 0)
            {
                for (int i = 0; i < Array_01_Timestamps_first.Count; i++)
                {
                    if (loop_Count == 6)
                    {


                        if (Array_01_Timestamps_first[i] > 6000f)
                        {
                            if (Array_01[i] < temp_baseVlue)
                            {
                                temp3 = Array_01_Timestamps_first[i];
                                break;
                            }



                        }
                    }

                }


                LatencyValuea = temp3 - 6000f;
                LatencyValuea = LatencyValuea / 1000f;
                 LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                if (LatencyValuea != 0)
                {
                    LatencyValue = LatencyValuea.ToString();
                }
                else
                {
                    LatencyValue = "0";
                }
            }

            #endregion
            /////////////////////////////////////////////////
            ///
        }
        if (loop_Count == 8)
        {
            #region Temp Splution 
            //temp solution needs change later................................

            float BaseValue = 0;
            double Base_Standard_Value = 0;

            List<float> temp_base = new List<float>();
            for (int i = 0; i < Array_01_Timestamps_first.Count; i++)
            {
                if (Array_01_Timestamps_first[i] > 0f && Array_01_Timestamps_first[i] <= 6000f)
                {
                    temp_base.Add(Array_01[i]);

                }

            }

            if (temp_base.Count > 0)
            {
                BaseValue = FindAverageValue(temp_base);
                Base_Standard_Value = FindStandardDeviation(temp_base);
            }

            double temp_baseVlue = BaseValue - (2 * Base_Standard_Value);

            float temp3 = 0;

            if (Array_01_Timestamps_first.Count > 0)
            {
                for (int i = 0; i < Array_01_Timestamps_first.Count; i++)
                {
                    if (loop_Count == 8)
                    {


                        if (Array_01_Timestamps_first[i] > 6000f)
                        {
                            if (Array_01[i] < temp_baseVlue)
                            {
                                temp3 = Array_01_Timestamps_first[i];
                                break;
                            }



                        }
                    }

                }


                LatencyValuea = temp3 - 6000f;
               // LatencyValuea = LatencyValuea / 1000f;
                LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                if (LatencyValuea != 0)
                {
                    LatencyValue = LatencyValuea.ToString();
                }
                else
                {
                    LatencyValue = "0";
                }
            }

            #endregion
            /////////////////////////////////////////////////
            ///
        }

        if (Array_02_TimeStamps.Count > 0)
        {
            for (int i = 0; i < Array_02_TimeStamps.Count; i++)
            {
                if (loop_Count == 1)
                {
                    if (Array_02_TimeStamps[i] > 5000f)
                    {
                        LatencyValuea = Array_02_TimeStamps[i] - 5000f;
                        LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                        if (LatencyValuea != 0)
                        {
                            LatencyValue = LatencyValuea.ToString();
                        }
                        else
                        {
                            LatencyValue = "0";
                        }
                        break;
                    }
                }

                if (loop_Count == 2)
                {
                    if (Array_02_TimeStamps[i] > 0f)
                    {
                        LatencyValuea = Array_02_TimeStamps[i];
                        LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                        if (LatencyValuea != 0)
                        {
                            LatencyValue = LatencyValuea.ToString();
                        }
                        else
                        {
                            LatencyValue = "0";
                        }
                        break;
                    }
                }
                if (loop_Count == 3)
                {
                    if (Array_02_TimeStamps[i] > 10000f)
                    {
                        LatencyValuea = Array_02_TimeStamps[i];
                        LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                        if (LatencyValuea != 0)
                        {
                            LatencyValue = LatencyValuea.ToString();
                        }
                        else
                        {
                            LatencyValue = "0";
                        }
                        break;
                    }
                }
                if (loop_Count == 4)
                {
                    if (Array_02_TimeStamps[i] > 12000f)
                    {
                        LatencyValuea = Array_02_TimeStamps[i];
                        LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                        if (LatencyValuea != 0)
                        {
                            LatencyValue = LatencyValuea.ToString();
                        }
                        else
                        {
                            LatencyValue = "0";
                        }
                        break;
                    }
                }
                if (loop_Count == 5)
                {
                    if (Array_02_TimeStamps[i] > 19000f)
                    {
                        LatencyValuea = Array_02_TimeStamps[i];
                        LatencyValuea = Mathf.Round(LatencyValuea * 100.0f) * 0.01f;
                        if (LatencyValuea != 0)
                        {
                            LatencyValue = LatencyValuea.ToString();
                        }
                        else
                        {
                            LatencyValue = "0";
                        }
                        break;
                    }
                }
            }
        }

    }
    void ClearAllList()
    {
        Array_01.Clear();
        Array_01_Timestamps_first.Clear();

        Array_01_removed_zero.Clear();
        Array_01_TimeStamps.Clear();

        Array_02.Clear();
        Array_02_TimeStamps.Clear();

        Array_Instantaneousvelocity.Clear();
        Array_Instantaneousvelocity_Timestamps.Clear();

        RemovingHighValue_timestamp.Clear();
        RemovingHighValue.Clear();

        LatencyValuea = 0f;
        LatencyValue = "";

        
        amplitudeof_constrictionVal = "";
        amplitudeof_DilationVal = "";
        baseLine_Val = "";
        constriction_Amount = "";
        velocity_of_Constriction = "";
        velocity_of_Dilation = "";

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
