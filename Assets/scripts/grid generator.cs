using UnityEngine;
using UnityEngine.UI;

public class gridgenerator : MonoBehaviour
{
    public static gridgenerator instance; // Singleton instance

    public GameObject gridPrefab; // Prefab for the grid

    //Image[] completeArray;
    private void Awake()
    {
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

        int maxUnlockedLevel = PlayerPrefs.GetInt("LevelUnlocked", 1); // Default 1
        for (int i = 0; i < 7; i++)
        {
            print("Creating grid for level: " + (i));

            var clone = Instantiate(gridPrefab, transform);
            var bt = clone.GetComponent<Button>();
            var tx = bt.GetComponentInChildren<Text>();
            var img = clone.GetComponent<Image>();

            tx.text = (i + 1).ToString();

           
            int levelIndex = i;
            // Lock/unlock based on PlayerPrefs
            if (levelIndex + 1 <= maxUnlockedLevel)
            {
                bt.interactable = true;
                img.color = Color.white;
                tx.color = Color.black;
            }
            else
            {
                bt.interactable = false;
                img.color = Color.gray;
                tx.color = Color.white;
            }

            bt.onClick.AddListener(() => {
                AudioManager.instance.stopBG();
                AudioManager.instance.carSound(levelIndex+1);
                screenManager.instance.ShowLevel(levelIndex + 1);
            });
            print("Creating grid for level: " + (i));
        }
    }
    
}
