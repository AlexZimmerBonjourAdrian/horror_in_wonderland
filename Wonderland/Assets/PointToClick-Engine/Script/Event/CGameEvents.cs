using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class CGameEvents 
{   
public static readonly CGameEvent<int> OnLevelComplete = new CGameEvent<int>(); 
    public static readonly CGameEvent<string> OnPlayerDeath = new CGameEvent<string>(); 
    public static readonly CGameEvent<string> OnDialogueTrigger = new CGameEvent<string>();
    public static readonly CGameEvent<string> OnDialogueEnd = new CGameEvent<string>();

    
    //Eventos de UI
    public static readonly CGameEvent<bool> OnShowPauseMenu = new CGameEvent<bool>();
    public static readonly CGameEvent<bool> OnShowInventory = new CGameEvent<bool>();

    //Eventos de sonido
    public static readonly CGameEvent<string> OnPlaySound = new CGameEvent<string>();
    public static readonly CGameEvent OnStopSound = new CGameEvent();

    public static readonly CGameEvent OnLightSwitch = new CGameEvent();

    public static readonly CGameEvent OnActivateDoor = new CGameEvent();

       public static readonly CGameEvent OnCompleteLevel = new CGameEvent();

}
