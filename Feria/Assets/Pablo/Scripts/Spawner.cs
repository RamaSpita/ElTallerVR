using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public static Spawner spawner;
    public bool isPlaying;
	public Transform spawnPosition;
	public GameObject prefab;
    public int cantBalls;
    public int ballsInBucket;
	public float timeToSpawn;

	void Awake ()
	{
		spawner = this;
        isPlaying = false;
        ballsInBucket = cantBalls;
	}
	
	// Update is called once per frame
	void Update ()
	{

        

        if (ballsInBucket == 0)
        {
            isPlaying = false;
        }
    }


	

	public void Spawn()
	{
		if (cantBalls > 0)
		{
			var balls = Instantiate (prefab);
			balls.transform.position = spawnPosition.position;
			balls.GetComponent<Rigidbody>().AddForce(-spawnPosition.forward * 1f, ForceMode.Impulse);
            
		}


	}

    public IEnumerator SpawnRate()
    {
        for (int i = 0; i < cantBalls; i++)
        {
            Spawn();
            yield return new WaitForSeconds(0.3f);
        }
        yield break;
    }

    

}
