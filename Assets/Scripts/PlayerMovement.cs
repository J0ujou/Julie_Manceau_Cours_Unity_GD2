using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private Vector3 _GrappinDirection;
    private Vector3 _GrappinHit;
    [SerializeField] private float _speed = 2f;
    private bool _isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
   

    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0.0f, _verticalMovement);
        GrappinUpdateDirection(_movement);// Mise à jour de la direction de tir du grappin
        _movement.Normalize();
        _movement *= _speed;
        _movement.y = _rb.linearVelocity.y;
        if (_rb != null)
        {
            _rb.linearVelocity = _movement;
        }
        else
        {
            Debug.LogError("No RigidBody found");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TryThrowGrappin();
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            ThrowGrappin();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up*500);
        }
        
        
    }
    

    private void GrappinUpdateDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.1f)
        {
            _GrappinDirection = direction;
        }
    }

    private void TryThrowGrappin()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, _GrappinDirection, out Hit, 100f))
        {
            Debug.DrawRay(transform.position, transform.position+_GrappinDirection*100f, Color.red);
            _GrappinHit  = Hit.point + Hit.normal*1.5f;
        }
    }

    private void ThrowGrappin()
    {
       transform.position = _GrappinHit;
       _GrappinDirection= Vector3.zero;
    }
}
