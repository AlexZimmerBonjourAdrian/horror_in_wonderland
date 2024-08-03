﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{

    public int level;
    public int health;
    public float[] position;
    
public void SavePlayer()
{
    CSaveSystem.SavePlayer(this);
}

public void LoadPlayer()
{
    CPlayerData data = CSaveSystem.LoadPlayer();

    // Update the player's properties based on the loaded data
    level = data.level;
    health = data.health;
    transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
}
    
}
