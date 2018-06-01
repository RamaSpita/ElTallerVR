using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobManager : MonoBehaviour {

    public AGolpear[] mobs;
    private float timer;
    public float time;
    public Text puntosTxt;
    public Text timeTxt;
    private int cantPuntos;
    public bool move;
    private float gameTime;
    public float totalGameTime;
    public Restart button;
    public float VelParaGolpe;


    // Use this for initialization
    void Start ()
    {
        move = false;
        cantPuntos = 0;
        puntosTxt.text = "0";
        mobs = gameObject.GetComponentsInChildren<AGolpear>();
        timer = time;
        gameTime = totalGameTime;
        timeTxt.text = "" + (int)gameTime;
        AGolpear.velocidadNecesaria = VelParaGolpe;


    }

    // Update is called once per frame
    void Update ()
    {
        if (move)
        {
            if (timer <= 0)
            {
                ActivateMobs(Random.Range(0, 2));
                timer = time;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            GameTimeUpdate();

        }

    }
    public void GameTimeUpdate()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            TurnOff();
        }
        timeTxt.text = "" + (int)gameTime;
    }
    public void ActivateMobs(int cant)
    {
        while (cant > 0)
        {
            var auxMob = mobs[Random.Range(0, mobs.Length)];
            if (!auxMob.active)
            {
                auxMob.Activate();
                cant--;
            }
        }
    }

    public void AddPoints()
    {
        cantPuntos++;
        puntosTxt.text = ""+ cantPuntos;
    }
    public void Restart()
    {
        cantPuntos = 0;
        puntosTxt.text = "0";
        timer = time;
        for (int i = 0; i < mobs.Length; i++)
        {
            mobs[i].Restart();
        }
    }
    public void TurnOff()
    {
        move = false;
        gameTime = totalGameTime;

        for (int i = 0; i < mobs.Length; i++)
        {
            mobs[i].wait = false;
            mobs[i].speed = -Mathf.Abs(mobs[i].speed);
        }
        button.onGame = false;
    }
}
