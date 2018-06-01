using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TP : Interactor
{
    private LineRenderer line;
    public float rayMaxDistance = 200f;
   

    private void Start() 
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.up * rayMaxDistance);
        EnableDisbaleRay(false);
        wand = GetComponent<WandController>();
        wand.PadClicked += PadClicked;
        wand.PadUnclicked += PadUnClicked;
    }
    void Update () 
    {
        if (line.enabled) 
        {
            MoveRayCast();
        }
    }
    private void PadClicked(object sender, ClickedEventArgs e)
    {
        EnableDisbaleRay(true);
    }
    private void PadUnClicked(object sender, ClickedEventArgs e) {
        EnableDisbaleRay(false);
    }

    public void MoveRayCast() 
    {
        line.SetPosition(0, transform.position);
        Ray ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        RaycastHit hitInfo = new RaycastHit();
        if(Physics.Raycast(ray, out hitInfo, rayMaxDistance)) 
        {
            line.SetPosition(1, hitInfo.point);
        }
        else 
        {
            line.SetPosition(1, transform.position + transform.forward * rayMaxDistance);

        }

    }
    private void Sa(object sender, ClickedEventArgs e)
    {

    }
    public void EnableDisbaleRay(bool value)
    {
        line.enabled = value;
    }

    
    
}
