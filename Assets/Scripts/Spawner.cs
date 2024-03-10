using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float enemyChance;
    public List<GameObject> enemies = new List<GameObject>();

    public GameObject upgradeBox;
    public float upgradeBoxChance;
    public List<GameObject> items = new List<GameObject>();

    public GameObject laserWall;
    public float laserWallChance;

    void Start()
    {
        CreateEnemy();
        CreateUpgradeBox();
        CreateLaserWall();

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

            Vector3 pos = transform.position + new Vector3(randX, 0.6f, randZ);

            GameObject tempEnemy = Instantiate(enemy, pos, Quaternion.identity);
            tempEnemy.transform.parent = transform;
            
        }
    }


    public void CreateUpgradeBox()
    {

        int chance = Random.Range(0, 101);

        if (chance < upgradeBoxChance)
        {

            float randX = Random.Range(-4, 5);
            float randZ = Random.Range(-4, 5);

            Vector3 pos = transform.position + new Vector3(randX, 1f, randZ);

            GameObject tempItem = Instantiate(upgradeBox, pos, Quaternion.identity);
            tempItem.transform.parent = transform;
           

        }


    }


    public void CreateLaserWall()
    {

        int chance = Random.Range(0, 101);

        if (chance < laserWallChance)
        {

            int randomIndex = Random.Range(0, 2);

            

            if (randomIndex == 0)
            {
                Vector3 pos = transform.position + new Vector3(2.5f, 0f, 0);

                GameObject tempItem = Instantiate(laserWall, pos, Quaternion.identity);

                tempItem.transform.parent = transform;

            }

            else
            {

                Vector3 pos = transform.position + new Vector3(-2.5f, 0f, 0);

                GameObject tempItem = Instantiate(laserWall, pos, Quaternion.identity);

                tempItem.transform.parent = transform;

            }


        }


    }

}
