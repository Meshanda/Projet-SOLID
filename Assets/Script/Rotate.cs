using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    private void Update()
    {
        gameObject.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
