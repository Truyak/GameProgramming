using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;
    public float spawnInterval = 2.0f;
    private float timer = 0.0f;
    public bool isGameOver = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        timer += Time.deltaTime;
        if (timer >= spawnInterval && !isGameOver)
        {
            RandomSpawnEnemy();
            timer = 0.0f;
        }
    }

    void RandomSpawnEnemy()
    {
        float xPosition = Random.Range(-8.0f, 8.0f);
        Vector3 spawnPosition = new Vector3(xPosition, 3.0f, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
