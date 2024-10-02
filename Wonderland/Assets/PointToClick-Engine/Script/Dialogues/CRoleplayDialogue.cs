using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

[RequireComponent(typeof(CMICILSPSystem))]
public class CRoleplayDialogue : MonoBehaviour
{
   // Example of a more complex check with degrees of success
     [YarnFunction("GetStatByIndex")]
    public static string PerformAdvancedSkillCheck(int statIndex, int difficulty)
    {
        int playerStat = CMICILSPSystem.Instance.GetStatByIndex(statIndex);
        int result = playerStat - difficulty;
        Debug.Log(result.ToString());

        if (result >= 3)
            return "critical_success"; // Huge success!
        else if (result >= 0)
            return "success";        // Standard success
        else if (result >= -3)
            return "partial_success"; // Barely made it
        else
            return "failure";          // Clear failure

    }
}
