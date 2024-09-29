using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEngineManager : MonoBehaviour
{
     [SerializeField] protected bool IsDebug = true;
     public static CEngineManager Inst_Engine
    {
        get
        {
            if (_inst_Engine == null)
            {
                GameObject obj = new GameObject("EngineManager");
                return obj.AddComponent<CEngineManager>();
            }
            return _inst_Engine;

        }
    }
    private static CEngineManager _inst_Engine;

    
    public bool GetIsDebug()
    {
        return IsDebug;
    }

   
}
