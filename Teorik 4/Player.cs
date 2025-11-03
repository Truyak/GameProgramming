using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100;

    public float speed = 5;
    private float horizontalInput;
    private float verticalInput;
    public GameObject laserPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
        if(transform.position.y > -2)
        {
            transform.position = new Vector3(transform.position.x, -2, transform.position.z);
        }
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
        if(transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, transform.position.z);
        }
    }

    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
    }

    public void TakeDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            GameManager.instance.isGameOver = true;
            health = 0;
        }
        if (health > 100)
        {
            health = 100;
        }
    }
}
