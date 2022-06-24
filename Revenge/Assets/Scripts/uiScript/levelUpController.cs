using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelUpController : MonoBehaviour
{
    public static levelUpController instance;

    private charSoulController souls;
    private charHealthController health;
    private charCombatController combat;

    private int damageLevel = 1;
    private int healthLevel = 1;

    [Header("Texts")]
    public TextMeshProUGUI RShealth;
    public TextMeshProUGUI RSdamage;
    public TextMeshProUGUI CRhealth;
    public TextMeshProUGUI CRdamage;

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
    private void Update()
    {
        textWorks();
    }

    public void damageLevelUp()
    {
        int damageLvlUpCost = damageLevel * 100;
        if(souls.getSoulCount() >= damageLvlUpCost)
        {
            CampfireSoundManager.PlayLevelUp();
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
            CampfireSoundManager.PlayLevelUp();
            souls.deleteSouls(healthLvlCost);
            health.healthLevelUp(healthLevel * 3);
            healthLevel++;
        }
    }
    private void textWorks()
    {
        int damageLvlUpCost = damageLevel * 100;
        int healthLvlCost = healthLevel * 100;
        CRhealth.text = health.playerMaxHealth.ToString();
        CRdamage.text = combat.getDamage().ToString();
        RShealth.text = healthLvlCost.ToString();
        RSdamage.text = damageLvlUpCost.ToString();
    }
}
