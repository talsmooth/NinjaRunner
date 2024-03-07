using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    public GameObject tile;
    public int tileSize;
    private int tileTotalSize;
    public float tileMoveSpeed;
    public List<GameObject> tiles = new List<GameObject>();
    private Vector3 playerPos;


    void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            GameObject tempTile = Instantiate(tile, new Vector3(0, 0, tileTotalSize), Quaternion.identity);
            tempTile.transform.parent = transform;
            tileTotalSize += tileSize;
            tiles.Add(tempTile);

        }
    }

    void Update()
    {


         playerPos = GameManager.Instance.player.transform.position;
         transform.position = new Vector3(0, 0, playerPos.z);
        

        
        List<GameObject> tilesToRemove = new List<GameObject>(tiles);

        foreach (GameObject tile in tilesToRemove)
        {
            tile.transform.Translate(Vector3.back * Time.deltaTime * tileMoveSpeed);

            if (tile.transform.position.z <= -10)
            {
                tiles.Remove(tile);

                Destroy(tile);

                GameObject tempTile = Instantiate(tile, new Vector3(0, 0, playerPos.z+90), Quaternion.identity);
                tempTile.transform.parent = transform;
                tiles.Add(tempTile);
            }
        }
    

    }



}


