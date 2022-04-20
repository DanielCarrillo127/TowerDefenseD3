using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Wave
{
    //Nombre de la oleada
    public string waveName;
    //cantidad de enemigos a spawnear
    public int noOfEnemies;
    //intervalo de spawn
    public float spawnInterval;
    //tipos de enemigos a spawnear
    public GameObject[] typeOfEnemies;
    //tipos de enemigos a spawnear
    public GameObject[] typeOfEnemies2;
}
public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Wave[] waves;
    //Puntos de spawn
    public Transform[] spawnpoints;
    //dicen en que oleada estamos
    private Wave currentWave;
    private int currentWaveNumber;

    //tiempo entre spawns de enemigos
    private float nextSpawnTime;
    //revisa si puede spawnear el enemigo
    private bool canSpawn = true;

    //Cuantos segundos hay entre oleadas
    public float timeRemaining = 10;
    // revisa si el tiempo se acabo
    public bool timerIsRunning = false;

    //muestra en el canvas
    public string enemtxt;
    public Text enemElem;

    public string timetxt;
    public Text TimeElem;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        //tomara lista de los enemigos spawneados
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemElem.text = "  " + currentWave.noOfEnemies.ToString();
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            TimeElem.text = " " + (int)timeRemaining + " ";
            timerIsRunning = true;
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    Debug.Log("Countdown: " + timeRemaining);
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 10;
                    timerIsRunning = false;
                    spawnNextWave();
                }
            }

        }
    }

    void spawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            //spawnea un enemigo aleatorio a un punto aleatorio
            int random = Random.Range(0, currentWave.typeOfEnemies.Length);
            if (random == 0)
            {
                GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
                Transform randompoint = spawnpoints[0];
                Instantiate(randomEnemy, randompoint.position, Quaternion.identity);
            }
            else
            {
                GameObject randomEnemy = currentWave.typeOfEnemies2[Random.Range(0, currentWave.typeOfEnemies2.Length)];
                Transform randompoint = spawnpoints[1];
                Instantiate(randomEnemy, randompoint.position, Quaternion.identity);
            }
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
            }
        }

    }

}

