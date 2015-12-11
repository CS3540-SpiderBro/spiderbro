using UnityEngine;
using System.Collections;
/// <summary>
/// spawn ccontrol center, mass spawn at first then waves after, randomize spawn locations based on x and z coordinates
/// </summary>
public class spawner : MonoBehaviour {
    public GameObject aEnemy;
   
    public int numEnemies;
    public int spawntime = 5;
    public bool SpawnON = true;
    public int rotateY;
    public GameObject SpawnBaseObject;
    int enemyCount;
    public Transform spawnOrigin;
    
    // Use this for initialization
    void Start () {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void FixedUpdate () {
        
       
    }

    IEnumerator spawn()
    {

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyCount);
        
        while (true)
        {
            yield return new WaitForSeconds(spawntime);
            for (int i = 0; i < numEnemies; i++)
            {
                yield return new WaitForSeconds(1);
                SpawnEnemy();
            }           
        }
    }
   

    public void SpawnEnemy()
    {
        //var origTr = spawnOrigin.transform.position;
        GameObject aEnemyClone = (GameObject) Instantiate(aEnemy, SpawnBaseObject.transform.position, transform.rotation * Quaternion.Euler(0, rotateY, 0));
    }

    public void switchSpawn(bool state)
    {
        SpawnON = state;
    }
}
