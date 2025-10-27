using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int speed = 4;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down *  speed * Time.deltaTime);
        if(transform.position.y < -0.8f ) Destroy(gameObject);
    }
}
