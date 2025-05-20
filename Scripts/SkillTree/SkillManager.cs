using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Player_COmbat combat;
    
    private void OnEnable() {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointsSpent;
    }

    private void OnDisable() {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointsSpent;
    }
    
    private void HandleAbilityPointsSpent(SkillSlot slot){
        string skillName = slot.skillSO.skillName;

        switch (skillName)
        {
            case "Max Health Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;
            case "Sword Slash":
                combat.enabled  = true;
                break;

            default:
            Debug.LogWarning("Unknown skill:" + skillName);
            break;
        }
    }
}
