using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeedLaser = 500;
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = transform.position + transform.forward * moveSpeedLaser * Time.deltaTime;
    }

}
