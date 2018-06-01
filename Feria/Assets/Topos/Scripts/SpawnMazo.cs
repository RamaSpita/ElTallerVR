using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMazo : Interacteable {

    public Animator anim;
    public bool canPress;
    public Transform mazo;
    public Transform spawnMazo;
    public Vector3 rotationOnSpawn;
    public void Start()
    {
        canPress = true;
        anim = this.gameObject.GetComponent<Animator>();
        SpawnElMazo();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canPress)
            {
                canPress = false;
                anim.Play("Press");
                SpawnElMazo();

            }
        }
    }
    public void SpawnElMazo()
    {
        mazo.transform.eulerAngles = rotationOnSpawn;
        mazo.transform.position = spawnMazo.position;
    }
    public override void OnInteractorEnter(Interactor interactor)
    {
        if (canPress)
        {
            canPress = false;
            anim.Play("Press");
            SpawnElMazo();

        }

    }
    public void ButtonUp()
    {
        canPress = true;
    }
}
