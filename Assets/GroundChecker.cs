using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float Radius = 0.15f;
    private bool _grounded;
    public LayerMask WhatIsGround;

    public bool Grounded => _grounded;
    void Start()
    {
        
    }

    
    void Update()
    {
        _grounded = Physics.CheckSphere(transform.position, Radius);       //Esto nos checkea si est� grounded (toca el suelo) checksphere nos dice la posici�n y el radio de la esfera
    }
}
