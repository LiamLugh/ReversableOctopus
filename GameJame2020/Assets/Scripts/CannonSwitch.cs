using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonSwitch : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    public SpriteData[] data;
    public float delayTime = 0.5f;

    public void Enter()
    {
        image.sprite = sprites[1];
        image.rectTransform.sizeDelta = new Vector2(data[1].w, data[1].h);
    }

    public void Exit()
    {
        image.sprite = sprites[0];
        image.rectTransform.sizeDelta = new Vector2(data[0].w, data[0].h);
    }

    public void Fire()
    {
        StartCoroutine(ImageDelay(delayTime));
    }

    IEnumerator ImageDelay(float delay)
    {
        image.sprite = sprites[2];
        image.rectTransform.sizeDelta = new Vector2(data[2].w, data[2].h);

        float timer = 0.0f;

        while(timer < delay)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        image.sprite = sprites[0];
        image.rectTransform.sizeDelta = new Vector2(data[0].w, data[0].h);
    }
}

[System.Serializable]
public struct SpriteData
{
    public float w, h;
}
