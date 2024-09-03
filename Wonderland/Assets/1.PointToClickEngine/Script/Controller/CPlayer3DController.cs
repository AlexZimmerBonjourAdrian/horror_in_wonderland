using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer3DController : MonoBehaviour
{
    // Movement variables
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    // Look variables
    public float mouseSensitivity = 2f;
    public float clampAngle = 80f;

    // Private variables
    private CharacterController _controller;
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private float _verticalRotation;
    private float _horizontalRotation;

    [SerializeField]
    private Transform direction_Transform;

    public float interactionDistance = 3f; // Distancia de interacción
    public Color gizmoColor = Color.yellow; // Color del Gizmo
 
    [SerializeField]
    private Transform CameraTransform;

    private Camera mainCamera;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _verticalRotation = transform.localEulerAngles.y;
         mainCamera = Camera.main;
      
    }

    private void Update()
    {
        // Movement
       // Movement
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");

        _moveDirection = direction_Transform.forward * zVertical; // Forward/Backward
        _moveDirection += direction_Transform.right * xHorizontal; // Left/Right

        // Interaction
        if (Input.GetKeyDown(KeyCode.E)) // Cambia 'E' por la tecla que desees
        {
            RaycastHit hit;
            // Usar la dirección de la cámara para el Raycast
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
            {
                // Buscar el componente Iinteract en el objeto golpeado
                Iinteract interactable = hit.collider.GetComponent<Iinteract>();
                if (interactable != null)
                {
                    interactable.Oninteract(); // Ejecutar Oninteract()
                }
            }
        }


        if (_controller.isGrounded)
        {
             _velocity.x = _moveDirection.x * moveSpeed;
             _velocity.z = _moveDirection.z * moveSpeed;
             if (Input.GetButtonDown("Jump"))
             {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);   
             }   
        }  

        if (!_controller.isGrounded)
        {
         _velocity.x = _moveDirection.x * moveSpeed;
         _velocity.z = _moveDirection.z * moveSpeed;
         _velocity.y -= gravity * Time.deltaTime;
        }
        _controller.Move(_velocity * Time.deltaTime);

        // Looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        _verticalRotation += mouseX;
        _horizontalRotation -= mouseY;

        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -clampAngle, clampAngle);

       CameraTransform.transform.localEulerAngles = new Vector3(_horizontalRotation, _verticalRotation, 0f);
    }

 void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor; // Establece el color del Gizmo
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * interactionDistance); // Línea hacia adelante
        Gizmos.DrawSphere(transform.position + transform.forward * interactionDistance, 0.2f); // Esfera al final de la línea
    }
}
