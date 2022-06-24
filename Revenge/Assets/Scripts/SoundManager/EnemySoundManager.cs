using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{
    public static EnemySoundManager instance;

    private AudioSource AudioPlayer;

    public AudioClip MeleeAttack;
    public AudioClip RangeAttack;
    private void Awake()
    {
        AudioPlayer = GetComponent<AudioSource>();
    }

    public void RangeAttackPlay()
    {
        AudioPlayer.clip = RangeAttack;
        AudioPlayer.Play();
    }
    public void MeleeAttackPlay()
    {
        AudioPlayer.clip = MeleeAttack;
        AudioPlayer.Play();
    }
}
