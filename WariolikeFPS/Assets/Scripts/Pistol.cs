using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [Header("Variables")]
    public float attackSpeed;
    public float ammo;
    public int attackDamage;

    public LayerMask attackLayer;
    public Camera playerCamera;
    public AudioSource audioSource;

    public GameObject muzzleFlash;
    public AudioClip emptySound;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }

    void attack()
    {
        if (!readyToAttack || attacking) return;
        readyToAttack = false;
        attacking = true;
        Invoke(nameof(resetAttack), attackSpeed);
        if(ammo > 0)
        {
            attackRaycast();
        }
        else
        {
            audioSource.PlayOneShot(emptySound);
        }

    }

    void resetAttack()
    {
        readyToAttack = true;
        attacking = false;
    }

    void attackRaycast()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, attackLayer))
        {
            hitTarget(hit.point);
        }
    }

    void hitTarget(Vector3 pos)
    {
        
    }
}
