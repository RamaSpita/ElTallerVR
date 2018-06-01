using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private Vector3 positionTomove;
    private Vector3 upPosition;
    private Vector3 downPosition;
    private int direction;
    private bool move;
    public ParticleSystem smoke;

	// Use this for initialization
	void Start ()
    {
        move = false;
        EventManager.SubscribeToEvent("Set_CoinPosition", SetParent);
        EventManager.SubscribeToEvent("Win", MoveUp);
        EventManager.SubscribeToEvent("Move_CoinDown", MoveDown);
        smoke = Instantiate(smoke);
        smoke.Stop();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (move)
        {
            Movement(direction, positionTomove);
        }
	}
    private void Movement(int dir, Vector3 position)
    {
        if ((transform.localPosition.y - position.y) * dir > Time.deltaTime * 0.005f)
        {
            transform.localPosition += Vector3.down * direction * 0.005f;
        }
        else
        {
            move = false;
            transform.localPosition = new Vector3(transform.localPosition.x, position.y, transform.localPosition.z);
        }
    }
    private void SetParent(params object[] pos)
    {
        var parent = (Transform)pos[0];
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        upPosition = transform.localPosition + new Vector3(0, 0.7f, 0);
        downPosition = transform.localPosition + new Vector3(0, 0.1f, 0);
        transform.localPosition = upPosition;
        smoke.transform.position = transform.position;
        smoke.Play();
    }
    private void MoveDown(params object[] down)
    {
        transform.localPosition = upPosition;
        direction = 1;
        positionTomove = downPosition;
        move = true;
    }
    private void MoveUp(params object[] up)
    {
        direction = -1;
        positionTomove = upPosition;
        move = true;
    }
}
