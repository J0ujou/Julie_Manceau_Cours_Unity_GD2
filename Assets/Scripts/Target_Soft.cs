using System;
using System.Collections;
using UnityEngine;

public class Target_Soft : MonoBehaviour
{ 
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 3f;
    [SerializeField] private GameObject _particuleEffect;
    private float _shadowTimer = 0;
    private bool _isInShadows = false;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            other.gameObject.GetComponent<Player_Collect>().UpdateScore(_targetValue);
            //Destroy(gameObject);
            //TODO: Hide Target
            ToggleVisibility(false);
            //TODO: Start Timer
            //_isInShadows = true;
            Instantiate(_particuleEffect, transform.position, Quaternion.identity);
            StartCoroutine(ShadowTimerControl());
        }
    }

    private void ToggleVisibility(bool newVisibility= true)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
    //TODO: Timer by deltatime
    /*private void Update()
    {
        if(_isInShadows)
        {
            _shadowTimer += Time.deltaTime;
            if (_shadowTimer >= _shadowDuration)
            {
                //TODO: Show Target
                ToggleVisibility(true);
                // TODO: Stop Timer
                _shadowTimer = 0f;
                _isInShadows = false;
            }
        }
    }*/
    
    
    //TODO: timer by coroutine
    private IEnumerator ShadowTimerControl()
    {
        yield return new WaitForSeconds(_shadowDuration);
        ToggleVisibility(true);
    }
    
}
