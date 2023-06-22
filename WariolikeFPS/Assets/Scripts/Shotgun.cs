using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
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
    private float bulletsPerShot = 6;
    private float spread = 5f;


    void awake()
    {

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

        for(int i = 0; i < bulletsPerShot; i++)
        {
            if (Physics.Raycast(bulletSpawnPoint.position, shotgunSpread(), out hit, range))
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
                TrailRenderer trail = Instantiate(bulletTrail, shotgunSpread(), Quaternion.identity);

                StartCoroutine(spawnTrail(trail, bulletSpawnPoint.position + transform.forward * 100, Vector3.zero, false));
            }
        }
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

    Vector3 shotgunSpread()
    {
        Vector3 targetPostion = playerCamera.transform.position + playerCamera.transform.forward * range;
        targetPostion = new Vector3(targetPostion.x + Random.Range(-spread, spread), targetPostion.y + Random.Range(-spread, spread), targetPostion.z + Random.Range(-spread, spread));
        Vector3 direction = targetPostion - playerCamera.transform.position;
        return direction.normalized;
    }
}