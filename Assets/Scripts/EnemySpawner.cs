using UnityEngine;
using System.Collections;
using MarchingBytes;

public class EnemySpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GameObject enemy = null;
    [SerializeField]
    private int enemySpawnTime = 5;
    [SerializeField]
    private int xMin = -10;
    [SerializeField]
    private int xMax = 10;
    [SerializeField]
    private int zMin = -10;
    [SerializeField]
    private int zMax = 10;
    private bool canSpawn = false;
    private int spawnPointX;
    private int spawnPointY;
    private int spawnPointZ;
    public string poolName;
    #endregion

    #region Unity Events
    private void Start()
    {
        if (enemy != null)
        {
            canSpawn = true;
            StartCoroutine(InitialSpawn());
            StartCoroutine(Spawn());
        }
    } 
    #endregion

    private IEnumerator Spawn()
    {
        while (canSpawn)
        {
            spawnPointX = Random.Range(xMin, xMax);
            spawnPointY = 1;
            spawnPointZ = Random.Range(zMin, zMax);
            Vector3 spawnPoint = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
            EasyObjectPool.instance.GetObjectFromPool(poolName, spawnPoint, Quaternion.Euler(270, 0, 0));
            //Instantiate(enemy, spawnPoint, Quaternion.Euler(270,0,0));
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }
    private IEnumerator InitialSpawn()
    {
        
            for (int i = 0; i < 2; i++)
            {
                spawnPointX = Random.Range(xMin, xMax);
                spawnPointY = 1;
                spawnPointZ = Random.Range(zMin, zMax);
                Vector3 spawnPoint = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
                EasyObjectPool.instance.GetObjectFromPool(poolName, spawnPoint, Quaternion.Euler(270, 0, 0));
            } 
            yield return new WaitForSeconds(enemySpawnTime);
        
    }
}
