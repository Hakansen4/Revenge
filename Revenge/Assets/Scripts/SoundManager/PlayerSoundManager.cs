using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager instance;

    private AudioSource AudioPlayer;
    private bool isGrounded;

    public AudioClip HitEnemy;
    public AudioClip Attack;
    public AudioClip HittedSound;
    public AudioClip WalkSound;
    private void Awake()
    {
        instance = this;
        AudioPlayer = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    public void Play(PlayerAudio audioType)
    {
        AudioPlayer.volume = 1;
        switch (audioType)
        {
            case PlayerAudio.HitEnemy:
                AudioPlayer.clip = HitEnemy;
                break;
            case PlayerAudio.Attack:
                AudioPlayer.clip = Attack;
                break;
            case PlayerAudio.Hitted:
                AudioPlayer.clip = HittedSound;
                break;
            default:
                break;
        }
        AudioPlayer.Play();
    }

    public void WalkSoundPlay()
    {
        if(isGrounded)
        {
            AudioPlayer.volume = 0.1f;
            AudioPlayer.clip = WalkSound;
            AudioPlayer.Play();
        }
    }
}

public enum PlayerAudio
{
    HitEnemy,
    Attack,
    Hitted
}
