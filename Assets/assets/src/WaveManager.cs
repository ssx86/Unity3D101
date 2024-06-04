using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float countDown = 5f;
    public float waveCountDown = 1f;
    public int waveCount = 3;


    // Update is called once per frame
    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = 5f;
            StartCoroutine(GenerateWave());
        }
    }

    IEnumerator GenerateWave()
    {
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(waveCountDown);
        }
    }
}
