using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMixer : MonoBehaviour
{

    public float speed;
    public int ciclesAmount;

    private List<Vector3> cupPosition = new List<Vector3>();
    private List<Vector3> cupPositionAux = new List<Vector3>();
    private List<Transform> cups = new List<Transform>();
    private float timer = 0;
    private int ciclesCont = 0;
    private bool startMixing;

    private void Awake()
    {
        for (int i = 0; i < GetComponentInChildren<Transform>().childCount; i++)
        {
            cupPosition.Add(GetComponentInChildren<Transform>().GetChild(i).localPosition);
            cups.Add(GetComponentInChildren<Transform>().GetChild(i));
        }
    }
    private void Start()
    {
        startMixing = false;
        cupPositionAux = cupPosition;
        EventManager.SubscribeToEvent("StartMixing", StartMovement);
        EventManager.SubscribeToEvent("Spawn_Coin", SetCointPosition);Debug.Log(cups.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (startMixing)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
                MoveBoxes(cupPosition, cups);
            }
            else
            {
                while (cupPositionAux[0] == cupPosition[0])
                {
                    cupPositionAux = PositionsMixer(cupPosition);
                }
                cupPosition = cupPositionAux;
                ciclesCont++;
                timer = 0;
            }
            if (ciclesCont == ciclesAmount)
            {
                startMixing = false;
                //To interact whit the box
                EventManager.TriggerEvent("Activate_Box", new object[] { true });
                //To Start again if you want
                EventManager.TriggerEvent("Play_Again");
            }
        }
    }

    private void MoveBoxes(List<Vector3> pos, List<Transform> cups)
    {
        timer += Time.deltaTime;
        for (int i = 0; i < cups.Count; i++)
        {
            cups[i].localPosition = Vector3.Slerp(cups[i].localPosition, pos[i], (speed / 10f) * timer * 1);
            if (cups[i].localPosition.y < pos[i].y)
            {
                var aux = new Vector3(cups[i].localPosition.x, pos[i].y + (pos[i].y - cups[i].localPosition.y), cups[i].localPosition.z);
                cups[i].localPosition = aux;
            }
            if (Vector3.Distance(cups[i].localPosition, pos[i]) < Time.deltaTime * speed)
            {
                cups[i].localPosition = pos[i];
            }
        }
    }

    private List<Vector3> PositionsMixer(List<Vector3> positions)
    {
        if (positions.Count == 0) { return positions; }
        else
        {
            var aux = new List<Vector3>(positions);
            int random = Random.Range(0, aux.Count);
            Vector3 valor = aux[random];
            aux.RemoveAt(random);
            var returnlist = new List<Vector3>();
            returnlist.Add(valor);
            returnlist.AddRange(PositionsMixer(aux));
            return returnlist;
        }
    }
    //
    //To begin mixing
    private void StartMovement(params object[] start)
    {
        //Reset Values
        startMixing = true;
        timer = 0;
        ciclesCont = 0;
        //To change Positions
        while (cupPositionAux[0] == cupPosition[0])
        {
            cupPositionAux = PositionsMixer(cupPosition);
        }
        cupPosition = cupPositionAux;
    }
    //
    //Put the coin in the right place
    private void SetCointPosition(params object[] coin)
    {
        //Show coin in a random place
        int random = Random.Range(0, cups.Count);
        EventManager.TriggerEvent("Set_CoinPosition", new object[] { cups[random] });
    }
}

