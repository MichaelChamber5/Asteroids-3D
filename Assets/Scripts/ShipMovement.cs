using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float tiltSpeed;
    [SerializeField] float rollSpeed;

    [SerializeField] GameObject laser1;
    [SerializeField] GameObject laser2;

    [SerializeField] float coolDown = 0.5f;

    LaserFire l1;
    LaserFire l2;

    float tiltAcceleration = 1;
    float rollAcceleration = 1;

    float currentTilt = 0;
    float currentRoll = 0;

    float tiltDirection = 0;
    float rollDirection = 0;

    float nextFireTime;

    Rigidbody rb;

    private void Start()
    {
        nextFireTime = Time.time;
        l1 = laser1.GetComponent<LaserFire>();
        l2 = laser2.GetComponent<LaserFire>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        currentTilt = Mathf.Lerp(currentTilt, tiltDirection, Time.deltaTime * tiltAcceleration);
        currentRoll = Mathf.Lerp(currentRoll, rollDirection, Time.deltaTime * rollAcceleration);

        rb.velocity = rb.transform.forward * moveSpeed;
        transform.rotation = transform.rotation * Quaternion.Euler(currentTilt * tiltSpeed, 0, -currentRoll * rollSpeed);
    }

    void OnTilt(InputValue value) 
    {
        tiltDirection = value.Get<float>();
    }

    void OnRoll(InputValue value)
    {
        rollDirection = value.Get<float>();
    }

    void OnShoot()
    {
        if(nextFireTime < Time.time)
        {
            l1.Shoot();
            l2.Shoot();
            nextFireTime = Time.time + coolDown;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //die
        print("KABOOM");
    }
}
