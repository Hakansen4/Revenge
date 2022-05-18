using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfireController : MonoBehaviour
{
    public charStateManger charState;
    public allEnemies enemies;
    public GameObject tButton;
    public GameObject levelUpScreen;
    private bool inArea = false;
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
                charState.SwitchState(charState.restState);
                enemies.setActivity(false);
                enemies.setBasePosition();
                levelUpScreen.SetActive(true);
            }
        }
    }
    public void endRest()
    {
        enemies.respawnEnemies();
        charState.SwitchState(charState.movingState);
        levelUpScreen.SetActive(false);
    }
}
