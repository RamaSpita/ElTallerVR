using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ReturnWithInput : Interacteable
{
    private bool wasThrown;
    private bool goBack;
    private bool triggerPressed;
    public Transform lastGrabbed;
    private Rigidbody rb;

    void Start ()
    {
        wasThrown = false;
        lastGrabbed = GameObject.Find("ElMazo").transform;
        rb = lastGrabbed.gameObject.GetComponent<Rigidbody>();

    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            goBack = true;
            rb.isKinematic = true;

        }
        if (goBack && lastGrabbed!=null)
        {
            Return();
        }
	}

    public override void OnPadClicked(Interactor interactor)
    {
        if (wasThrown && triggerPressed)
        {
            goBack = true;
            rb.isKinematic = true;
        }

    }
    public override void OnTriggerPressed(Interactor interactor)
    {
        triggerPressed = true;
    }
    public override void OnTriggerReleased(Interactor interactor)
    {
        triggerPressed = false;
        if (goBack)
        {
            goBack = false;
            rb.isKinematic = false;
        }
    }
    public override void OnPadUnclicked(Interactor interactor)
    {
        if (goBack)
        {
            goBack = false;
            rb.isKinematic = false;
        }
    }

    public void Return()
    {
        if (Vector3.Distance(lastGrabbed.position,this.transform.position)<0.1f)
        {
            lastGrabbed.SetParent(transform, true);
            lastGrabbed.forward = transform.forward;
            lastGrabbed.localPosition = new Vector3(0, 0, 0);
            Thrown(false);
            goBack = false;
            return;
        }
        if (Vector3.Distance(lastGrabbed.position, this.transform.position) < 5f)
        {
            lastGrabbed.forward = Vector3.Lerp(lastGrabbed.forward,transform.forward, 0.01f);
        }
        lastGrabbed.position = Vector3.Lerp(lastGrabbed.position, this.transform.position, 0.05f);
        lastGrabbed.localEulerAngles += lastGrabbed.right * 50;

    }
    public void Thrown(bool value)
    {
        wasThrown = value;
    }
}
