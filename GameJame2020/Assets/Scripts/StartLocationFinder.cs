using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLocationFinder : MonoBehaviour
{
    public LandGenerator landGen;
    public Transform startLocation;

    public Vector3 GetStartLocation()
    {
        Vector3 target = Vector3.zero;
        float[,] noiseMap = landGen.GetNoiseMap();

        int mapWidth = noiseMap.GetLength(0);
        int mapHeight = noiseMap.GetLength(1);

        int halfWidth = mapWidth / 2;
        int halfHeight = mapHeight / 2;

        int checkRange = 5;

        for (int x = halfWidth - checkRange; x < halfWidth + checkRange; x++)
        {
            for (int y = halfHeight - checkRange; y < halfHeight + checkRange; y++)
            {
                if((x >= 0) && (x < mapWidth) && (y >= 0) && (y < mapHeight))
                {
                    if(noiseMap[x,y] < 0.5f)
                    {
                        target = new Vector3(x, 1.0f, y);
                        startLocation.transform.position = target;
                        return target;
                    }
                }
            }
        }

        return target;
    }
}
