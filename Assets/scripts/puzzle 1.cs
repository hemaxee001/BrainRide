using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class puzzle1 : MonoBehaviour
{
    [SerializeField] Text countDigit;
    string answer = "3";
    public Text correctText, incorrectText;
    public GameObject correctPanel, incorrectPanel;
    //public bool isCorrect = false;

    public static puzzle1 instance;
   // public Image levelImage;
    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        AudioManager.instance.carEngineAudioSource.Stop();

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void submit()
    {

        if (countDigit.text == answer)
        {
            correctPanel.SetActive(true);
            correctText.text = "Correct!";
            incorrectPanel.SetActive(false);

            //isCorrect = true;
            print("Correct answer! Proceeding to the next level." +screenManager.instance.levelIndex);
            // Set the level index to 1 for the next level

            //next_bt.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
            incorrectText.text = "Incorrect! Try again.";
            correctPanel.SetActive(false);
        }
        countDigit.text = "";

    }
    public void click1()
    {
        countDigit.text += "1";
    }
    public void click2()
    {
        countDigit.text += "2";
    }
    public void click3()
    {
        countDigit.text += "3";
    }
    public void click4()
    {
        countDigit.text += "4";
    }
    public void click5()
    {
        countDigit.text += "5";
    }
    public void click6()
    {
        countDigit.text += "6";
    }
    public void click7()
    {
        countDigit.text += "7";
    }
    public void click8()
    {
        countDigit.text += "8";
    }
    public void click9()
    {
        countDigit.text += "9";
    }
    public void click0()
    {
        countDigit.text += "0";
    }
    public void ClickC()
    {
        //string v = temp123.text.Substring(0);
        int v1 = countDigit.text.Length - 1;
        countDigit.text = countDigit.text.Substring(0, v1);
    }
    public void Reset()
    {
        countDigit.text = "";
        correctPanel.SetActive(false);
        incorrectPanel.SetActive(false);
    }
    public void nextBt()
    {
        int nextLevel = screenManager.instance.levelIndex + 1;

        // Unlock next level
        int currentUnlocked = PlayerPrefs.GetInt("LevelUnlocked", 1);
        if (nextLevel > currentUnlocked)
        {
            PlayerPrefs.SetInt("LevelUnlocked", nextLevel);
            PlayerPrefs.Save();
        }
        AudioManager.instance.carSound(nextLevel);
        SceneManager.LoadScene("Level-" + nextLevel);

    }
}
