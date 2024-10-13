using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plataform2D;
public class CSwitch : MonoBehaviour
{
    // Start is called before the first frame update


   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CGameManager.Inst.LoadSceneAsync("scene1");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CGameManager.Inst.LoadSceneAsync("scene2");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CGameManager.Inst.LoadSceneAsyncAdditive("scene3");
        }
    }
    public void SwitchScene(string name)
    {
        CGameManager.Inst.LoadSceneAsync(name);
    }
    
}
