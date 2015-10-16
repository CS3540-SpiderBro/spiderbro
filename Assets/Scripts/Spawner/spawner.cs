using UnityEngine;
using System.Collections;
/// <summary>
/// spawn ccontrol center, mass spawn at first then waves after, randomize spawn locations based on x and z coordinates
/// </summary>
public class spawner : MonoBehaviour {
    public GameObject aEnemy;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    public int yMax;
    public int numEnemies;
    public int activeEnemies;
	public bool SpawnON = true;
    public int rotateY;
    int enemyCount;
    
    // Use this for initialization
    void Start () {       

    }

    // Update is called once per frame
    void Update () {
        
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
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

        Vector3 newPos = new Vector3(Random.Range(xMin, xMax), yMax, Random.Range(zMin, zMax));
        //Debug.Log(newPos);
		GameObject aEnemyClone = (GameObject) Instantiate(aEnemy, newPos, transform.rotation * Quaternion.Euler(0, rotateY, 0));
        
       
    }

	public void switchSpawn(bool state)
	{
		SpawnON = state;
	}
}
