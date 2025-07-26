using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public ParticleSystem ps;
    public static TestScript instance; // Singleton instance
    private void Awake()
    {
        instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision detected with:::::::::::::::::: " + collision.gameObject.name + " ---->  " + gameObject.name);
        if (ps != null)
        {
            ps.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (ps != null)
        {
            ps.Stop();
        }
    }

}
