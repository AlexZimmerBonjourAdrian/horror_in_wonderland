﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItemData",menuName ="PointToClick/Item")]
[Serializable]
public class CItemData : ScriptableObject
{
    
    // Start is called before the first frame update
    private int Id;
    private string Name;

    [TextArea(2, 2)]
    private string description;
    private Sprite imageInventory;
    private bool Optional;


}
