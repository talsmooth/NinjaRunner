using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class TileSpawner2 : MonoBehaviour
{

    public GameObject tile;
    public int tileSize;
    private int tileTotalSize;
    public float tileMoveSpeed;
    public float currentPos;
    public float nextPos;
    public List<GameObject> tiles = new List<GameObject>();
    Vector3 playerPos;


    void Start()
    {
        currentPos = transform.position.z;
        nextPos = currentPos + 10;

        for (int i = 0; i < 11; i++)
        {

            GameObject tempTile = Instantiate(tile, new Vector3(0, 0, tileTotalSize), Quaternion.identity);
            //tempTile.transform.parent = transform;
            tileTotalSize += tileSize;
            tiles.Add(tempTile);

        }
    }

    void Update()
    {


        playerPos = Player.Instance.transform.position;
        transform.position = new Vector3(0, 0, playerPos.z);


        if (transform.position.z >= nextPos)
        {
            GameObject tempItem = Instantiate(tile, new Vector3(0, 0, nextPos + 100), Quaternion.identity);
            //tempItem.transform.parent = transform;
            tiles.Add(tempItem);
            nextPos += 10;




        }

    }
}



