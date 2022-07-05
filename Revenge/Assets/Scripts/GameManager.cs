using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform lastCampfire;
    public charStateManger charState;
    public charHealthController charHealth;
    public charCombatController charCombat;
    public GameObject deadScreen;
    public charSoulController souls;
    public bossHealthController boss;
    public levelUpController lvlUp;

    private GameMusicController GameMusics;
    private SaveObjects Save;
    private void Start()
    {
        GameMusics = GameObject.FindGameObjectWithTag("GameMusics").GetComponent<GameMusicController>();
        StartGame();
    }
    private void StartGame()
    {
        Save = SaveManager.Load();
        CheckMusic();
        if(Save.Saved)
        {
            charHealth.healthLevelUp(Save.Health - charHealth.playerMaxHealth);
            charCombat.levelUpDamage(Save.Damage - charCombat.attack1Damage);
            souls.addSoul(Save.Soul);
            charState.gameObject.transform.position = new Vector3(Save.xPosition, Save.yPosition, 0);
            lvlUp.SetLevels(Save.DamageLevel, Save.HealthLevel);
        }
    }
    private void CheckMusic()
    {
        if (SceneManager.GetActiveScene().name == "1")
            GameMusics.SetMusic(MusicType.Gameplay);
        else
            GameMusics.SetMusic(MusicType.Boss);
    }
    public void SaveGame(Vector3 position)
    {
        Save.Saved = true;
        Save.xPosition = position.x;
        Save.yPosition = position.y;
        Save.Damage = charCombat.attack1Damage;
        Save.Health = charHealth.playerMaxHealth;
        Save.DamageLevel = lvlUp.GetDamageLevel();
        Save.HealthLevel = lvlUp.GetHealthLevel();
        Save.Soul = souls.getSoulCount();
        SaveManager.Save(Save);
        Debug.Log("Saved = " + position);
    }
    public void Respawn()
    {
        if(lastCampfire != null)
        {
            charHealth.rest();
            charState.gameObject.transform.position = lastCampfire.position;
            lastCampfire.gameObject.GetComponent<campfireController>().enemiesWorks();
            charState.SwitchState(charState.movingState);
            souls.resetSouls();
            if(boss != null)
            {
                boss.Reset();
            }
            deadScreen.SetActive(false);
        }
        else
        {
            GameMusics.SetMusic(MusicType.Gameplay);
            SceneManager.LoadScene("1");
        }
    }
}