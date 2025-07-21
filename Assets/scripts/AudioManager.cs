using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource clickEffect, bgAudioSource, carEngineAudioSource;
    public AudioClip[] car = new AudioClip[5] ; 
    public AudioClip buttonClickEffetc;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playClickEffect()
    {
        if (clickEffect != null && buttonClickEffetc != null)
        {
            clickEffect.volume = 1;
            clickEffect.PlayOneShot(buttonClickEffetc);
            // SceneManager.LoadScene("New Scene 1");
        }
    }

    public void startBG()
    {
        bgAudioSource.Play();
    }

    public void stopBG()
    {
        bgAudioSource.Stop();
    }
    //public void startCarEngine()
    //{
    //    if (carEngineAudioSource != null)
    //    {
    //        carEngineAudioSource.volume = 0;
    //        carEngineAudioSource.Play();
    //    }
    //}
    public void startCarEngine()
    { 
           carEngineAudioSource.Play();
    }
    public void stopCarEngine()
    { 
            carEngineAudioSource.Stop();  
    }

    public void carSound(int index)
    {
        carEngineAudioSource.clip = car[index-1];
          print("Car sound index: " + (index-1));
        carEngineAudioSource.Play();
    }
}
