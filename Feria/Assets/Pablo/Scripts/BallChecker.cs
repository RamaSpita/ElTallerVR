using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChecker : MonoBehaviour
{
	


	public void OntriggerExit(Collider collision)
	{
		if (collision.gameObject.CompareTag("Bucket"))
		{
			Spawner.spawner.ballsInBucket--;
		}
	}

}
