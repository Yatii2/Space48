using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFunction : MonoBehaviour
{
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
