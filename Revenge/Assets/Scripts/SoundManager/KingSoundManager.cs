using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSoundManager : MonoBehaviour
{
    public AudioClip NormalAttack_1;
    public AudioClip NormalAttack_2;
    public AudioClip SpecialAttackCharge;
    public AudioClip SpecialAttack;
    public AudioClip TeleportSound;

    private AudioSource AudioPlayer;

    private void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    public void FirstNormalAttackPlay()
    {
        AudioPlayer.clip = NormalAttack_1;
        AudioPlayer.Play();
    }
    public void SecondNormalAttackPlay()
    {
        AudioPlayer.clip = NormalAttack_2;
        AudioPlayer.Play();
    }
    public void SpecialAttackPlay()
    {
        AudioPlayer.clip = SpecialAttack;
        AudioPlayer.Play();
    }
    public void SpecialAttackChargePlay()
    {
        AudioPlayer.clip = SpecialAttackCharge;
        AudioPlayer.Play();
    }
    public void TeleportSoundPlay()
    {
        AudioPlayer.clip = TeleportSound;
        AudioPlayer.Play();
    }
}
