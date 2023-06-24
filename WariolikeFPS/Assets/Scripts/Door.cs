using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;

    public bool requiresKey;
    public bool reqBlue, reqRed, reqYellow;
    public bool isDoorOpen;

    void Update()
    {
        if(isDoorOpen)
        {
            doorAnim.SetTrigger("OpenDoor");
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isDoorOpen = true;
        }
    }
}
