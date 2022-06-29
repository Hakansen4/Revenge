using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class charHealthController : MonoBehaviour
{
    public static charHealthController instance;
    [SerializeField] private Player _playerData;

    [HideInInspector]public float playerMaxHealth;
    private float playerHealth;
    [HideInInspector]public int maxPotionCount;
    public TextMeshProUGUI potionCountText;
    private int potionCount;
    public GameObject emptyPotion;
    private charStateManger state;
    private Animator anim;
    private PlayerSoundManager Sounds;
    [SerializeField]private healthBarController healthBar;
    private void Awake()
    {
        instance = this;
        playerMaxHealth = _playerData.Health;
        maxPotionCount = _playerData.PotionCount;
        potionCount = maxPotionCount;
        potionCountText.text = potionCount.ToString();
        anim = GetComponent<Animator>();
        playerHealth = playerMaxHealth;
        healthBar.setMaxHealth(playerMaxHealth);
    }
    private void Start()
    {
        state = charStateManger.instance;
        Sounds = PlayerSoundManager.instance;
    }
    private void Update() {
        healYourself();
        chechPotionCount();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("e0_Hit")   ||  other.CompareTag("Arrow"))
        {
            if(playerHealth > 0)
            {
                Sounds.Play(PlayerAudio.Hitted);
                playerHealth -= 15;
            }
            healthBar.setHealth(playerHealth);
            if(playerHealth > 0)
            {
                state.SwitchState(state.hittedState);
                hitEffect(other);
            }
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
    private void hitEffect(Collider2D other)
    {
        if (other.transform.position.x > gameObject.transform.position.x)
            GetComponent<Rigidbody2D>().DOMoveX(transform.position.x - 1, 0.6f).OnComplete(() => HitEffectEnded());
        else
            GetComponent<Rigidbody2D>().DOMoveX(transform.position.x + 1, 0.6f).OnComplete(() => HitEffectEnded());

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<charStateManger>().FLAG_MOVE = false;
    }
    private void HitEffectEnded()
    {
        GetComponent<charStateManger>().FLAG_MOVE = true;
    }
    public void healthLevelUp(float value)
    {
        Debug.Log("Eski Health = " + playerMaxHealth);
        playerMaxHealth += value;
        playerHealth = playerMaxHealth;
        healthBar.setMaxHealth(playerMaxHealth);
        healthBar.setHealth(playerHealth);
        Debug.Log("Yeni Health = " + playerMaxHealth);
    }
    public void rest()
    {
        emptyPotion.SetActive(false);
        playerHealth = playerMaxHealth;
        healthBar.setHealth(playerHealth);
        potionCount = maxPotionCount;
        potionCountText.text = potionCount.ToString();
    }
}