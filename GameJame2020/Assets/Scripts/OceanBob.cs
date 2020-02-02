using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanBob : MonoBehaviour
{
    bool down = true;
    public float startHeight;
    Vector3 startPos;
    public float endHeight;
    Vector3 endPos;
    public float duration;
    public float waitTime;
    public Transform player;

    void Start()
    {
        //waitTime = Globals.time - duration;
        startPos = Vector3.one * startHeight;
        endPos = Vector3.one * endHeight;
        StartCoroutine(StartBobbing(duration));
    }

    IEnumerator StartBobbing(float duration)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / duration));
            player.position = new Vector3(player.position.x, transform.position.y, player.position.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Make sure we got there
        transform.position = endPos;

        /*
        elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Make sure we got there
        transform.position = startPos;

        StartCoroutine(StartBobbing(halfDuration));
        */

        yield return null;
    }
}
