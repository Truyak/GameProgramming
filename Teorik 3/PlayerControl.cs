using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 1.3f;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    private float delayTime = 1f;
    public float lastShootTime = 0f;
    public float health = 100f;
    public TextMeshProUGUI healthUI;

    private void Start()
    {
        healthUI.text = health.ToString("F0");
    }
    void Update()
    {
        lastShootTime += Time.deltaTime;
        Move();
        if(Keyboard.current.spaceKey.wasPressedThisFrame && lastShootTime >= delayTime)
        {
            Shoot();
        }
    }
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -0.7f, -0.4f),0);
        transform.position = (Mathf.Abs(transform.position.x) >= 1.6f) ? new Vector3(-transform.position.x, transform.position.y, 0) : transform.position;
        transform.Translate(new Vector3(moveX, moveY, 0));
    }

    private void Shoot()
    {
        Transform shootTransform = shootPoint != null ? shootPoint : transform;
        Instantiate(bulletPrefab, shootTransform.position, Quaternion.identity);
        lastShootTime = 0f;
    }

    public void UpdateHealth(float amount)
    {
        health += amount;
        if(health > 100f)
        {
            health = 100f;
        }
        healthUI.text = health.ToString("F0");
        if (health <= 0f)
        {
            health = 0f;
            healthUI.text = health.ToString("F0");
            Debug.Log("Player Dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            UpdateHealth(-10f);
            Destroy(other.gameObject);
        }
    }


}
