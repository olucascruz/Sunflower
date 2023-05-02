using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private int lifeRoot = 5;
    private bool delayDamage = false;

    

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Caterpillar") && !delayDamage){
            TakeDamage();
        }
    }
    void Update(){
        if(lifeRoot <= 0){
            gameObject.SetActive(false);
        }
    }
    private void OnEnable(){
        lifeRoot = 5;
        delayDamage = false;

    }

    private void TakeDamage(){
        lifeRoot--;
        StartCoroutine(DelayDamage());
    }

    private IEnumerator DelayDamage(){
        delayDamage = true;
        yield return new WaitForSeconds(1f);
        delayDamage = false;
    }


}
