using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [Header("Variables")]
    public float damage;
    public float delay;
    public float range;
    public float firerate;

    public float bulletSpeed = 100;
    public Transform bulletSpawnPoint;

    public Camera playerCamera;
    public TrailRenderer bulletTrail;

    private float nextTimeToFire = 0f;

    public Recoil recoilScript;

    void Start()
    {
        recoilScript = GameObject.Find("CameraRot/CameraRecoil").GetComponent<Recoil>();
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
        Vector3 direction = transform.forward;
        if (Physics.Raycast(bulletSpawnPoint.position, direction, out hit, range))
        {
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(spawnTrail(trail, hit.point, hit.normal, true));

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
        else
        {
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);

            StartCoroutine(spawnTrail(trail, bulletSpawnPoint.position + transform.forward * 100, Vector3.zero, false));
        }

        recoilScript.recoilFire();
    }

    private IEnumerator spawnTrail(TrailRenderer trail, Vector3 hit, Vector3 hitNormal, bool madeImpact)
    {
        Vector3 startPosition = trail.transform.position;
        float distance = Vector3.Distance(trail.transform.position, hit);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit, 1 - (remainingDistance / distance));

            remainingDistance -= bulletSpeed * Time.deltaTime;

            yield return null;
        }
    }
}