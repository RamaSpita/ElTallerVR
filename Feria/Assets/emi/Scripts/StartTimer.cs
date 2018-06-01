using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public void StartPlaying()
    {
        GetComponent<Animator>().Play("Timer");
        gameObject.SetActive(false);
    }
}
