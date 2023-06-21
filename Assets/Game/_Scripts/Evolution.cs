using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Evolution : MonoBehaviour
{   
    [SerializeField] private GameObject rootLeft;
    [SerializeField] private GameObject rootRight;


    [SerializeField] private TextMeshProUGUI DescriptUpLeftText;
    [SerializeField] private TextMeshProUGUI PriceLeftText;
    [SerializeField] private TextMeshProUGUI DescriptUpMidText;
    [SerializeField] private TextMeshProUGUI PriceMidText;
    [SerializeField] private TextMeshProUGUI DescriptUpRightText;
    [SerializeField] private TextMeshProUGUI PriceRightText;

    private Sunflower sunflower;
    private GameManager gameManager;
    private SoundManager soundManager;
    private int priceSunflowerGrow = 0;
   
    void Start(){
        sunflower = Sunflower.instance;
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
    }
    void OnEnable(){
        ModalLeft();
        ModalMid();
        ModalRight();
    }   

    void ModalLeft(){
        string textDescription = "a";
        string textPrice = "10";

        if (!rootLeft.activeSelf) {
            textDescription = "Left defensive root";
            textPrice = "25";
        }else{
            textDescription = "Add more life to the sunflower";
            textPrice = "30";
        }
            PriceLeftText.text = textPrice; 
            DescriptUpLeftText.text = textDescription;
    }
    
    void ModalMid(){
        if(!sunflower)return;
        priceSunflowerGrow = 50 + (25 * sunflower.Grow);
        
        string textDescription = "To make the sunflower grow";
        DescriptUpMidText.text = textDescription;
        PriceMidText.text = priceSunflowerGrow.ToString();
    }

    void ModalRight(){
        string textDescription = "a";
        string textPrice = "10";
        if (!rootRight.activeSelf) {
            textDescription = "Right defensive root";
            textPrice = "25";
        }else{
            textDescription = "add more life to the sunflower";
            textPrice = "30";
        }
        DescriptUpRightText.text = textDescription;
        PriceRightText.text = textPrice; 
    }

    public void ClickModalLeft(){
    if (!rootLeft.activeSelf) {
            if(gameManager.EnemiesDead < 25) return;
            rootLeft.SetActive(true);
        }else{
            if(gameManager.EnemiesDead < 30) return;
            sunflower.AddLife();
        }
        ClickReset();

    }

    public void ClickModalMid(){
        if(gameManager.EnemiesDead < priceSunflowerGrow) return;
        sunflower.GrowSunflower();
        soundManager.PlayGrowSunflowerSound();
        ClickReset();
    }

    public void ClickModalRight(){
        if (!rootRight.activeSelf) {
            if(gameManager.EnemiesDead < 25) return;
            rootRight.SetActive(true);
        }else{

            if(gameManager.EnemiesDead < 30) return;
            sunflower.AddLife();
        }
        ClickReset();
    }

    public void ClickReset(){
        if(sunflower){
            sunflower.ResetLife();
        }
        gameManager.ResetEnemiesDead();
        gameManager.Resume();
    }

}
