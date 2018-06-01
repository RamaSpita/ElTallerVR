using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : Interacteable
{
    public MobManager mobManager;
    public Animator anim;
    public bool canPress;
    public bool onGame;
    public void Start()
    {
        canPress = true;
        anim = this.gameObject.GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canPress)
            {
                mobManager.move = false;
                canPress = false;
                anim.Play("Press");

                if (onGame)
                {
                    onGame = false;
                    mobManager.TurnOff();
                }
                else
                {
                    onGame = true;
                    mobManager.Restart();
                }

            }
        }
    }
    public override void OnInteractorEnter(Interactor interactor)
    {
        if (canPress)
        {
            mobManager.move = false;
            canPress = false;
            anim.Play("Press");

            if (onGame)
            {
                onGame = false;
                mobManager.TurnOff();
            }
            else
            {
                onGame = true;
                mobManager.Restart();
            }

        }

    }
    public void ButtonUp()
    {
        if (onGame)
        {
            mobManager.move = true;

        }
        canPress = true;

    }
}
