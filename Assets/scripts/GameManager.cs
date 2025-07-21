using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

   public GameObject[] levels;

    GameObject currentLevel;

  //  public GameObject gamePlayObj, carObj;
   // public Sprite[] LevelImage;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void startGamePlay(int level)
    {
       // AudioManager.instance.stopBG();
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        // levels[level].tranform.position
        currentLevel = Instantiate(levels[level], Vector3.zero, Quaternion.identity);
    }

}