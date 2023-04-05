using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))]
public class ViewBobbing : MonoBehaviour
{
    [Header("Variables")]
    public float effectIntensity;
    public float effectIntensityX;
    public float effectSpeed;

    private PositionFollower followerInstance;
    private Vector3 originalOffset;
    private float sinTime;

    void Start()
    {
        followerInstance = GetComponent<PositionFollower>();
        originalOffset = followerInstance.offset;
    }

    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));

        if(inputVector.magnitude > 0f)
        {
            sinTime += Time.deltaTime * effectSpeed;
        }
        else
        {
            sinTime = 0f;
        }

        Vector3 sinAmountX = followerInstance.transform.right * effectIntensity * Mathf.Cos(sinTime) * effectIntensityX;
        float sinAmountY = -Mathf.Abs(effectIntensity * Mathf.Sin(sinTime));

        followerInstance.offset = new Vector3 { x = originalOffset.x, y = originalOffset.y + sinAmountY, z = originalOffset.z };
        followerInstance.offset += sinAmountX;
    }
}
