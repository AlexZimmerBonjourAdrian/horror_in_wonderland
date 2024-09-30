using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevelDialogue : CLevelGeneric
{
   void Start()
   {
    
    //Testing With Loop Dialogue, succesfull
    //  if(!CManagerDialogue.Inst.GetIsDialogueRunning())
    //   {
        
    //       CManagerDialogue.Inst.SetListYarn(0);
    //       CManagerDialogue.Inst.StartDialogueRunner();
    //   }
       //Testing With Loop Dialogue, funciona

      if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {
        
          CManagerDialogue.Inst.SetListYarn(1);
          CManagerDialogue.Inst.StartDialogueRunner();
      }



   }
}
