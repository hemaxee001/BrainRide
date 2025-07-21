using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public ParticleSystem ps;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision detected with:::::::::::::::::: " + collision.gameObject.name + " ---->  " + gameObject.name);
        if (ps != null)
        {
            ps.Play();
        }
        //if(gameObject.name == "gameover check"){
        //    MAIN.isGameRunning = false;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (ps != null)
        {
            ps.Stop();
        }
    }

}
