using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sunflower : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI lifeSunflowerText;
    private int maxLife = 5;
    private int life = 5;
    public int Life{
        get {return life;}
    }
    private bool canTakeDamage = true;
    public static Sunflower instance;    
    
    private int grow = 0;
    public int Grow{
        get {return grow;}
    }
    private GameManager gameManager;
    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start(){
        gameManager = GameManager.instance;
        life = maxLife;
        lifeSunflowerText.text = life.ToString();
    }
    
    public void GrowSunflower(){
        Vector3 position = transform.position;
        position.y += 1f; // adicionar 1 ao eixo Y
        grow += 1;
        transform.position = position;
    }

    public void TakeDamage(){
        if(canTakeDamage){
            life--;
            lifeSunflowerText.text = life.ToString();
            StartCoroutine(DelayDamage());
        }
    }

    public void AddLife(){
        maxLife++;
    }

    private void Update(){
        if(life <= 0 && gameManager.gameState == GameManager.GameState.PLAY){
            gameManager.GameOver();
        }
        if(grow == 11 && gameManager.gameState == GameManager.GameState.PLAY){
            gameManager.Win();
        }
        if(gameManager.gameState == GameManager.GameState.GAMEOVER){
            life = maxLife;
        }

    }

    public void ResetLife(){
        life = maxLife;
        lifeSunflowerText.text = life.ToString();
    }

    private IEnumerator DelayDamage(){
        
        canTakeDamage = false;
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
    }

    void OnEnable(){
        canTakeDamage = true;
    }
}
