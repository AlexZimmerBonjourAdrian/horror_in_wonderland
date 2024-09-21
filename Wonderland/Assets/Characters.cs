using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Characters : MonoBehaviour, Iinteract
{

public Transform puzzleCameraTarget;
    public void Oninteract()
    {
         CGameManager.Inst.LearpCameraToPuzzle(puzzleCameraTarget);
    }
}
