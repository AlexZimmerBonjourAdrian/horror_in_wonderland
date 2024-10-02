using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

[RequireComponent(typeof(CMICILSPSystem))]
public class CRoleplayDialogue : MonoBehaviour
{


   

 

    // Example of a more complex check with degrees of success
    // [YarnCommand("advanced_skill_check")]
    // public string PerformAdvancedSkillCheck(CMICILSPSystem.Stats statToCheck, int difficulty)
    // {
    //     int playerStat = statsSystem.GetStat(statToCheck);
    //     int result = playerStat - difficulty;

    //     if (result >= 5)
    //         return "critical_success"; // Huge success!
    //     else if (result >= 1)
    //         return "success";        // Standard success
    //     else if (result >= -3)
    //         return "partial_success"; // Barely made it
    //     else
    //         return "failure";          // Clear failure
    // }
}
