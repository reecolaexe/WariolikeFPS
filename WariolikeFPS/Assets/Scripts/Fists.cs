using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : MonoBehaviour
{
    [Header("Variables")]
    public float damage;
    public float delay;
    public float range;
    public float firerate;

    public Camera playerCamera;
    public Animator animator;

    private float nextTimeToFire = 0f;

    public const string IDLE = "Idle";
    public const string EQUIP = "Equip";
    public const string ACTION = "Action"
    public const string PUNCH = "Punch";
    public const string PUNCHIMPACT = "PunchImpact";
    string currentAnimationState;

    void Start()
    {
        changeAnimationState("");
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            Invoke(nameof(shoot), delay);
        }
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
    }

    void changeAnimationState(string newState)
    {
        if (currentAnimationState == newState) return;
        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }
}
