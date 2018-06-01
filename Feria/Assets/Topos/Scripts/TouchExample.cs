using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchExample : Interacteable {

    public Color idleColor = Color.white;
    public Color touchedColor = Color.white;

    private MeshRenderer rend;

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public override void OnInteractorEnter(Interactor interactor)
    {
        rend.material.color = touchedColor;
    }

    public override void OnInteractorExit(Interactor interactor)
    {
        rend.material.color = idleColor;
    }

}
