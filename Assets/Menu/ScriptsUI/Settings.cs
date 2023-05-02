using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{
    
    [SerializeField] private OptionsValues optionsValues;
    [SerializeField] private Slider slider;


    void Start()
    {   
        Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);   
        slider.value = optionsValues.volume;
    }

    
    void Update()
    {
        optionsValues.volume = slider.value;
    }
}
