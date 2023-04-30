using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public enum GameState {PLAY, PAUSE, GAMEOVER};
    public GameState gameState = GameState.PLAY;
    private SpawnSystem spawnSystem;
    private int enemiesDead = 0;
    [SerializeField] private TextMeshProUGUI enemiesDeadText;
    
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

    public void Pause(){
        gameState = GameState.PAUSE;
    }

    public void Resume(){
        gameState = GameState.PLAY; 
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
    }
}
