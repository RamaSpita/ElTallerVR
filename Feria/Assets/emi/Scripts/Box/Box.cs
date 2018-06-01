using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interacteable
{
    private Animator anim;
    private Interactor interactor;
    [HideInInspector]
    public bool isActive;
    private float initialHandPositionY;
    private bool isOpen;
    private ParticleSystem winEffecct;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        winEffecct = GetComponent<Transform>().Find("Win").gameObject.GetComponent<ParticleSystem>();
        isActive = false;
        interactor = null;
        isOpen = false;
        EventManager.SubscribeToEvent("Open_Box", Open);
        EventManager.SubscribeToEvent("Close_Box", Close);
        EventManager.SubscribeToEvent("Close_BoxAndStart", CloseAndStart);
        EventManager.SubscribeToEvent("Activate_Box", Interact);
    }
    private void Update()
    {
        if (interactor != null)
        {
            float distace = interactor.transform.position.y - initialHandPositionY;
            if (distace > 0.01f)
            {
                //Show content
                anim.Play("OpenToShow");
            }
        } 
    }
    private void Close(params object[] close)
    {
        anim.Play("Close");
    }
    private void Open(params object[] close)
    {
        if (!isOpen)
        {
            anim.Play("Open");
        }
        else isOpen = false;
        winEffecct.Stop();
    }
    private void Interact(params object[] interact)
    {
        isActive = (bool)interact[0];
    }

    //When the hand is on the top
    public override void OnTriggerPressed(Interactor interactor)
    {
        if (isActive == true)
        {
            this.interactor = interactor;
            initialHandPositionY = interactor.transform.position.y;
        }
    }
    public override void OnTriggerReleased(Interactor interactor)
    {
        this.interactor = null;
    }
    public override void OnInteractorExit(Interactor interactor)
    {
        this.interactor = null;
    }
    
    //Open and show the content, OpenToShow function
    public void ShowContent()
    {
        if (isActive)
        {
            if (GetComponentInChildren<Transform>().Find("Coin") != null)
            {
                Debug.Log("Win");
                EventManager.TriggerEvent("Win");
                winEffecct.Play();
            }
            else
            {
                Debug.Log("Lose");
            }
            //Reset Values
            interactor = null;
            isOpen = true;
            EventManager.TriggerEvent("Activate_Box", new object[] { false });
        }
    }
    //Open and spawn the coin
    public void Spawn_Coin()
    {
        EventManager.TriggerEvent("Spawn_Coin");
    }
    //
    //Close
    private void CloseAndStart(params object[] close)
    {
        anim.Play("CloseToStart");
    }
    //CloseToStart function
    public void StartMixing()
    {
        EventManager.TriggerEvent("StartMixing");
    }
}

