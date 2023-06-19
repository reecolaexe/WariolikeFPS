using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [Header("Variables")]

    public Recoil recoilScript;

    void Start()
    {
        recoilScript = GameObject.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
    }
}
