using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms.Impl;

public class stick : MonoBehaviour
{
    //private GameObject stick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float normalMass = 0.001f;
    public float heavyMass = 1f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = normalMass;
    }
    public void lessMass()
    {
        rb.mass = normalMass;
    }
    public void moreMass()
    {
        rb.mass = heavyMass;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("arrow"))
    //    {
    //        //Destroy(collision.gameObject);
    //        print(collision.gameObject.CompareTag("arrow"));
    //        rb.mass = normalMass;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("arrow"))
    //    {
    //        //Destroy(collision.gameObject);
    //        print(collision.gameObject.CompareTag("arrow"));
    //        rb.mass = heavyMass;
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("arrow"))
    //    {
    //        //Destroy(collision.gameObject);
    //        print(collision.gameObject.CompareTag("arrow"));
    //        rb.mass = normalMass;
    //    }
    //}
    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("arrow"))
    //    {
    //        //Destroy(collision.gameObject);
    //        print(collision.gameObject.CompareTag("arrow"));
    //        rb.mass = heavyMass;
    //    }

    //}
    void Update()
    {

    }
}
