using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripExample : Interacteable {

    public Color idleColor = Color.white;
    public Color grippedColor = Color.white;

    private MeshRenderer rend;

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public override void OnGripped(Interactor interactor)
    {
        rend.material.color = grippedColor;
    }

    public override void OnUngripped(Interactor interactor)
    {
        rend.material.color = idleColor;
    }

}
