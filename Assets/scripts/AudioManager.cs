using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sprite soundOff,musicOff,soundOn,musicOn;
    public Image sound,music;



    public AudioSource clickEffect, bgAudioSource, carEngineAudioSource;
    public AudioSource coinSource;
    public AudioSource fuelSource;
    public AudioSource crashSource;

    public AudioClip[] car = new AudioClip[5];
    public AudioClip buttonClickEffetc;
    public AudioClip bgMusic;
    public AudioClip coinSound;
    public AudioClip fuelSound;
    public AudioClip crashSound;

    private bool isSoundOn = true;

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

        //carEngineAudioSource.volume = 0.5f; // Set default volume for car engine sound
    }

    private void Start()
    {

        isSoundOn = PlayerPrefs.GetInt("SoundState", 1) == 1;
        AudioListener.volume = isSoundOn ? 1f : 0f;


        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
        {
            // In level, play car sound based on levelIndex
            int levelIndex = screenManager.instance != null ? screenManager.instance.levelIndex : 1;
            carSound(levelIndex);
        }
        else
        {
            // Home or other scene
            startBG();
        }
    }


    //-----------------------------click sound-------------------------------
    public void playClickEffect()
    {
        if (clickEffect != null && buttonClickEffetc != null)
        {
            clickEffect.volume = 1;
            clickEffect.PlayOneShot(buttonClickEffetc);
            // SceneManager.LoadScene("New Scene 1");
        }
    }

    //------------------------------background music-------------------------------
    public void startBG()
    {
        bgAudioSource.Play();
    }

    public void stopBG()
    {
        bgAudioSource.Stop();
    }

    //------------------------------car engine sound-------------------------------
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
        carEngineAudioSource.clip = car[index - 1];
        print("Car sound index: " + (index - 1));
        carEngineAudioSource.Play();
    }

    //-------------------------------coin sound-------------------------------
    //public void startCoinSound()
    //{
    //    fuelSource.Play();
    //}
    //public void stopCoinSound()
    //{
    //    fuelSource.Stop();
    //}
    public void playCoinSound()
    {
        if (coinSource != null && coinSound != null)
        {
            //coinSource.volume = 1;
            coinSource.PlayOneShot(coinSound);
            //stopCoinSound();
        }
    }

    //--------------------------------fuel sound-------------------------------
    public void playFuelSound()
    {
        if (fuelSource != null && fuelSound != null)
        {
            //fuelSource.volume = 1;
            fuelSource.PlayOneShot(fuelSound);
        }
    }

    //--------------------sound click --------------------------
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        AudioListener.volume = isSoundOn ? 1f : 0f;
        // Optional: Save state
        PlayerPrefs.SetInt("SoundState", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
        sound.sprite = isSoundOn ? soundOn : soundOff;
       

        //sound.sprite = isSoundOn ? soundOff : soundOff; // Assuming soundOff is the sprite for sound on





    }
    // --------------------music----------------------

    public void ToggleMusic()
    {
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            if (!bgAudioSource.isPlaying)
                bgAudioSource.Play();
            
        }
        else
        {
            bgAudioSource.Pause(); // Use Pause instead of Stop to resume later
        }
        PlayerPrefs.SetInt("MusicState", isSoundOn ? 1 : 0);
        music.sprite = isSoundOn ? musicOn : musicOff; // Assuming musicOff is the sprite for music on
        PlayerPrefs.Save();
    }

    public void PlayCrashSound()
    {
        if (crashSource != null && crashSound != null)
        {
            //crashSource.clip = crashSound;
            crashSource.PlayOneShot(crashSound);
            print("hello");
            //crashSource.Play();
            //Invoke("crashStop", 2f);

            ////}
        }
        print("car crash");
    }

    public void crashStop()
    {
        crashSource.Stop();

    }
}