using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private LayerMask sunflowerLayer;
    [SerializeField] private float raycastDistance = 5f;
    [SerializeField] private float forceUp = 5f;

    private Transform sunflowerTrans;
    private Animator anim;
    private bool dead = false;
    private Rigidbody2D rb;
    private bool eating = false;
    private GameManager gameManager;
    private SoundManager soundManager;
    private GameObject[] pointSpawns;
    private Sunflower sunflower;
    private bool isForceLose = false;
    
    void Start()
    {   
        sunflower = Sunflower.instance;
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        sunflowerTrans = GameObject.FindGameObjectWithTag("Sunflower").transform;
        pointSpawns = GameObject.FindGameObjectsWithTag("Spawn");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
        if(!sunflower && !sunflowerTrans) return;
        if (transform.position.x < sunflowerTrans.position.x)
        {
                transform.rotation = Quaternion.Euler(0, 0, 0); // olhar para a direita
        }
        else
        {
                transform.rotation = Quaternion.Euler(0, 180, 0); // olhar para a esquerda
        }
     
        float distance = Vector2.Distance(transform.position, sunflowerTrans.position);

        Ray2D ray = new Ray2D(transform.position, transform.right);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance, sunflowerLayer);
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        if(gameManager.gameState == GameManager.GameState.PLAY){
            if (distance > 0.5f && !dead && !hit)
            {
                if(sunflower.Grow == 0 && gameManager.EnemiesDead == 50 && !isForceLose){
                    speed = speed * 3;
                    isForceLose = true;
                }
                transform.position = Vector2.MoveTowards(transform.position, sunflowerTrans.position, speed * Time.deltaTime);
            }else{
                if(!eating && hit && !dead){
                    eating = true;
                    StartCoroutine(isEating());
                    }
            }
        }   
    }

    IEnumerator isEating(){
        while(eating && gameManager.gameState == GameManager.GameState.PLAY){
            rb.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);
            sunflower.TakeDamage();
            yield return new WaitForSeconds(0.5f);    
        }
    }

    void OnEnable(){
        if(anim){
            eating = false;
            anim.SetBool("Dead", false);
            int randomVelocity = Random.Range(2, 6);
            speed = randomVelocity;
            int randomPoint = Random.Range(0, 2);
            transform.position = pointSpawns[randomPoint].transform.position;
            speed = speed + (sunflower.Grow * 0.5f);
        }
    }

    void OnMouseDown()
    {
        if(Application.isMobilePlatform)return;

        Dead();
    }

    IEnumerator Desactive(){
        yield return new WaitForSeconds(1f);
        dead = false;
        gameManager.EnemyDead();
        gameObject.SetActive(false);
    }

    public void Dead(){
        if(gameManager.gameState == GameManager.GameState.PLAY){
            dead = true;
            soundManager.SmashBug();
            anim.SetBool("Dead", true);
            StartCoroutine(Desactive());
        }
    }
    
}
