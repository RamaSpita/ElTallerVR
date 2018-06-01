using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : Interacteable
{
    private bool isActive = true;
    private Animator anim;
    private float timer;

    private void Awake()
    {
        timer = 5;
        anim = GetComponent<Animator>();
        EventManager.SubscribeToEvent("Play_Again", Restart);
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (timer <= 4)
        {
            timer += Time.deltaTime;
            if (timer > 4)
            {
                EventManager.TriggerEvent("Close_BoxAndStart");
                EventManager.TriggerEvent("Move_CoinDown");
            }
        }
    }
    private void StartPlaying()
    {
        EventManager.TriggerEvent("Open_Box");
        anim.Play("Press");
        isActive = false;
        timer = 0;
    }
    public override void OnInteractorEnter(Interactor interactor)
    {
        if (isActive) StartPlaying();
    }
    //
    //Unpress function
    private void Restart(params object[] restart)
    {
        anim.Play("UnPress");
    }
    public void PlayAgain()
    {
        isActive = true;
    }
}
