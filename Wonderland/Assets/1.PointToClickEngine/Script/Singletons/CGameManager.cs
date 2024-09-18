using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class CGameManager : MonoBehaviour
{
    // Referencias a otros managers
    public CManagerSFX sfxManager;

    // Estado del juego
    [SerializeField] private int score;
    [SerializeField] private int currentLevel;
    [SerializeField] private int playerLives;

    [SerializeField] private float progressPorcement;

    [SerializeField] private bool IsEndGame;

    [SerializeField] private bool Is3D;

    [SerializeField] private bool IsTalking;
   
    [SerializeField] private bool PuzzleMode = false;

     [SerializeField] private float lerpDuration = 2f; // Duración de la transición
    private Coroutine cameraLerpCoroutine; // Para controlar la corrutina
   //private Transform originalCameraTransform; 
   private Vector3 originalCameraPosition; 
   private Quaternion originalCameraRotation;

   private GameObject PlayerGameobject;
     [SerializeField] private Transform originalCameraTransform;


    public void LearpCameraToPuzzle(Transform puzzleTransform)
    {
        
        if(PuzzleMode == false)
        {
           
        // Detener la corrutina si ya hay una en progreso
            if (cameraLerpCoroutine != null )
            {
                StopCoroutine(cameraLerpCoroutine);
            }
            cameraLerpCoroutine = StartCoroutine(LerpCameraToPuzzle(puzzleTransform));
        }
        // Iniciar la corrutina de movimiento
       
    }

    //Singleton
     public static CGameManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameManager");
                return obj.AddComponent<CGameManager>();
            }
            return _inst;

        }
    }
    private static CGameManager _inst;

    private AsyncOperation _CurrentLoadScene;

   public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }



    private void Start()
    // Métodos para inicializar y finalizar el juego
    {
      
        PlayerGameobject = GameObject.FindGameObjectWithTag("Player");
     
    }
    public void InitializeGame()
    {
        // Cargar niveles, configurar controles, etc.

    }

    public void EndGame()
    {
        // Guardar puntuación, mostrar pantalla de game over, etc.
        
    }

    // Métodos para manejar eventos del juego
    public void OnPlayerDeath()
    {
        // Restar vida al jugador, mostrar efecto de muerte, etc.
    }

    public void OnLevelComplete()
    {
        // Incrementar nivel, mostrar pantalla de victoria, etc.
    }

    // Métodos para actualizar y renderizar el juego
    public void Update()
    {
        // Actualizar física, renderizar gráficos, etc.
       
    }

    public void RenderGame()
    {
        // Renderizar gráficos, mostrar HUD, etc.
    }


    public void SaveGame()
    {
        // Guardar puntuación, nivel actual, Data del inventario, Progreso, niveles completados
    }

    public void LoadGame()
    {
        // Cargar puntuación, nivel actual, Data del inventario, Progreso, niveles completados
    }

    public void CreateNewSaveGame()
    {
        // Crea una partida nueva en un slot, que gurda el progreso
    }

    public void AutoloadGamePostDeath()
    {
        // Carga el juego después de la muerte del jugador cuando se presiona cualquier tecla
    }

    public void DeleteInventarieItem()
    {
         // Elimina un item del inventario
    }
    
    public void SwitchMechanics2DTo3D(bool Genere)
    {
        // Cambia las mecanicas de 2D a 3D O 3D a 2d
    }
    
     public void StartDialogSystem()
  {
    IsTalking = true;
    
  }
  public void LearpBackToOriginalPosition()
    {
        if (cameraLerpCoroutine != null)
        {
            StopCoroutine(cameraLerpCoroutine);
        }
        cameraLerpCoroutine = StartCoroutine(LerpCameraToBackOrigianlPosition());
    }
    private IEnumerator LerpCameraToPuzzle(Transform targetTransform)
    {
   
    float timeElapsed = 0f;
    Transform startingPos = PlayerGameobject.transform;
    //Quaternion startingRot = Camera.main.transform.rotation;

    while (timeElapsed < lerpDuration)
    {
        Camera.main.transform.position = Vector3.Lerp(startingPos.position, targetTransform.position, timeElapsed / lerpDuration);
        Camera.main.transform.rotation = Quaternion.Lerp(startingPos.rotation, targetTransform.rotation, timeElapsed / lerpDuration);

        timeElapsed += Time.deltaTime;
        yield return null;
    }
    PuzzleMode = true; 
    
}


  private IEnumerator LerpCameraToBackOrigianlPosition()
    {
    float timeElapsed = 0f;
    Transform startingPos = Camera.main.transform;
    Quaternion startingRot = Camera.main.transform.rotation;

    while (timeElapsed < lerpDuration)
    {
        Camera.main.transform.position = Vector3.Lerp(startingPos.position,  originalCameraPosition, timeElapsed / lerpDuration);
        Camera.main.transform.rotation = Quaternion.Lerp(startingRot , originalCameraRotation, timeElapsed / lerpDuration);

        timeElapsed += Time.deltaTime;
        yield return null;
    }
    PuzzleMode = false; 

    //Guardar la posición original si es la primera vez que se llama a LerpCamera
    }

    public bool GetPuzzleMode()
    {
        return PuzzleMode;
    }

    public void ActivateCamera1(Transform target)
    {
        DeactivateAllCameras();
        CCameraManager.Inst.camera1.gameObject.SetActive(true);
        CCameraManager.Inst.camera1.transform.position = target.position;
        CCameraManager.Inst.camera1.transform.rotation = target.rotation;
        PuzzleMode = true;
    }

    public void ActivateCamera2(Transform target)
    {
        DeactivateAllCameras();
        CCameraManager.Inst.camera2.gameObject.SetActive(true);
        CCameraManager.Inst.camera2.transform.position = target.position;
        CCameraManager.Inst.camera2.transform.rotation = target.rotation;
        PuzzleMode = true;
    }

    public void ActivateMainCamera()
    {
        DeactivateAllCameras();
        CCameraManager.Inst.mainCamera.gameObject.SetActive(true);
        PuzzleMode = false;
    }

    private void DeactivateAllCameras()
    {
        CCameraManager.Inst.mainCamera.gameObject.SetActive(false);
        CCameraManager.Inst.camera1.gameObject.SetActive(false);
        CCameraManager.Inst.camera2.gameObject.SetActive(false);
    }
}
