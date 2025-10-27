using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 1 * speed, 0);
    }

    void Update()
    {
        if(transform.position.y >= 1f)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
