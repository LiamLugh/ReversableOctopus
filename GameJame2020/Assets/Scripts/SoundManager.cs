using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMnager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] shootEffects;
    public AudioClip[] pickUpEffects;
    public AudioClip youWinSound;

    public void PlayShootEffect()
    {
        int rand = shootEffects.Length;
        source.Stop();
        source.PlayOneShot(shootEffects[rand]);
    }

    public void PickUpEffect()
    {
        int rand = pickUpEffects.Length;
        source.Stop();
        source.PlayOneShot(pickUpEffects[rand]);
    }

    public void PlayYouWin()
    {
        source.Stop();
        source.PlayOneShot(youWinSound);
    }

}
