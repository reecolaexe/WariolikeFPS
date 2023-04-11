using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : MonoBehaviour
{
    [Header("Variables")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage;

    public LayerMask attackLayer;
    public Camera playerCamera;
    public AudioSource audioSource;

    public GameObject hitEffect;
    public AudioClip swingSound;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
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
        Invoke(nameof(attackRaycast), attackDelay);

    }

    void resetAttack()
    {
        readyToAttack = true;
        attacking = false;
    }

    void attackRaycast()
    {
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            hitTarget(hit.point);
        }
    }

    void hitTarget(Vector3 pos)
    {
        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 20);
    }
}
