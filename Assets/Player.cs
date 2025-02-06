using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;

    private Rigidbody rb;

    private Vector2 inputMando;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        playerInput.actions["Jump"].started += Jump;
        playerInput.actions["Move"].performed += Move; //Se dispara el evento SÓLO MIENTRAS HAYA CAMBIO DE VALOR.
        playerInput.actions["Move"].canceled += StopMoving;
    }
    private void Move(InputAction.CallbackContext ctx)
    {
        Debug.Log("Cambio valor!"); 
        //Estoy leyendo la dirección de movimiento del mando/teclado
        inputMando = ctx.ReadValue<Vector2>();
    }

    private void StopMoving(InputAction.CallbackContext ctx)
    {
        inputMando = ctx.ReadValue<Vector2>();
    }


    private void Jump(InputAction.CallbackContext obj)
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(inputMando.x, 0, inputMando.y) * 10, ForceMode.Force);
    }
}
