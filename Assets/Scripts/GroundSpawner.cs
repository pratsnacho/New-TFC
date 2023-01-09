using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroundSpawner : MonoBehaviour
{
    public List<GameObject> Items;
    public List<GameObject> ItemsSafe;
    Vector3 nextSpawnPoint = new Vector3( 0, 0, -5);
    public Vector3 direction;
    public float speed = 5;
    public float increment = 0.2f;

    public List<Transform> instanced = new List<Transform>();

    public void SpawnTile()
    {
        GameObject temp = Instantiate(Items[Random.Range(0, Items.Count)], nextSpawnPoint, Quaternion.identity, transform);
        nextSpawnPoint.z += 10;

    }

    public void SpawnTileSafe()
    {
        GameObject temp = Instantiate(ItemsSafe[Random.Range(0, ItemsSafe.Count)], nextSpawnPoint, Quaternion.identity, transform);
        nextSpawnPoint.z += 10;

    }

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i < 3)
                SpawnTileSafe();

            else
                SpawnTile();
        }
    }
}