using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float enemyChance;
    public List<GameObject> enemies = new List<GameObject>();

    public GameObject item;
    public float itemChance;
    public List<GameObject> items = new List<GameObject>();
    void Start()
    {
        CreateEnemy();
        CreateItem();

    }
    private void OnEnable()
    {
       

    }

    void Update()
    {
        
    }

    public void CreateEnemy()
    {
        int chance = Random.Range(0, 101);
       
        if (chance < enemyChance)
        {

            float randX = Random.Range(-4, 5);
            float randZ = Random.Range(-4, 5);

            Vector3 pos = transform.position + new Vector3(randX, 0, randZ);

            GameObject tempEnemy = Instantiate(enemy, pos, Quaternion.identity);
            tempEnemy.transform.parent = transform;
            
        }
    }


    public void CreateItem()
    {

        int chance = Random.Range(0, 101);

        if (chance < itemChance)
        {

            float randX = Random.Range(-4, 5);
            float randZ = Random.Range(-4, 5);

            Vector3 pos = transform.position + new Vector3(randX, 0.5f, randZ);

            GameObject tempItem = Instantiate(item, pos, Quaternion.identity);
            tempItem.transform.parent = transform;
           

        }


    }

}
