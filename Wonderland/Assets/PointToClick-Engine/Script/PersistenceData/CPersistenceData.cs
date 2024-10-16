using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CPersistenceData : MonoBehaviour
{

   private static CPersistenceData _instance;
   public static CPersistenceData Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CMICILSPSystem");
                _instance = obj.AddComponent<CPersistenceData>();
                DontDestroyOnLoad(obj); 
            }
            return _instance;
        }
    }

        public CMICILSPSystem.StatTemplate CurrentStatsTemplate { get; private set; } 
    // Start is called before the first frame update
     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

   public void SetArquetipe(int i)
   {
    switch (i)
    {
        case 0:

         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.Detective);
        break;

        case 1:

         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.HeroinaDeCapaBlanca); 
         break;
           case 2:
         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.LocaPerturbada); 
         break;
         
           case 3:
         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.MonstruoSinCorazon); 
         break;
    }
       

   }
    public void SaveDataArquetipe()
    {
        CMICILSPSystem.StatTemplate statTemplate = null;
        statTemplate = CMICILSPSystem.Instance.GetStatTemplate();   
        CMICILSPSystem.Instance.PrintStats(statTemplate);   
    }
}
