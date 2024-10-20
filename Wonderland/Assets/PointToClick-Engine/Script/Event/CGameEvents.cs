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

    public static readonly CGameEvent<int> OnPlaySound = new CGameEvent<int>();

//Stop Sound
    public static readonly CGameEvent OnStopSound = new CGameEvent();

//OnLightSwitch
    public static readonly CGameEvent OnLightSwitch = new CGameEvent();

//OnActivateDoor 
    public static readonly CGameEvent OnActivateDoor = new CGameEvent();
//CompleteLevel
    public static readonly CGameEvent<bool> OnCompleteLevel = new CGameEvent<bool>();

//Examples to integrate public static readonly CGameEvent<bool>

//   void OnEnable()
//     {
//         CGameEvents.OnDialogueTrigger.Subscribe(OnDialogueTrigger);
//         CGameEvents.OnDialogueEnd.Subscribe(OnDialogueEnd);
//         CGameEvents.OnShowPauseMenu.Subscribe(OnShowPauseMenu);
//         CGameEvents.OnShowInventory.Subscribe(OnShowInventory);
//         CGameEvents.OnPlaySound.Subscribe(OnPlaySound);
//     }

//     void OnDisable()
//     {
//         CGameEvents.OnDialogueTrigger.Unsubscribe(OnDialogueTrigger);
//         CGameEvents.OnDialogueEnd.Unsubscribe(OnDialogueEnd);
//         CGameEvents.OnShowPauseMenu.Unsubscribe(OnShowPauseMenu);
//         CGameEvents.OnShowInventory.Unsubscribe(OnShowInventory);
//         CGameEvents.OnPlaySound.Unsubscribe(OnPlaySound);
//     }

//     private void OnDialogueTrigger(string dialogueID)
//     {
//         // Lógica para manejar el inicio del diálogo con el ID proporcionado.
//         Debug.Log("Dialogue triggered: " + dialogueID);
//     }

//     private void OnDialogueEnd(string dialogueID)
//     {
//         // Lógica para manejar el final del diálogo con el ID proporcionado.
//         Debug.Log("Dialogue ended: " + dialogueID);
//     }

//     private void OnShowPauseMenu(bool show)
//     {
//         // Lógica para mostrar u ocultar el menú de pausa.
//         Debug.Log("Show pause menu: " + show);
//     }

//     private void OnShowInventory(bool show)
//     {
//         // Lógica para mostrar u ocultar el inventario.
//         Debug.Log("Show inventory: " + show);
//     }

//     private void OnPlaySound(int soundID)
//     {
//         // Lógica para reproducir el sonido con el ID proporcionado.
//         Debug.Log("Play sound: " + soundID);
//     }

}
