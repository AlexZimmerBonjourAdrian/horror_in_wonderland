using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Compiler;
using Yarn.Unity;
using Yarn.Unity.Example;
using UnityEngine.TextCore.Text;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class CAnimaticController : MonoBehaviour
{   
    
    
    [SerializeField]private List<CAnimaticData> animaticData_List;

    //Code to planning Manager Dialogs
  
    private CAnimaticData ActualAnimatic;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space) && CEngineManager.Inst.GetIsDebug())
        {
            StartAnimatic();
            NextAnimatic();
        }


    }
    public void StartAnimatic()
    {
        if(ActualAnimatic == null)
        {   
           if(!CManagerDialogue.Inst.GetIsDialogueRunning())
            {
                CManagerDialogue.Inst.SetListYarn(0);
                CManagerDialogue.Inst.StartDialogueRunner();
            }
            
            spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,1);

            ActualAnimatic = animaticData_List[0];
           
            spriteRenderer.sprite = ActualAnimatic._Animatic;     
        }
        else
        {
            spriteRenderer.sprite = ActualAnimatic._Animatic;
        }
    }


    private CAnimaticData NextAnimatic()
    {
        //return  ActualAnimatic._NextAnimatic != null ? ActualAnimatic = ActualAnimatic._NextAnimatic : EndAnimatic();
        if (ActualAnimatic._NextAnimatic != null) 
        {
            ActualAnimatic = ActualAnimatic._NextAnimatic;
        }
        else 
        {
            ActualAnimatic = animaticData_List[0]; // Reinicia al llegar al final
        }
        return ActualAnimatic;
    }
    



    // private  CAnimaticData EndAnimatic()
    // {
    //     spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0);
    //     return null;
    // }



}   
   
