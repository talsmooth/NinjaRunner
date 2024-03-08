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
        transform.position = Player.Instance.transform.position;

        // Instantiate the initial tiles
        for (int i = 0; i < 14; i++)
        {
            GameObject tempTile = Instantiate(tile, new Vector3(0, 0, i * tileSize), Quaternion.identity);
            tempTile.transform.parent = transform;
            tiles.Add(tempTile);
        }

        tileTotalSize = tileSize * 14; // Update the total size
    }

    void Update()
    {
        for (int i = tiles.Count - 1; i >= 0; i--)
        {
            GameObject tile = tiles[i];

            // Move the tiles based on player state
            if (Player.Instance.isAttacking)
                tile.transform.Translate(Vector3.back * Time.deltaTime * Player.Instance.playerAttackSpeed);
            else
                tile.transform.Translate(Vector3.back * Time.deltaTime * Player.Instance.playerMoveSpeed);

            // Check if the tile is out of view
            if (tile.transform.position.z <= -tileSize *2)
            {
                // Remove and destroy the tile
                tiles.RemoveAt(i);
                Destroy(tile);

                // Spawn a new tile after the last tile
                GameObject lastTile = tiles[tiles.Count - 1];
                float newPositionZ = lastTile.transform.position.z + tileSize;

                GameObject tempTile = Instantiate(tile, new Vector3(0, 0, newPositionZ), Quaternion.identity);
                tempTile.transform.parent = transform;
                tiles.Add(tempTile);
            }
        }
    }


}
