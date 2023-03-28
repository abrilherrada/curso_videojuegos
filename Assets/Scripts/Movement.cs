using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isGrounded = false;
    [SerializeField] private string objectName = "Dexter";
    private int characterAge = 5;
    private double fallingSpeed = -9.81;
    [SerializeField] private Vector3 objectSize = new Vector3(x: 1, y: 1, z: 1);
    [SerializeField] private float speed = 0.3f;
    [SerializeField] private Vector3 movementDirection = new Vector3(x: 0.5f, y: 0.5f, z: 0.5f);

    private void Awake()
    {
        Debug.Log("Hello world");
        Debug.LogWarning("Warning");

        var isSpeedValid = speed > 0;
        var isNameValid = !string.IsNullOrEmpty(objectName);

        Debug.LogError("Is the speed valid? " + isSpeedValid);

        //solo lo imprime si la condición evaluada es falsa
        Debug.Assert(isSpeedValid, "The speed is invalid");
        Debug.Assert(isNameValid, "The name is invalid");
    }
    void Start()
    {
        transform.localScale = objectSize;
    }

    private Vector3 CalculateDisplacement(float movSpeed, Vector3 movDirection)
    {
        var displacement = movSpeed * Time.deltaTime * movDirection;
        return displacement;
    }

    private void Move(float movSpeed, Vector3 movDirection, Transform movObject)
    {
        movObject.position += CalculateDisplacement(movSpeed, movDirection);
    }

    void Update()
    {
        Move(speed, movementDirection, transform);
        
        //Debug.Log(transform.position);
        //Debug.Break();
    }
}