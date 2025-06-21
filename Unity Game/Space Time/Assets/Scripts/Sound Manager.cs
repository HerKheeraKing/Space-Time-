using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // Access from other scripts
    public static SoundManager instance;

    [Header("---BGM---")]
    [SerializeField] public AudioSource soundTrackAud;
    [SerializeField] AudioClip gamePlayMusic;
    [SerializeField] public float gamePlayVol;
    public bool isPlayingGamePlayMusic = false;


    [Header("---Menu Music---")]
    [SerializeField] public AudioSource menuAud;
    [SerializeField] AudioClip menuMusic; 
    [SerializeField] public float menuVol;
    public bool isPlayingMenuMusic = false;


    [Header("---Sound Effects---")]
    [SerializeField] public AudioSource sfxAud;
    [SerializeField] AudioClip playerEnter; 
    [SerializeField] public float playerEnterVol;
    public bool isPlayingPlayerEnterMusic = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
           instance = this;
        }

        SoundTrackswitch(musicType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public enum GameMusic {GamePlay, menuMusic, playerEnter}
public GameMusic musicType = GameMusic.menuMusic;
    // Sound Functions 
    public void SoundTrackswitch(GameMusic music)
    {
   
      switch(music)
      {
        case GameMusic.GamePlay:
         if(soundTrackAud != null)
        {
         if(soundTrackAud.clip != gamePlayMusic)
         {
            soundTrackAud.clip = gamePlayMusic;
            soundTrackAud.volume = gamePlayVol;
            soundTrackAud.Play();
            isPlayingGamePlayMusic = true;
         }
        }
        break;

        case GameMusic.menuMusic:
        if(menuAud != null)
        {
            if(menuAud.clip != menuMusic)
            {
               menuAud.clip = menuMusic;
               menuAud.volume = menuVol;
               menuAud.Play();
               isPlayingMenuMusic = true;
            }
        }
         break;
        

        case GameMusic.playerEnter:
        if(sfxAud.clip != playerEnter)
        {
           sfxAud.PlayOneShot(playerEnter, playerEnterVol);
           isPlayingPlayerEnterMusic = true;
        }
        break;


      }
    }
}
