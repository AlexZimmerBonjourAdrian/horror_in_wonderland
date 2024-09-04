using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour, Iinteract
{
    public Transform puzzleCameraTarget; // Arrastra el objeto puzzle aquí en el inspector
    
    public void Oninteract()
    {
       CGameManager.Inst.LearpCameraToPuzzle(puzzleCameraTarget);
    }
   
            
    
}
