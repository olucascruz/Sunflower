using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    public void EnterGame(){
    SceneManager.LoadScene("GameScene");
   }

   public void QuitGame(){
    Application.Quit();
   }
}
