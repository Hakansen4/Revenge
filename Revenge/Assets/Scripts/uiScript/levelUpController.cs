using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpController : MonoBehaviour
{
    public static levelUpController instance;

    private charSoulController souls;
    private charHealthController health;
    private charCombatController combat;

    private int damageLevel = 1;
    private int healthLevel = 1;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        souls = charSoulController.instance;
        health = charHealthController.instance;
        combat = charCombatController.instance;
    }

    public void damageLevelUp()
    {
        int damageLvlUpCost = damageLevel * 100;
        if(souls.getSoulCount() >= damageLvlUpCost)
        {
            souls.deleteSouls(damageLvlUpCost);
            combat.levelUpDamage(damageLevel * 3);
            damageLevel++;
        }
    }
    public void healthLevelUp()
    {
        int healthLvlCost = healthLevel * 100;
        if (souls.getSoulCount() >= healthLvlCost)
        {
            souls.deleteSouls(healthLvlCost);
            health.healthLevelUp(healthLevel * 3);
            healthLevel++;
        }
    }
}
