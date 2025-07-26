using UnityEngine;

public class over : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("road"))
        {
            MAIN.isGameRunning = false;
            MAIN.instance.gameOver();
        }
    }
}
