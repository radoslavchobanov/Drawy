using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip CannonShootSound;
    public AudioClip CannonBurningSound;
    public AudioClip CompleteSound;
    public AudioClip FailSound;
    public AudioClip CoinPick;

    public void PlaySound(AudioClip sound)
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(sound, 1f);
    }

    public void TogglePause()
    {
        if (AudioSource.isPlaying == true) AudioSource.Pause();
        else AudioSource.UnPause();
    }
}
