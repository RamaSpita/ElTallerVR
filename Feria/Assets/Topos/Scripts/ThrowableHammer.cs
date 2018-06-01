using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThrowableHammer : Interacteable
{

    private Rigidbody rb;
    private bool wasThrown;
    public bool hammer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnTriggerPressed(Interactor interactor)
    {
        rb.isKinematic = true;
        transform.SetParent(interactor.transform, true);
        transform.up = transform.parent.forward;
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public override void OnTriggerReleased(Interactor interactor)
    {
        rb.isKinematic = false;
        transform.SetParent(null);
        rb.velocity = interactor.wand.velocity;
        rb.angularVelocity = interactor.wand.angularVelocity;
        if (hammer)
        interactor.SendMessage("Thrown", false, SendMessageOptions.DontRequireReceiver);

    }

    public override void OnInteractorExit(Interactor interactor)
    {
        //Por las dudas
        rb.isKinematic = false;
        transform.SetParent(null);
        if (hammer)
        interactor.SendMessage("Thrown", true, SendMessageOptions.DontRequireReceiver);

    }

}
