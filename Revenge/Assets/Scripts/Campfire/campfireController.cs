using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfireController : MonoBehaviour
{
    private charStateManger charState;
    private allEnemies enemies;
    public GameObject tButton;
    public GameObject levelUpScreen;
    public GameManager gm;

    private bool inArea = false;
    private void Start()
    {
        charState = charStateManger.instance;
        enemies = allEnemies.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            tButton.SetActive(true);
            inArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tButton.SetActive(false);
            inArea = false;
        }
    }
    private void Update()
    {
        checkRest();
    }
    private void checkRest()
    {
        if (inArea && charState.currentState != charState.restState)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                gm.lastCampfire = transform;
                charState.SwitchState(charState.restState);
                enemiesWorks();
                levelUpScreen.SetActive(true);
                CampfireSoundManager.PlayFire();
                gm.SaveGame(transform.position);
            }
        }
    }
    public void endRest()
    {
        enemies.respawnEnemies();
        charState.SwitchState(charState.movingState);
        levelUpScreen.SetActive(false);
        CampfireSoundManager.StopFire();
    }
    public void enemiesWorks()
    {
        enemies.setActivity(false);
        enemies.setBasePosition();
        enemies.setActivity(true);
    }
}
