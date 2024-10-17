using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using Patterns.GameEvents;

public class CLevel2 : CLevelGeneric
{
   
    [SerializeField] 
    private List<GameObject> POV;

    [SerializeField] 
    private List<GameObject> Mesa;
   
    [SerializeField]
    public List<int> RouteNormalRoom;

    private  bool EnterSound = false;

     [SerializeField]
    public List<GameObject> LevelRooms;

   [SerializeField] public MapData Routerooms;

    [SerializeField] public List<StructRoom.Room> rooms; // Lista de todas las rooms

    private int currentRoomIndex; // Índice de la room actual

    // [SerializeField]
    // private List<int> SequencePuzzle;
    
    [SerializeField]
    private List<int> CorrectSequence;

   // [SerializeField]
   // private EPuzzleType.Puzzle TypePuzzle = EPuzzleType.Puzzle.None;

    
    [SerializeField]
    private bool IsTakeShootgun;
    
    [SerializeField]
    private bool IsRevolver;
    [SerializeField]
    private bool IsMagRevolver;
    [SerializeField]
    private bool IsShootGunShell;

    [SerializeField]
    private bool IsFinished;

    [SerializeField]
    private bool IsTakeCard;

    [SerializeField]
    private bool IsShootMusicBox;

    private CDoor doorTemp;
    private int ActualRoom = 0;

    public static CLevel2 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level2");
                return obj.AddComponent<CLevel2>();
            }

            return _inst;
        }
    }

    private static CLevel2 _inst;


    public void Awake()
    {
     
        LevelRooms = GetComponentsInChildren<Room>().Select(room => room.gameObject).ToList();
       
       // TypePuzzle = EPuzzleType.Puzzle.Sequence;
       
        _inst = this;
        
        
    }


 public void Start()
{
    doorTemp = FindObjectOfType<CDoor>();
    SetRoomActive(0, true);
    SetPovActive(0,true);
    SetMesaActive(0,true);
}


public void SetIsShootMusicBox(bool aBool)
{
    IsShootMusicBox = aBool;
}

public void SetIsTakeShootgun(bool aBool)
{
    IsTakeShootgun = aBool;
}

public void SetIsRevolver(bool aBool)
{
    IsRevolver = aBool;
}

public void SetIsFinished(bool aBool)
{
   
    IsFinished = aBool;
    doorTemp.SetThisLevelIsComplete(aBool);
}
public void SetIsMagRevolver(bool aBool)
{
    IsMagRevolver = aBool;
}

public void SetIsTakeCard(bool aBool)
{
    IsTakeCard = aBool;
}

public void SetIsShootGunShell(bool aBool)
{
    IsShootGunShell = aBool;
}
public bool GetIsShootMusicBox()
{
   return IsShootMusicBox;
}

public bool GetIsRevolver()
{
    return IsRevolver;
}

public bool GetIsMagRevolver()
{
    return IsMagRevolver;
}

public bool GetIsTakeShootGun()
{
    return IsTakeShootgun;
}

public bool GetIsShootGunShell()
{
    return IsShootGunShell;
}

public bool GetIsFinishLevel()
{
  
    return  IsFinished;
}
public void SetRoomActive(int roomIndex, bool isActive)
    {
        if (roomIndex >= 0 && roomIndex < LevelRooms.Count)
        {
            LevelRooms[roomIndex].SetActive(isActive);
            ActualRoom = roomIndex;
            RouteNormalRoom.Add(ActualRoom);
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  LevelRooms.Count-1; i++)
        {
            if( i != ActualRoom)
            {
                 LevelRooms[i].SetActive(false);
            }
        }

    }

    public void SetPovActive(int roomIndex, bool isActive)
    {
        if (roomIndex >= 0 && roomIndex < POV.Count)
        {
            POV[roomIndex].SetActive(isActive);      
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  POV.Count-1; i++)
        {
            if( i != roomIndex)
            {
                 POV[i].SetActive(false);
            }
        }

    }

    
        public void SetMesaActive(int roomIndex, bool isActive)
    {
        if (roomIndex >= 0 && roomIndex < Mesa.Count)
        {
            Mesa[roomIndex].SetActive(isActive);      
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  Mesa.Count-1; i++)
        {
            if( i != roomIndex)
            {
                Mesa[i].SetActive(false);
            }
        }

    }


public void LoadRoom(int index)
    {
        // Validar el índice
        foreach (StructRoom.Room R in rooms)
        {
            if (R.id == index)
            {
                if (R.IsAccessible)
                {
                    Debug.LogWarning("La room " + index + "Es");
                    currentRoomIndex = index;
                    //_SprtR.sprite = R.RoomImage;                   

                break;
            }
            else
            {
                Debug.LogWarning("La room " + index + " no es accesible.");
                break;
            }
        }
    }
}




    public void LoadRoomByTag(string roomTag)
    {
        // Iterate through all rooms and update IsAccessible based on the tag
        foreach (var R in rooms)
        {
            if (R.tag == roomTag)
            {
                R.SetIsAccessible(true);
                Debug.LogWarning("La room " + R.id + " con tag " + roomTag + " es accesible.");
            }
            else
            {   
             
                R.SetIsAccessible(false);
                Debug.LogWarning("La room " + R.id + " con tag " + roomTag + " no es accesible.");
            }
        }
        
    }

     public int GetCurrentRoomIndex()
     {
         return currentRoomIndex;
     }

     public MapData GetRouterooms()
     {
        return Routerooms;
     }

    public void SetRouterooms(MapData Data)
    {
        Routerooms = Data;
    }

    public void Update()
    {
        if(GetIsShootGunShell() == true && GetIsShootGunShell() && EnterSound == false)
        {
            CManagerSFX.Inst.PlaySound(8);
            EnterSound = true;
        }
    }


    
}
