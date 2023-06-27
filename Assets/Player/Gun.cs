using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Transform playerCamera;

    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;


    void awake()
    {
        playerCamera = Camera.main.transform;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, range))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
