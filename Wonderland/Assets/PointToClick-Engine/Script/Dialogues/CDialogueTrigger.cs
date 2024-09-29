using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Event;

public class CDialogueTrigger :  CGameEventListener
{
    public string dialogueStartNode;
    
    // public YarnProject specificYarnProject; // If you need to switch projects

    // public override void OnEventRaise()
    // {
    //     CGameManager.Inst.StartDialogue(dialogueStartNode, specificYarnProject);
    // }
}
