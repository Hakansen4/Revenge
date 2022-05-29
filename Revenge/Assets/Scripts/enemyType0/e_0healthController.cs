using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_0healthController : MonoBehaviour
{
    [SerializeField] private Enemies enemyType;
    private float maxHealth;
    [SerializeField]private healthBarController healthBar;
    private e_0stateManager state;
    private GameObject healtBarObject;
    private float healthBarTimer;
    private float healthBarTime;
    private float health; 
    private void Awake()
    {
        maxHealth = enemyType.enemyHealth;
        health = maxHealth;
        state = this.gameObject.GetComponent<e_0stateManager>();
        healtBarObject = healthBar.gameObject;
        healthBarTimer = 0;
        healthBarTime = 3;
        healtBarObject.SetActive(false);
        healthBar.setMaxHealth(maxHealth);
    }
    void Update()
    {
        checkHealtBarTime();
    }
    public void increaseHealth(float damage)
    {
        healthBarTimer = Time.time + healthBarTime;
        healtBarObject.SetActive(true);
        if(health > 0)
            health-=damage;
        healthBar.setHealth(health);
        if(health <= 0  &&  state.currentState != state.deadState)
        {
            state.SwitchState(state.deadState);
        }
    }
    public bool isDead()
    {
        if(health <= 0)
            return true;
        return false;
    }
    private void checkHealtBarTime()
    {
        if(Time.time > healthBarTimer)
        {
            healtBarObject.SetActive(false);
        }
    }
    public void respawn()
    {
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
}
