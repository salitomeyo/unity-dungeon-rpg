using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] private float rotationSpeed = 240.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, verticalInput, 0);
        controller.Move(move * Time.deltaTime * movementSpeed);
    }

    void PlayerRotation()
    {
        Vector3 mousePos = Input.mousePosition;

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
