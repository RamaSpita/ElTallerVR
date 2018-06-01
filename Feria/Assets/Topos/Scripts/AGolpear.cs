using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGolpear : MonoBehaviour {
    public bool active;
    public bool wait;
    public bool gotHit;
    public float speed;
    public float waitingTime;
    private float timer;
    public float distancia;
    public float velRotNes;
    private Vector3 posIni;
    public static float velocidadNecesaria;
    private Animator anim;


    void Start ()
    {
        posIni = this.transform.position;
        timer = waitingTime;
        active = false;
        anim = this.gameObject.GetComponent<Animator>();
       
	}
	
	void Update ()
    {
        if (active)
        {
            Move();
        }
        
	}

    public void Move()
    {
        if (!wait)
        {
            this.transform.position += Vector3.up * Time.deltaTime * speed;
            if ((this.transform.position - posIni).magnitude >= distancia && speed > 0)
            {
                wait = true;
            }
            else if(this.transform.position.y <= posIni.y && speed<0)
            {
                active = false;
                speed *= -1;
                anim.Play("GotHit");

            }
        }
        else
        {
            if (timer <= 0)
            {
                wait = false;
                speed *= -1;
                timer = waitingTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        
    }

    public void Activate()
    {
        Activate(0, 0);
    }
    public void Activate(float speed, float waitingTime)
    {
        anim.Play("Idle");
        active = true;
        wait = false;
        gotHit = false;
        this.transform.position = posIni;
        if (speed>0)
        {
            this.speed = speed;
        }
        if (waitingTime>0)
        {
            this.waitingTime = waitingTime;
        }
        timer = this.waitingTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Martillo") && active && !gotHit)
        {
                var wand = other.transform.parent.parent.GetComponent<WandController>();
            if (/*wand.velocity.y <= -velocidadNecesaria ||*/ wand.angularVelocity.x >= velRotNes) 
            {
                Debug.Log(wand.angularVelocity.x);
                if (wand != null)
                {
                    wand.Vibrate(2000, 0.3f, 1, 0);
                }
                GotHit();
            }
            
        }
    }

    public void Restart()
    {
        this.transform.position = posIni;
        wait = false;
        active = false;
        timer = waitingTime;

        if (speed < 0)
        {
            speed *= -1;
        }
    }

    public void GotHit()
    {
        gotHit = true;
        anim.Play("GotHit");
        wait = false;
        speed = -Mathf.Abs(speed);
        timer = waitingTime;
        this.transform.parent.SendMessage("AddPoints");

    }
}
