using UnityEngine;

public class levelSelection : MonoBehaviour
{
    public static levelSelection instance; // Singleton instance
    public LevelData[] levels; // Array to hold level data
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void startLevel(int level)
    {
        GameManager.instance.startGamePlay(level);
      
        gameObject.SetActive(false);
    }
}
