using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : Interacteable
{

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
        rb.velocity = interactor.wand.velocity;
        rb.angularVelocity = interactor.wand.angularVelocity;
    }

    public override void OnInteractorExit(Interactor interactor)
    {
        //Por las dudas
        rb.isKinematic = false;
        transform.SetParent(null);
    }
}
