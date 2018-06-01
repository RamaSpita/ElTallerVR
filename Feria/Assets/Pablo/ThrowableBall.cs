using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ThrowableBall : Interacteable
{
    public float speedMultiplier = 1f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnTriggerPressed(Interactor interactor)
    {
        rb.isKinematic = true;
        transform.SetParent(interactor.transform, true);
    }

    public override void OnTriggerReleased(Interactor interactor)
    {
        rb.isKinematic = false;
        transform.SetParent(null);
        rb.velocity = interactor.wand.velocity * speedMultiplier;
        rb.angularVelocity = interactor.wand.angularVelocity;
        Spawner.spawner.ballsInBucket--;
    }

    public override void OnInteractorExit(Interactor interactor)
    {
        //Por las dudas
        rb.isKinematic = false;
        transform.SetParent(null);
       
    }

    
}
