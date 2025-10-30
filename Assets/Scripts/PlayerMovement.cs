using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] GameObject _ground;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private Vector3 _GrappinDirection;
    private Vector3 _GrappinHit;
    [SerializeField] private float _speed = 2f;
    [SerializeField] GameObject _targetBonus;
    [SerializeField] MusicManager sfxSource;
	[SerializeField] Player_Collect _playerCollect;
    private Target_Bonus BonusScript;
    private bool _isGrounded;
    //[SerializeField] private float timer = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //BonusScript = _targetBonus.GetComponent<Target_Bonus>();
   

    }

    // Update is called once per frame
    void Update()
    {
		if (_playerCollect.gameStarted)
        {
			_horizontalMovement = Input.GetAxis("Horizontal");
        	_verticalMovement = Input.GetAxis("Vertical");
        	_movement = new Vector3(_horizontalMovement, 0.0f, _verticalMovement);
        	GrappinUpdateDirection(_movement);// Mise à jour de la direction de tir du grappin
        	_movement.Normalize();
        	_movement *= _speed;
        	_movement.y = _rb.linearVelocity.y;
		}
		else
		{
		 _movement = Vector3.zero;
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
		}

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
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && _playerCollect.gameStarted)
        { 
                _rb.AddForce(Vector3.up*500);
                sfxSource.PlayJumpSound();
        }

        /*if (BonusScript.BonusActivated)
        {
            timer -= Time.deltaTime;
            _speed = 5f;
            if (timer <= 0f)
            {
                BonusScript.BonusActivated = false;
                _speed = 2f;
            }
        }*/
    }

    public void ActivateBonus(float duration = 5f)
    {
        StartCoroutine(SpeedBoost(duration));
    }

    private IEnumerator SpeedBoost(float duration)
    {
        _speed = 5f;
        yield return new WaitForSeconds(duration);
        _speed = 2f;
    }
    
    public void ActivateMalus(float duration = 5f)
    {
        StartCoroutine(SpeedDBoost(duration));
    }

    private IEnumerator SpeedDBoost(float duration)
    {
        _speed = 0.5f;
        yield return new WaitForSeconds(duration);
        _speed = 2f;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (_ground)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (_ground)
        {
            _isGrounded = false;
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
