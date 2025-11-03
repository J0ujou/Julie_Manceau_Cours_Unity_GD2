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
    [SerializeField] private float _speed = 2f;
    [SerializeField] GameObject _targetBonus;
    [SerializeField] MusicManager sfxSource;
	[SerializeField] Player_Collect _playerCollect;
    private Target_Bonus BonusScript;
    private bool _isGrounded;
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
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && _playerCollect.gameStarted)
        { 
                _rb.AddForce(Vector3.up*250);
                sfxSource.PlayJumpSound();
        }
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

}
