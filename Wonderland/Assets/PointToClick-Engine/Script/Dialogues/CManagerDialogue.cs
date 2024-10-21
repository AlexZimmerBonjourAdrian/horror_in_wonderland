using UnityEngine;
using System.Collections.Generic;
using Yarn.Unity;
using TMPro;
using System.IO;
using System.Linq;
using System;


namespace PointClickerEngine
{
[RequireComponent(typeof(CKeywordHandler),typeof(CRoleplayDialogue),typeof(CDiceRollDialogue))]
public class CManagerDialogue : MonoBehaviour
{

    [SerializeField]
    private DialogueRunner dialogueRunner;
   
   [SerializeField]
    private List<string> dialogueHistory = new List<string>();

    [SerializeField]
    private HashSet<string> executedDialogues = new HashSet<string>();
    
    [SerializeField]
    public DialogueSaver dialogueSaver;

    
    [SerializeField] public TextMeshProUGUI dialogueText;


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
       // keywordHandler = GetComponent<CKeywordHandler>();
       dialogueSaver = new DialogueSaver();
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
   public void StartDialogueRunner(int IndexYarn)
   {
       dialogueRunner.StartDialogue(ActualYarn.NodeNames[IndexYarn]);
   }

    public void StartDialogueRunner(string Dialogue)
   {    
     if (!dialogueHistory.Contains(Dialogue)) 
     {
        dialogueHistory.Add(Dialogue); 
     } 
     else
     {
        if (executedDialogues.Add(Dialogue)) 
        {

        dialogueRunner.StartDialogue(Dialogue);

            dialogueSaver.SaveDialogue(Dialogue);
        }
        else
        {
            Debug.LogWarning("Dialogue '" + Dialogue + "' has already been executed.");
        }
      }
   }
    public void IterateDialogueViews()
    {
          if (dialogueRunner == null || dialogueRunner.dialogueViews == null)
        {
            Debug.LogError("DialogueRunner or dialogueViews is not assigned!");
            return;
        }
        var dialogueView = dialogueRunner.dialogueViews;
        
          var LineViews = dialogueView[0];
          //var optionListView = dialogueView[0];

           dialogueHistory.Add(LineViews.ToString()); 
            

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

    public  TextMeshProUGUI getText()
    {
        return dialogueText;
    }


    public DialogueRunner GetDialogueRunner()
    {
        return dialogueRunner;
    }

    public List<String> getdialogueHistory()
    {
        return dialogueHistory;
    }

     public HashSet<string> getexecutedDialogues()
    {
        return executedDialogues;
    }
}
    

public class DialogueSaver : Yarn.Unity.VariableStorageBehaviour
{
    private string filePath = "Assets/SaveData/dialogues.txt"; // Path to save the dialogues

    public void SaveDialogue(string dialogueName)
    {
        // Append the dialogue name to the file
        using (StreamWriter writer = File.AppendText(filePath))
        {
            writer.WriteLine(dialogueName);
        }
    }

    // main function used by Dialogue Runner to retrieve Yarn variable values

    
    // overload for setting a String variable
    public override void SetValue(string variableName, string stringValue) {
        // save "stringValue" under key "variableName" to a dictionary, etc.
    }
    
    // overload for setting a Float variable
    public override void SetValue(string variableName, float floatValue) {
        // save to a dictionary, etc.
    }
    
    // overload for setting a Boolean variable
    public override void SetValue(string variableName, bool boolValue) {
        // save to a dictionary, etc.
    }

    // clear all variable data        
    public override void Clear() {
        // clear all your dictionaries
    }

    public override bool Contains(string variableName)
    {
        throw new System.NotImplementedException();
    }

    public override void SetAllVariables(Dictionary<string, float> floats, Dictionary<string, string> strings, Dictionary<string, bool> bools, bool clear = true)
    {
        throw new System.NotImplementedException();
    }

    public override (Dictionary<string, float> FloatVariables, Dictionary<string, string> StringVariables, Dictionary<string, bool> BoolVariables) GetAllVariables()
    {
        throw new System.NotImplementedException();
    }

    public override bool TryGetValue<T>(string variableName, out T result)
    {
        throw new System.NotImplementedException();
    }
}
}



