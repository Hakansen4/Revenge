using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allEnemies : MonoBehaviour
{
    public static allEnemies instance;
    public List<GameObject> enemies;
    private void Awake()
    {
        instance = this;
        addEnemies();
    }
    private void addEnemies()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemyPrefab");
        for (int i = 0; i < enemy.Length; i++)
        {
            enemies.Add(enemy[i]);
        }
    }
    public void setActivity(bool active)
    {
        if(active)
        {
            foreach (var item in enemies)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (var item in enemies)
            {
                item.SetActive(false);
            }
        }
    }
    public void setBasePosition()
    {
        foreach (var item in enemies)
        {
            item.transform.position = new Vector3(item.GetComponent<e_0stateManager>().leftBorder, item.transform.position.y,
                                                    item.transform.position.z);
        }
    }

    public void respawnEnemies()
    {
        foreach (var item in enemies)
        {
            item.SetActive(true);
            item.GetComponent<e_0healthController>().respawn();
            item.GetComponent<e_0stateManager>().SwitchState(item.GetComponent<e_0stateManager>().patrolState);
        }
    }
}