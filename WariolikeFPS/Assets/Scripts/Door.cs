using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;

    public bool requiresKey;
    public bool reqBlue, reqRed, reqYellow;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(requiresKey)
            {
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
            }
            else
            {
                doorAnim.SetTrigger("OpenDoor");
            }
        }
    }
}
