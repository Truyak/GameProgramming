using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10.0f;
    void Start()
    {
        Destroy(gameObject, 3.0f);
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
