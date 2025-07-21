using UnityEngine;

public class over : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("road"))
        {
            MAIN.isGameRunning = false;
            MAIN.instance.gameOver();
        }

        

        //if (collision.gameObject.name == "gameover check")
        //{
        //    MAIN.isGameRunning = false;
        //    MAIN.instance.gameOverPanel.SetActive(true);
        //}
    }
}
