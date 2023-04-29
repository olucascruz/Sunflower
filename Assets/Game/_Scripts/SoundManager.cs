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
}