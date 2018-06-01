using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : Interacteable
{
        
    public override void OnInteractorEnter(Interactor interactor)
    {
        var aux = GameObject.FindGameObjectsWithTag("Vasos");

        for (int i = 0; i < aux.Length; i++)
        {
            aux[i].transform.position = aux[i].GetComponent<Vasos>().startPosition;
            aux[i].transform.rotation = aux[i].GetComponent<Vasos>().rotation;
            aux[i].gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            aux[i].gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

    }

}
