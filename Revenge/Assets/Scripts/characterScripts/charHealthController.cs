using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class charHealthController : MonoBehaviour
{
    public float playerMaxHealth;
    private float playerHealth;
    public int maxPotionCount;
    public TextMeshProUGUI potionCountText;
    private int potionCount;
    public GameObject emptyPotion;
    private charStateManger state;
    private Animator anim;
    [SerializeField]private healthBarController healthBar;
    private void Awake()
    {
        potionCount = maxPotionCount;
        potionCountText.text = potionCount.ToString();
        anim = GetComponent<Animator>();
        playerHealth = playerMaxHealth;
        state = GetComponent<charStateManger>();
        healthBar.setMaxHealth(playerMaxHealth);
    }
    private void Update() {
        healYourself();
        chechPotionCount();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("e0_Hit"))
        {
            if(playerHealth > 0)
                playerHealth -= 15;
            healthBar.setHealth(playerHealth);
            if(playerHealth <= 0  &&  state.currentState != state.deadState)
            {
                state.SwitchState(state.deadState);
            }
        }
    }
    private void healYourself()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(chechPotionCount())
            {
                if(playerHealth != playerMaxHealth)
                {
                    if(playerMaxHealth - playerHealth < 20)
                        playerHealth = playerMaxHealth;
                    else if(playerHealth > 0)
                    {
                        playerHealth += 20;
                    }
                    anim.SetTrigger("Heal");
                    healthBar.setHealth(playerHealth);
                    potionCount--;
                    potionCountText.text = potionCount.ToString();
                }
            }
        }
    }

    private bool chechPotionCount()
    {
        if(potionCount <= 0)
        {
            emptyPotion.SetActive(true);
            return false;
        }
        return true;
    }
}