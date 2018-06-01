using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    // Use this for initialization
    public Camera cam;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 50))
            {
                if (hit.transform.GetComponent<StartButton>() != null)
                {
                    hit.transform.GetComponent<StartButton>().OnInteractorEnter(null);
                }
                if (hit.transform.GetComponent<Box>() != null)
                {
                    if (hit.transform.GetComponent<Box>().isActive)
                    {
                        hit.transform.GetComponent<Box>().GetComponent<Animator>().Play("OpenToShow");
                    }
                }
            }
        }
	}
    
}
