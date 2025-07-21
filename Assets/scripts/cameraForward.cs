using UnityEngine;

public class cameraForward : MonoBehaviour
{
    public Transform target; // The target to follow
    Vector3 offset; // Offset from the target's position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
        offset.y = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x = target.position.x + offset.x;
        pos.y = target.position.y + offset.y;
        transform.position = pos;
    }
}
