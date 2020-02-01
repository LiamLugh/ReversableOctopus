using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class CreatureSpawner : MonoBehaviour
{
    public int creatureCount = 4;
    public GameObject[] creatures;
    public float bottomRange = 0.45f;
    public float topRange = 0.5f;
    public int border = 10;

    public List<Vector3> spawnLocations;

    public void SetSpawnLoactions(List<Vector3> list)
    {
        spawnLocations = list;
    }

    public void SpawnCreatures(float[,] noiseMap)
    {
        List<Vector3> spawnPositions = new List<Vector3>();

        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float f = noiseMap[x, y];

                // border location cull
                if((x >= border && x < width-border) && (y >= border && y <= height-border))
                {
                    if (f > bottomRange && f < topRange) // height band
                    {
                        spawnLocations.Add(new Vector3((x - 100) / 2, f / 2, (y - 100) / 2));
                    }
                }
            }
        }

        // Shuffle List
        for (int i = 0; i < spawnLocations.Count; i++)
        {
            Vector3 temp = spawnLocations[i];
            int randomIndex = Random.Range(i, spawnLocations.Count);
            spawnLocations[i] = spawnLocations[randomIndex];
            spawnLocations[randomIndex] = temp;
        }

        for (int i = 0; i < creatureCount; i++)
        {
            // creature to spawn 2 of
            GameObject creaturePrefab = creatures[Random.Range(0,creatures.Length)];

            //Spawn creature 1
            GameObject creature1 = Instantiate(creaturePrefab, spawnLocations[0], Quaternion.identity, transform);
            //Spawn creature 1
            GameObject creature2 = Instantiate(creaturePrefab, spawnLocations[1], Quaternion.identity, transform);

            spawnLocations.RemoveAt(0);
            spawnLocations.RemoveAt(0);
        }
    }

    
}
