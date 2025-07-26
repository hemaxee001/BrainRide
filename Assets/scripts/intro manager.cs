using UnityEngine;

public class intromanager : MonoBehaviour
{
    public GameObject intro1, intro2;

    private void Start()
    {
        Invoke("openIntro2", 1.20f);
    }

    void openIntro2()
    {
        intro1.SetActive(false);
        intro2.SetActive(true);
        Invoke("startGame", 2.30f);
    }

    void startGame()
    {

        gameObject.SetActive(false);

        screenManager.instance.ShowHome();

    }

}
