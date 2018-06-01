using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadExample : Interacteable
{

    public Color idleColor = Color.white;
    public Color clickColor = Color.white;
    public Color color1 = Color.white;
    public Color color2 = Color.white;

    private MeshRenderer rend;
    private bool touched;
    private Interactor interactor;

    private void Awake()
    {
        rend = GetComponent<MeshRenderer>();
    }

    public override void OnPadTouched(Interactor interactor)
    {
        touched = true;
        this.interactor = interactor;
    }

    public override void OnPadUntouched(Interactor interactor)
    {
        touched = false;
        rend.material.color = idleColor;
    }

    private void Update()
    {
        if (touched)
        {
            var t = interactor.wand.GetTouchpadAxis().x / 2 + 0.5f;
            rend.material.color = Color.Lerp(color1, color2, t);
        }
    }

    public override void OnPadClicked(Interactor interactor)
    {
        touched = false;
        rend.material.color = clickColor;
    }

    public override void OnPadUnclicked(Interactor interactor)
    {
        touched = true;
    }

}
