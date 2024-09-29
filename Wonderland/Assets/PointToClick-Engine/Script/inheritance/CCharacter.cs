using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
//[SerializeField]
public class CCharacter : MonoBehaviour, Iinteract
{
    [SerializeField]
    protected Animator anim;
    //private bool isActiveAnim = false;

    [SerializeField]protected CGameEventScriptable OnPlayAnimatic;

    [SerializeField]
    protected  int id;


    [SerializeField]
    protected string CharacterName;

    [SerializeField] private List<string> barkNodes;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        
        
    }

    // Update is called once per frame
    public virtual void Oninteract()
    {   
      CManagerSFX.Inst.PlaySound(0);
//      CCameraManager.Inst.GetCamera1().gameObject.SetActive(true);
        if(OnPlayAnimatic!= null)
         OnPlayAnimatic.Raize();


      if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {
          CManagerDialogue.Inst.SetListYarn(id);
          CManagerDialogue.Inst.StartDialogueRunner();
      }
    }

    public virtual int GetIDCharacter()
    {
        return id;
    }

  // Nombres de los nodos de bark en Yarn Spinner

    public void PlayRandomBark()
    {
        if (barkNodes.Count == 0) return;

        int randomIndex = Random.Range(0, barkNodes.Count);
        string barkNode = barkNodes[randomIndex];

        CManagerDialogue.Inst.StartDialogueRunner(barkNode);
    }

    


}
