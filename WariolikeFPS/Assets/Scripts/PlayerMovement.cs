using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float moveSmoothTime;
    public float jumpHeight;
    public float gravityStrength;

    [Header("Charging")]
    public float chargeSpeed;
    public float chargeDuration;
    public bool cameraLocked;

    private CharacterController cc;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private Vector3 currentForceVelocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        cameraLocked = false;
    }

    void Update()
    {
        groundMovement();
        airMovement();
    }

    void groundMovement()
    {
        Vector3 playerInput = new Vector3 { x = Input.GetAxisRaw("Horizontal"), y = 0f, z = Input.GetAxisRaw("Vertical") };

        if (playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }

        Vector3 moveVector = transform.TransformDirection(playerInput);
        currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, moveVector * moveSpeed, ref moveDampVelocity, moveSmoothTime);
        cc.Move(currentMoveVelocity * Time.deltaTime);
    }

    void airMovement()
    {
        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.25f))
        {
            currentForceVelocity.y = -2f;
            if (Input.GetKey(KeyCode.Space))
            {
                currentForceVelocity.y = jumpHeight;
            }
        }
        else
        {
            currentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }
        cc.Move(currentForceVelocity * Time.deltaTime);
    }

    void charging() 
    {
        //Add force to transform.forward to apply constant speed.
    }
}