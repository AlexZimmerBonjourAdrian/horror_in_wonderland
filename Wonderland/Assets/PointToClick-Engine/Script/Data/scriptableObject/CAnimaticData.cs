using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimatioNData", menuName = "PointToClick/Animatic")]
[Serializable]
public class CAnimaticData : ScriptableObject
{
   private int _id;
  

   private Sprite _Animatic;

   private CAnimaticData _NextAnimatic;
  [SerializeField] private bool _hasPlayed;
    
    public bool HasPlayed 
    { 
        get => _hasPlayed; 
        set => _hasPlayed = value; 
    }

//     public void PlayAnimatic(CAnimaticData animaticData)
// {
//     if (animaticData.HasPlayed)
//     {
//         // La animatic ya se ha reproducido, no hacer nada
//         return;
//     }

//     // Reproducir la animatic
//     // ...

//     // Marcar la animatic como reproducida
//     animaticData.HasPlayed = true;
// }
}
