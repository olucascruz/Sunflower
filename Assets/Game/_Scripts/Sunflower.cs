using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    private int life = 5;
    public int Life{
        get {return life;}
    }
    private bool canTakeDamage = true;
    public static Sunflower instance;    
    
    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(){
        if(canTakeDamage){
            life--;
            StartCoroutine(DelayDamage());
        }
    }

    private IEnumerator DelayDamage(){
        
        canTakeDamage = false;
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
    }
}
