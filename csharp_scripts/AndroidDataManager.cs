using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;


public class AndroidDataManager : MonoBehaviour
{
    //old stucture of data
    public PatientTestDataList patientTestDataList;

    public ShowResult showResult;

    // Start is called before the first frame update
    void Start()
    {
       // GetTopicData1();
    }

    public void GetTopicData1()
    {
        TextAsset textFile = Resources.Load("MonocularEmergencyJson_OU") as TextAsset;
        // TextAsset textFile = Resources.Load("fixedintensity") as TextAsset;
        string temp = textFile.text;
       // GetTopicData(temp);
        showResult.ShowPupilXResult(temp);

    }
    public void GetTopicData(string data)
    {
        // Debug.Log(data);
       // PatientTestDataList cmtData = JsonUtility.FromJson<PatientTestDataList>(data);
        PatientTestDataList Data = JsonConvert.DeserializeObject<PatientTestDataList>(data);
        patientTestDataList.patientDataManagerList = Data.patientDataManagerList;
    }
}
