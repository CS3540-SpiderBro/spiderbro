using UnityEngine;
using System.Collections;
/// <summary>
/// spawn ccontrol center, mass spawn at first then waves after, randomize spawn locations based on x and z coordinates
/// </summary>
public class spawner : MonoBehaviour {
    public Rigidbody aEnemy;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    public int numEnemies;
    public int activeEnemies;
	public bool SpawnON = true;
    int enemyCount;
    
    // Use this for initialization
    void Start () {       

    }

    // Update is called once per frame
    void Update () {
        
        enemyCount = GameObject.FindGameObjectsWithTag("EnemyUnit").Length;
        Debug.Log(enemyCount);
        if (activeEnemies <= 0 || enemyCount <= 1)
        {
            
            // Do your enemy spawns here
            for (int i = 0; i < numEnemies; i++)
            {                
                SpawnEnemy();
            }
            activeEnemies += numEnemies;
            // Reset for next spawn
           
        }
    }



    public void SpawnEnemy()
    {

        Vector3 newPos = new Vector3(Random.Range(xMin, xMax),250, Random.Range(zMin, zMax));
		Rigidbody aEnemyClone = (Rigidbody) Instantiate(aEnemy, newPos, Quaternion.identity);
        
       
    }

	public void switchSpawn(bool state)
	{
		SpawnON = state;
	}
}
