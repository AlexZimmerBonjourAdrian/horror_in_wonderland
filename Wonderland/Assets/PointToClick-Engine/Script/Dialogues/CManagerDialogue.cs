using UnityEngine;
using System.Collections.Generic;
using Yarn.Unity;

public class CManagerDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
   
    [SerializeField]
    private  InMemoryVariableStorage varibleStorage;

    public CKeywordHandler keywordHandler;
    public static CManagerDialogue Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("ManagerDialogue");
                return obj.AddComponent<CManagerDialogue>();
            }
            return _inst;

        }
    }
    private static CManagerDialogue _inst;

     public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;

        dialogueRunner = GameObject.FindAnyObjectByType<DialogueRunner>();
        varibleStorage = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
    }
   
    
    [SerializeField]
    private List<YarnProject> ListYarnProyect;

    [SerializeField]
    private YarnProject ActualYarn;

    public void SetYarnProject(YarnProject Dialogs)
    {
        dialogueRunner.SetProject(Dialogs);
    }
    
    public YarnProject GetYarnProject()
    {
        return dialogueRunner.GetYarnProject();
    }
    public void SetListYarn(int IndexYarn)
    {
        ActualYarn = ListYarnProyect[IndexYarn];
        dialogueRunner.SetProject(ActualYarn);
    }
   public void StartDialogueRunner()
   {
       dialogueRunner.StartDialogue(ActualYarn.NodeNames[0]);
   }

    public void StartDialogueRunner(string Dialogue)
   {
       dialogueRunner.StartDialogue(Dialogue);
   }

    public void StopDialogueRunner()
    {
        dialogueRunner.Stop();
    }
  public bool FindNode(string nodeNameToFind)
{
    Debug.Log("FindNode " + nodeNameToFind);
    foreach (string nodeName in ActualYarn.NodeNames) 
    {
      
        if (nodeName == nodeNameToFind)
        {
            Debug.Log("Nodo encontrado: " + nodeNameToFind);
            // ¡Nodo encontrado! Puedes hacer algo aquí, como iniciar el diálogo.
            return true; 
        }
    }
     Debug.Log("NO ENCUENTRA NODO: " + nodeNameToFind);
    // Si llega aquí, el nodo no se encontró.
    return false;
}
   
   public bool GetIsDialogueRunning()
   {
       return dialogueRunner.IsDialogueRunning;
   }

    // [YarnCommand("show_dialogue")]
    // public void ShowDialogue(string text)
    // {
    //     keywordHandler.UpdateDialogueText(text);
    // }
   
}
