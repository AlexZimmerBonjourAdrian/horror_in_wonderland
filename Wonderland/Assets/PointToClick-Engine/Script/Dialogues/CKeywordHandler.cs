using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CKeywordHandler : MonoBehaviour
{

   [SerializeField] public static Text  dialogueText;
    // Start is called before the first frame update

    private void Start()
    
    {
        dialogueText = GameObject.Find("DialogueText").GetComponent<Text>();

    }
     public static void OnKeywordClick(string keyword)
    {
        // Busca el nodo correspondiente a la palabra clave
        string nodeName = keyword;
        Debug.Log("OnKeywordClick " + nodeName); // Ajusta según tu nomenclatura
        if (CManagerDialogue.Inst.FindNode(nodeName) == true)
        {    
            CManagerDialogue.Inst.StopDialogueRunner();
            // Inicia el diálogo en el nodo encontrado

            CManagerDialogue.Inst.StartDialogueRunner(nodeName);
        }
    }

    [YarnCommand("EndTerror")]
    public static void UpdateDialogueText(string text)
    {
//         Debug.Log("Text type: " + text); // Example: prints the terror type
      //   dialogueText.text = ""; // Limpia el texto anterior

        // // Divide el texto en palabras
        // string[] words = text.Split(' ');

        // // Itera sobre cada palabra
        
           // Debug.Log("Text type: " + word);
        //     // Verifica si la palabra es una palabra clave (puedes usar un prefijo o sufijo especial)
            
                // Extrae la palabra clave sin las etiquetas

                // Crea un objeto de texto para la palabra clave
                GameObject keywordObject = new GameObject("Keyword");
                keywordObject.transform.SetParent(dialogueText.transform);
                
                // Agrega un componente Text al objeto
                Text keywordText = keywordObject.AddComponent<Text>();
                keywordText.text = text;
                keywordText.font = dialogueText.font;
                keywordText.fontSize = dialogueText.fontSize;
               // keywordText.color = Color.black // Color de resaltado
             
                // Agrega un componente Button al objeto
                Button keywordButton = keywordObject.AddComponent<Button>();
                keywordButton.onClick.AddListener(() => OnKeywordClick(text));
            
           
         
    }

    public static Text getText()
    {
        return dialogueText;
    }
}
