using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMusicController : MonoBehaviour
{
    public AudioClip MenuMusic;
    public AudioClip GameplayMusic;
    public AudioClip BossFightMusic;

    private AudioSource AudioPlayer;
    private Toggle toggle;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        toggle = GetComponentInChildren<Toggle>();
        AudioPlayer = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MuteController();
    }
    private void MuteController()
    {
        if(!toggle.isOn)
        {
            AudioPlayer.mute = true;
        }
        else
            AudioPlayer.mute = false;

    }

    public void SetMusic(MusicType music)
    {
        switch (music)
        {   
            case MusicType.Menu:
                AudioPlayer.clip = MenuMusic;
                break;
            case MusicType.Gameplay:
                AudioPlayer.clip = GameplayMusic;
                break;
            case MusicType.Boss:
                AudioPlayer.clip = BossFightMusic;
                break;
            default:
                break;
        }
        AudioPlayer.Play();
    }
}
public enum MusicType
{
    Menu,
    Gameplay,
    Boss
}