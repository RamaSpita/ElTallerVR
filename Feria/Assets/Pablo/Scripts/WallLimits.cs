using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLimits : MonoBehaviour
{
	public GameObject particlesPrefab;
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			var particles = Instantiate (particlesPrefab, collision.transform.position, Quaternion.identity);
			Destroy (collision.gameObject);
			Destroy (particles, 2f);
		}



	}


}
