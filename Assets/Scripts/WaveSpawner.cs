using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;

    
    //wave, time
    public float timeBetweenWaves = 5f;
    private float countdown = 2;
    public Text waveCountdownText;
    private int waveIndex = 1;

    public float timeBetweenEnemySpawnsInWave = 0.5f;


    void Update()
    {
        if (countdown <= 0f)
        {
            // IEnumerator call
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        //minus 1 every sec
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }
    //wait
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemySpawnsInWave);
        }
        waveIndex++;
    }
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }

}
