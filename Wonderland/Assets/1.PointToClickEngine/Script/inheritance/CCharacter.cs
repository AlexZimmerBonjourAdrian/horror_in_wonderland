using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
//[SerializeField]
public class CCharacter : MonoBehaviour, Iinteract
{
    private Animator anim;
    private bool isActiveAnim = false;

   
    public  int id;
    
    public Transform puzzleCameraTarget; 

    [SerializeField]
    private string CharacterName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        
        
    }

    // Update is called once per frame
    public void Oninteract()
    {   
      CManagerSFX.Inst.PlaySound(0);
      CCameraManager.Inst.GetCamera1().gameObject.SetActive(true);

      if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {
          CManagerDialogue.Inst.SetListYarn(id);
          CManagerDialogue.Inst.StartDialogueRunner();
      }
    }

    public void SetupCamera1(Transform target)
    {
        CCameraManager.Inst.camera1.transform.position = target.position;
        CCameraManager.Inst.camera1.transform.rotation = target.rotation;
    }

    public int GetIDCharacter()
    {
        return id;
    }

    // private void ChangeAnimation()
    // {
    //     isActiveAnim = !isActiveAnim;
    //     anim.SetBool("IsActive", isActiveAnim);
    // }


}
