using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireSoundManager : MonoBehaviour
{
    public static CampfireSoundManager instance;

    private static AudioSource [] AudioPlayers;
    //public AudioSource Audioplayer2Clone;

    private void Awake()
    {
        instance = this;
        AudioPlayers = GetComponents<AudioSource>();
    }

    public static void PlayFire()
    {
        AudioPlayers[0].Play();
    }
    public static void StopFire()
    {
        AudioPlayers[0].Stop();
    }
    public static void PlayLevelUp()
    {
        AudioPlayers[1].Play();
    }
}