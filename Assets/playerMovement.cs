using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputController _input;
    public float Speed=1;
    private Vector3 _lastVelocity;
    private float JumpSpeed = 10;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController>();
    }

    void Update()
    {

        
        Move();
    }

    private void Jump(ref Vector3 velocity)
    {
        velocity.y = JumpSpeed;
    }

    private bool ShouldJump()
    {
        return _input.Jump;
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_input.InputMove.x, 0, _input.InputMove.y); //el 0 es para q solo se mueva horizontalmente, InputController es un vector 2 
                                                                                    //que solo tiene 2 direcciones, x e y, por eso el 0 es y en vez de z
        //_characterController.SimpleMove(direction * Speed); //con el método simplemove

        Vector3 velocity = new Vector3();
        velocity.x = direction.x * Speed;
        velocity.y = _lastVelocity.y;
        velocity.z = direction.z * Speed;


        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity); //se lo paso por referencia para cuando salga de la función el valor haya cambiado, si lo paso por valor normal, al salir no cambia su valor

        _characterController.Move(velocity * Time.deltaTime);//con el método Move



        //turn
        if (direction.magnitude>0) //para girar
        {
            Vector3 target = transform.position + direction;
            transform.LookAt(target);
        }
        _lastVelocity = velocity;
        
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime; //queremos la ultima velocidad que hemos tenido más el incremento durante el tiempo de caida, 
                                                                       //porque la aceleración es el incremento de la velocidad
    
    
    }


}
