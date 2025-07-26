using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        screenManager.instance.restartGame();
    }
    public void NextLevel()
    {
        screenManager.instance.nextLevel();
    }
    public void LevelSelection()
    {
        //AudioManager.instance.crashSource.Stop();
        //StartCoroutine(ScreenManager.instance.ShowLoadAndShowLevelSelection());
        screenManager.instance.ShowLoadAndShowLevelSelection();
    }
}
