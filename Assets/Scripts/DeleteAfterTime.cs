using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{

    [SerializeField] float delay;

    private void Start()
    {
        Invoke("Delete", delay);
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
