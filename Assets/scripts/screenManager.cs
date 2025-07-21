using UnityEngine;
using UnityEngine.SceneManagement;

public class screenManager : MonoBehaviour
{

    public GameObject home, levelSelection;
    public static screenManager instance;

    public  int levelIndex = 1;
    public static string directShowScreen = "";

    private void Awake()
    {
        //print("=====Awake instance : " + instance);
        //print("=====Awake isShowLevelSelection : " + isShowLevelSelection);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (directShowScreen != "")
            {

                switch (directShowScreen)
                {
                    case "home":
                        intromanager.instance.gameObject.SetActive(false);
                        levelSelection.SetActive(false);
                        ShowHome();
                        break;
                    case "levelSelection":
                        ShowLevelSelection();
                        break;
                }

                directShowScreen = "";
            }
        }
    }
   
    public void ShowHome()
    {
        
        home.SetActive(true);
        levelSelection.SetActive(false);
    }
    
    public void ShowLevelSelection()
    {
        print("ShowLevelSelection ::  home -> " + home);
        print("ShowLevelSelection ::  levelSelection -> " + levelSelection);
        intromanager.instance.gameObject.SetActive(false);
        home.SetActive(false);
        levelSelection.SetActive(true);
    }
   
    public void ShowLevel(int level)
    {
        levelIndex = level;
        SceneManager.LoadScene("Level-" + level);
    }
    internal void nextLevel()
    {
        ShowLevel(levelIndex + 1);
    }
    internal void restartGame()
    {
        ShowLevel(levelIndex);
    }
    //internal IEnumerator ShowLoadAndShowLevelSelection()
    //{
    //    isShowLevelSelection = true;
    //    yield return SceneManager.LoadSceneAsync("MainPage");
    //}
    internal void ShowLoadAndShowLevelSelection()
    {
        directShowScreen = "levelSelection";
        SceneManager.LoadScene("homeLevelscreen");
    }
    internal void ShowLoadAndHome()
    {
        directShowScreen = "home";
        SceneManager.LoadScene("homeLevelscreen");
    }
    public void PlayGame()
    {
        AudioManager.instance.stopBG();
        int unlockedLevel = PlayerPrefs.GetInt("LevelUnlocked", 1); // Default to Level-1
        ShowLevel(unlockedLevel); // Loads the next unlocked level
        AudioManager.instance.carSound(unlockedLevel); // Play car sound for the level
    }

}
