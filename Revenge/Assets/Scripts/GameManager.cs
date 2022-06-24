using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform lastCampfire;
    public charStateManger charState;
    public charHealthController charHealth;
    public GameObject deadScreen;
    public charSoulController souls;
    public bossHealthController boss;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}