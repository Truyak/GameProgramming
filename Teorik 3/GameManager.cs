using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnRate = 1.5f;
    private float nextSpawn = 0.0f;
    public TextMeshProUGUI minutes;
    public TextMeshProUGUI seconds;
    private float gameTime = 0.0f;

    void Update()
    {

        nextSpawn += Time.deltaTime;
        if(nextSpawn >= spawnRate)
        {
            float randomX = Random.Range(-1.2f, 1.2f);
            Vector3 spawnPosition = new Vector3(randomX, 0.6f, 0);
            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            nextSpawn = 0.0f;
        }
        gameTime += Time.deltaTime;
        int min = Mathf.FloorToInt(gameTime / 60F);
        int sec = Mathf.FloorToInt(gameTime - min * 60);
        minutes.text = min.ToString("00");
        seconds.text = sec.ToString("00");

    }
}
