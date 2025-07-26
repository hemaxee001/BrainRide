using UnityEngine;

public class DynamicBackground : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -20f) // Off-screen? destroy it
        {
            Destroy(gameObject);
        }
    }
}
