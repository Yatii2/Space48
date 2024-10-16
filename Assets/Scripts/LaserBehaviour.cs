using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500;
    [SerializeField] private float cooldownTime = 3f;
    [SerializeField] private GameObject laserPrefab;

    private float cooldownCounter = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;

        }


    }
}
