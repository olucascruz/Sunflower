using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMenu : MonoBehaviour
{

    [SerializeField] private OptionsValues optionsValues;
    [Header("Audios")]
    [SerializeField] private AudioSource backgroundMenu;
    [SerializeField] private AudioSource button;

   
    
    private void Start()
    {
        backgroundMenu.Play();
    }

    private void OnGUI()
    {
        backgroundMenu.volume =  optionsValues.volume;
        button.volume = optionsValues.volume;
    }

    public void ButtonClick(){
        button.Play();
    }
}
