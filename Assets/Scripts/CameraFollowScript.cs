using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    [SerializeField] GameObject focus;
    [SerializeField] Vector3 offsetVector;

    // Update is called once per frame
    void Update()
    {
        //transform.position = focus.transform.position + (focus.transform.rotation * offsetVector);
        //transform.LookAt(focus.transform.position, transform.up);

        // Maintain offset while matching the ship's rotation
        transform.position = focus.transform.position + (focus.transform.rotation * offsetVector);

        // Ensure camera follows the ship’s rotation completely, including roll
        transform.rotation = focus.transform.rotation;
    }
}
