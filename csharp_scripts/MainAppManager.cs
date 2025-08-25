using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MainAppManager : MonoBehaviour
{
    public FixedIntensityProtocolManager fixedIntensityProtocolManager;
    public VariableIntensityProtocolManager variableIntensityProtocolManager;
    public PIPRMonocolar pIPRMonocolar;
    public ExtendedPIPRMonocular extendedPIPRMonocular;
    public DiameterSmoothingManger diameterSmoothingManger;

    public ResultConvertJsonObj resultConvertJsonObj;


    public enum EyeProtocolType
    {
        FixedIntensity_Bino,
        VariableIntensity_Bino,
        QuickTest_Bino,
        ExtendedPIPR_Bino,
        PIPR_Mono,
        ExtendedPIPR_Mono
    }

    public EyeProtocolType currentProtocol;

    // Start is called before the first frame update
    void Start()
    {
       // currentProtocol = EyeProtocolType.FixedIntensity_Bino;
       // Invoke("GetProtocolData", 1f);

    }


    public void GetProtocolData()
    {
        switch (currentProtocol)
        {
            case EyeProtocolType.ExtendedPIPR_Bino:

                break;
            case EyeProtocolType.FixedIntensity_Bino:

                 fixedIntensityProtocolManager.FixedIntensityTestBinocular();
            //    resultConvertJsonObj.ShowPupilXResult();

                 // pIPRMonocolar.PIPRMonocularTest();
                 // variableIntensityProtocolManager.VariableIntensityTestBinocular();

                break;
            case EyeProtocolType.QuickTest_Bino:
              
                break;
            case EyeProtocolType.VariableIntensity_Bino:

                variableIntensityProtocolManager.VariableIntensityTestBinocular();

                break;
            case EyeProtocolType.PIPR_Mono:
                pIPRMonocolar.PIPRMonocularTest();
                break;
            case EyeProtocolType.ExtendedPIPR_Mono:
                extendedPIPRMonocular.ExtendedPIPRMonocularTest();

                break;

        }
    }

}
