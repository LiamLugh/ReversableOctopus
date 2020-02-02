using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class CreatureSpawner : MonoBehaviour
{
    public LandGenerator lGen;

    public int creatureCount = 4;
    public GameObject[] creatures;
    public float bottomRange = 0.45f;
    public float topRange = 0.5f;
    public int border = 5;
    public float playerRange = -10.0f;
    public Transform player;

    public List<Vector3> spawnLocations = new List<Vector3>();
    public List<Vector3> playerSpawnLocations = new List<Vector3>();

    public MeshCollider collider;

    public void SpawnCreatures()
    {
        //List<Vector3> spawnLocations = new List<Vector3>();
        //List<Vector3> playerSpawnLocations = new List<Vector3>();

        creatureCount = Globals.levelPairCount + 1; 
        /// Scan the map

        int width = lGen.mapWidth;
        int actualWidth = width / 4;
        int height = lGen.mapHeight;
        int actualHeight = height / 4;

        for (int y = -actualHeight + border; y < actualHeight - border; y++)
        {
            for (int x = -actualWidth + border; x < actualWidth - border; x++)
            {
                // Raycast
                RaycastHit hit;
                Ray ray = new Ray(new Vector3(x, 100, y), Vector3.down);

                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if(hit.collider != null)
                    {
                        if (hit.point.y > bottomRange && hit.point.y < topRange) // height band creature
                        {
                            spawnLocations.Add(new Vector3(x, hit.point.y, y));
                        } 
                        else if (hit.point.y < playerRange) // height band player
                        {
                            playerSpawnLocations.Add(new Vector3(x, 0.5f, y));
                        }
                    }
                }
                
            }
        }

        if(spawnLocations.Count < creatureCount * 2)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
            spawnLocations.RemoveAt(0);
            //Spawn creature 1
            GameObject creature2 = Instantiate(creaturePrefab, spawnLocations[0], Quaternion.identity, transform);
            spawnLocations.RemoveAt(0);

            //Peel off clone
            creature1.name = creature1.name.Substring(0, creature1.name.Length - 7);
            creature2.name = creature1.name;
        }

        // Set player start location
        //Debug.Log("Player Spawn count: " + playerSpawnLocations.Count);
        player.position = playerSpawnLocations[Random.Range(0, playerSpawnLocations.Count)];

        //collider.enabled = false;
    }

    
}
