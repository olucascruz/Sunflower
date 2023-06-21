using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private OptionsValues optionsValues;
    [Header("Audios")]
    [SerializeField] private AudioSource backgroundGame;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource smashBug;
    [SerializeField] private AudioSource growSunflowerSound;


    public static SoundManager instance;
    
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
   
    
    private void Start()
    {
        backgroundGame.Play();
        backgroundGame.volume = optionsValues.volume;
    }


    public void ButtonClick(){
        button.Play();
    }

    public void SmashBug(){
        smashBug.Play();
    }

    public void PlayGrowSunflowerSound(){
        growSunflowerSound.Play();
    }
}