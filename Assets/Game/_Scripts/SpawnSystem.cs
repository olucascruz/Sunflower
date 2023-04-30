using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem instance;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxEnemys;
    [SerializeField] private Transform[] spawn;

    public List<GameObject> enemys;
    private bool isSpawn = false;
    void Awake(){
        if (instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        enemys = new List<GameObject>();
        StartCoroutine(InitialInstanciete());
    }

    private IEnumerator InitialInstanciete(){
        for(int i = 0; i< maxEnemys; i++){
            int index = 0;
            if(i < maxEnemys/2){
                index = 0;
            }else{
                index = 1;
            }

            GameObject enemy = Instantiate(prefab, spawn[index].position, Quaternion.identity);


            enemy.SetActive(false);
            enemys.Add(enemy);
            yield return new WaitForSeconds(0.05f);
        }

    }

    public void Spawner(float time){
        if(enemys.Count == maxEnemys){
            if(isSpawn == false){
            isSpawn = true;
            StartCoroutine(CoroutineSpawner(time));
            }
        }
    } 
    
    public void StopSpawner(){
        isSpawn = false;
        foreach (var i in enemys)
        {
            i.SetActive(false);
        }
    }

    private IEnumerator CoroutineSpawner(float time){
        while(isSpawn){
            int randomIndex = Random.Range(0, enemys.Count);    
            enemys[randomIndex].SetActive(true);
            yield return new WaitForSeconds(time);
        }
    }
}
