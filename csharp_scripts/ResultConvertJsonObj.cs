using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResultConvertJsonObj : MonoBehaviour
{
    public FixedIntensityProtocolManager fixedIntensityProtocolManager;


    // Create a field for the save file.
    string saveFile;
    string saveCsv;

    // Start is called before the first frame update
    void Start()
    {
        // Update the path once the persistent path exists.
        //  saveFile = Application.persistentDataPath + "/gamedata.json";
        saveFile = Application.dataPath + "/Final_Emr.txt";
        saveCsv = Application.dataPath + "/Emergency.csv";


    }
    public void ShowPupilXResult()
    {
        string jsonString = JsonConvert.SerializeObject(fixedIntensityProtocolManager.resultManagerA.patientResultData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);



   //     WriteCSVFile();
        
    }

    List<float> bluelight_diameters = new List<float>();
    List<float> bluelight_timstamps = new List<float>();
    List<float> redlight_diameters = new List<float>();
    List<float> redlight_timestamps = new List<float>();
    List<float> whitelight_diameters = new List<float>();
    List<float> whitelight_timestamps = new List<float>();

    void ClearAllTempLists()
    {
        bluelight_diameters.Clear();
        bluelight_timstamps.Clear();
        redlight_diameters.Clear();
        redlight_timestamps.Clear();
        whitelight_diameters.Clear();
        whitelight_timestamps.Clear();

    }

    public void WriteCSVFile()
    {
        ClearAllTempLists();

        if (fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculationNew[0].SmoothDiameters.Count > 0)
        {

            //for (int i = 0; i < fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[9].smoothTimeStamps.Count; i++)
            //{
            //    bluelight_diameters.Add((float.Parse)(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[8].smoothDiameters[i]));
            //    bluelight_timstamps.Add((float.Parse)(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[9].smoothTimeStamps[i]));

            //}
            if(fixedIntensityProtocolManager.androidDataManager.patientTestDataList.patientDataManagerList[0].mainTitle== "Emergency Care Protocol (Monocular)")
            {
                
            }
            for (int i = 0; i < fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculationNew[0].SmoothTimeStamps.Count; i++)
            {
                bluelight_diameters.Add((fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculationNew[0].SmoothDiameters[i]));
                bluelight_timstamps.Add((fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculationNew[0].SmoothTimeStamps[i]));

            }

            //for (int i = 0; i < fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[2].Array01TimeStamps.Count; i++)
            //{
            //    redlight_diameters.Add(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[2].Array01Diameters[i]);
            //    redlight_timestamps.Add(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[2].Array01TimeStamps[i]);

            //}
            //for (int i = 0; i < fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[4].Array01TimeStamps.Count; i++)
            //{
            //    whitelight_diameters.Add(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[4].Array01Diameters[i]);
            //    whitelight_timestamps.Add(fixedIntensityProtocolManager.resultManagerA.patientResultData.graphValueCalculation[4].Array01TimeStamps[i]);

            //}

            SaveListsToCSV(bluelight_timstamps,bluelight_diameters, redlight_timestamps, redlight_diameters, whitelight_timestamps, whitelight_diameters, saveCsv);

        }

    }

    private void SaveListsToCSV(List<float> list1, List<float> list2, List<float> list3, List<float> list4, List<float> list5, List<float> list6, string filePath)
    {
        // Determine the maximum count among the lists
        int maxCount = Mathf.Max(list1.Count, list2.Count, list3.Count, list4.Count, list5.Count, list6.Count);

        StreamWriter sw = new StreamWriter(filePath);

        // Write the , list3.Count
        sw.WriteLine("Blue TimeStamps,Blue Diameters,Red TimeStamps,Red Diameters,White TimeStamps,White Diameters");

        // Iterate over the lists using the maximum count
        for (int i = 0; i < maxCount; i++)
        {
            // Assign default values or leave blank for missing values
            string data1 = i < list1.Count ? list1[i].ToString() : "";
            string data2 = i < list2.Count ? list2[i].ToString() : "";
            string data3 = i < list3.Count ? list3[i].ToString() : "";
            string data4 = i < list4.Count ? list4[i].ToString() : "";
            string data5 = i < list5.Count ? list5[i].ToString() : "";
            string data6 = i < list6.Count ? list6[i].ToString() : "";

            // Write the data to the CSV file
            sw.WriteLine(data1 + "," + data2 + "," + data3 + "," + data4 + "," + data5 + "," + data6);
        }

        sw.Close();
    }




    public void WriteCSVFile1()
    {
        if (fixedIntensityProtocolManager.osDiameters.Count > 0)
        {
            TextWriter tw = new StreamWriter(saveCsv, false);
            tw.WriteLine("Raw Diameters,Raw Timestamps");
            tw.Close();

            tw = new StreamWriter(saveCsv, true);

            for (int i = 0; i < fixedIntensityProtocolManager.osDiameters.Count; i++)
            {
                tw.WriteLine(fixedIntensityProtocolManager.osDiameters[i] + "," + fixedIntensityProtocolManager.timeStampValues[i]);
            }

            tw.Close();
        }

    }
}
