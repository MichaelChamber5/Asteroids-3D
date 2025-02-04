using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    //public Transform laserOrigin;
    public float gunRange = 500f;
    public float fireRate = 0.3f;
    public float laserDuration = 0.1f;

    LineRenderer laserLine;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    public void Shoot()
    {
        laserLine.SetPosition(0, transform.position);
        Vector3 rayOrigin = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            if(hit.collider.gameObject.tag == "Meteor")
            {
                hit.collider.gameObject.GetComponent<MeteorScript>().Pop();
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (transform.forward * gunRange));
        }
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
