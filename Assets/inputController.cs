using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputController : MonoBehaviour
{
    private Vector2 _move;

    public Vector2 Move => _move;
    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void Update()
    {
        Debug.Log(Move);
    }
}
