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


    private Transform sunflower;
    private Animator anim;
    private bool dead = false;
    private Rigidbody2D rb;
    private bool eating = false;
    void Start()
    {
        sunflower = GameObject.FindGameObjectWithTag("Sunflower").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     
        float distance = Vector2.Distance(transform.position, sunflower.position);

        Ray2D ray = new Ray2D(transform.position, transform.right);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance, sunflowerLayer);

        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        if (distance > 0.5f && !dead && !hit)
        {
            transform.position = Vector2.MoveTowards(transform.position, sunflower.position, speed * Time.deltaTime);
        }else{
            if(!eating){
                eating = true;
                StartCoroutine(isEating());
                }
        }   
    }

    IEnumerator isEating(){
        while(eating){
            rb.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);    
        }
    }

    void OnEnable(){
        if(anim){
            anim.SetBool("Dead", false);
        }
    }

    void OnMouseDown()
    {
        dead = true;
        anim.SetBool("Dead", true);
        StartCoroutine(Desactive());
    }

    IEnumerator Desactive(){
        yield return new WaitForSeconds(1f);
        dead = false;
        gameObject.SetActive(false);
    }



}
