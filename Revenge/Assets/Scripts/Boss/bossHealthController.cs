using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealthController : MonoBehaviour
{
    [SerializeField]private float maxHealth;
    [SerializeField]private healthBarController healthBar;
    private bossStateManager state;
    private float health; 
    private void Awake()
    {
        health = maxHealth;
        state = this.gameObject.GetComponent<bossStateManager>();
        healthBar.setMaxHealth(maxHealth);
    }
    public void increaseHealth()
    {
        if(health > 0)
            health--;
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
}
