using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public enum GameState {PLAY, PAUSE, GAMEOVER, WIN};
    public GameState gameState = GameState.PLAY;
    private SpawnSystem spawnSystem;
    private int enemiesDead = 0;
    public int EnemiesDead{
        get {return enemiesDead;}
    }

    [SerializeField] private TextMeshProUGUI enemiesDeadText;
    [SerializeField] private GameObject evolution;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject sunflower;

    
    private void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void EnemyDead(){
        enemiesDead++;
        enemiesDeadText.text = enemiesDead.ToString();
    }

    public void ResetEnemiesDead(){
        enemiesDead = 0;
    }

    public void Pause(){
        gameState = GameState.PAUSE;
    }

    public void Resume(){
        gameState = GameState.PLAY;
        sunflower.SetActive(true);

    }

    public void GameOver(){
        gameState = GameState.GAMEOVER;
        sunflower.SetActive(false);
    }

    public void Win(){
        gameState = GameState.WIN;
    }

    private void Start(){
        spawnSystem = SpawnSystem.instance;
        enemiesDeadText.text = enemiesDead.ToString();
    }

    private void Update()
    {
        if(gameState == GameState.PLAY){

            spawnSystem.Spawner(0.5f);
        }

        if(gameState == GameState.GAMEOVER){
            spawnSystem.StopSpawner();
            evolution.SetActive(true);
        }else{
            evolution.SetActive(false);
        }

        if(gameState == GameState.WIN){
            win.SetActive(true);
        }
    }

    public void Quit(){
        SceneManager.LoadScene("MenuScene");
    }
}
