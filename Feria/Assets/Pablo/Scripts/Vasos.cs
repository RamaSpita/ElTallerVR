using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vasos : MonoBehaviour {

	public static int puntos;
    public Vector3 startPosition;
    public Quaternion rotation;
    

	void Awake () 
	{
        startPosition = this.transform.position;
        rotation = this.transform.rotation;
		//GetComponent<Rigidbody>().Sleep();
	}
	


	public void SumaPuntos()
	{
		puntos += 5;
	}


	public void OnCollisionEnter(Collision info)
	{
		if (info.gameObject.CompareTag("Mesa")) 
		{
			SumaPuntos ();

		}

	}


		
}
