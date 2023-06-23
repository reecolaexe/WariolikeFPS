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
                if(reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    doorAnim.SetTrigger("OpenDoor");
                }
                if (reqYellow && other.GetComponent<PlayerInventory>().hasYellow)
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
