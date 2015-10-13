using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour 
{

	const int MAX_HP = 500;

	public static int hp = 100;
	public int xp;
	public bool is_alive;

	// Use this for initialization
	void Start () 
	{
		hp = 100;	//set life to 100
		xp = 25;	//xp to be worth
		is_alive = true;
	}

	public int checkHP()
	{
		return hp;
	}

	public void changeHP(int change)
	{
		hp = change;
	}
	
	// Update is called once per frame
	void Update () 
	{


		/*if (hp < 1) 
		{
			is_alive = false;	//cannot damage/kill/interact with objects that are not alive
			//play death sound

			//give player xp
			Destroy (gameObject, 0);	//destroy enemy after 5 seconds
		}*/



	}
}
