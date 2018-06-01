using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(WandController))]
public class Interactor : MonoBehaviour
{

    public WandController wand { get; protected set; }
    private HashSet<Interacteable> touched;

    private void Awake()
    {
        wand = GetComponent<WandController>();
        touched = new HashSet<Interacteable>();

        wand.TriggerClicked += OnTriggerClick;
        wand.TriggerUnclicked += OnTriggerUnclick;

        wand.PadTouched += OnPadTouched;
        wand.PadUntouched += OnPadUntouched;

        wand.PadClicked += OnPadClick;
        wand.PadUnclicked += OnPadUnclick;

        wand.Gripped += OnGrip;
        wand.Ungripped += OnUngrip;
    }

    private void OnTriggerClick(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnTriggerPressed(this);
    }

    private void OnTriggerUnclick(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnTriggerReleased(this);
    }

    private void OnPadTouched(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnPadTouched(this);
    }

    private void OnPadUntouched(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnPadUntouched(this);
    }

    private void OnPadClick(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnPadClicked(this);
    }

    private void OnPadUnclick(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnPadUnclicked(this);
    }

    private void OnGrip(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnGripped(this);
    }

    private void OnUngrip(object sender, ClickedEventArgs e)
    {
        foreach (var current in touched)
            current.OnUngripped(this);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var currents = collider.GetComponents<Interacteable>();
        foreach (var current in currents)
        {
            if (!touched.Contains(current))
            {
                touched.Add(current);
                current.OnInteractorEnter(this);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        var currents = collider.GetComponents<Interacteable>();
        foreach (var current in currents)
        {
            if (touched.Contains(current))
            {
                touched.Remove(current);
                current.OnInteractorExit(this);
            }
        }
    }
}
