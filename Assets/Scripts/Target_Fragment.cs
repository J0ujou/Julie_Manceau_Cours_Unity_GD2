using System;
using System.Collections;
using UnityEngine;

public class Target_Fragment : MonoBehaviour
{ 
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 5f;
    [SerializeField] private GameObject _particuleEffect;
    [SerializeField] private Player_Collect _playerCollect;
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
            //Instantiate(_particuleEffect, transform.position, Quaternion.identity);
         // StartCoroutine(ShadowTimerControl());
        }
    }
    
   private void ToggleVisibility(bool newVisibility= true)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
    
    private void Hide(bool newVisibility = true)
    { 
        GetComponent<MeshRenderer>().enabled = newVisibility;
    }
    
    //TODO: Timer by deltatime
    private void Update()
    {
       /*f(_isInShadows)
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
        }*/
       if (_playerCollect.gameStarted)
       {
               StartCoroutine(ShadowTimerControl());
       }   
    }
    
    
    //TODO: timer by coroutine
    private IEnumerator ShadowTimerControl()
    {
        yield return new WaitForSeconds(_shadowDuration);
        Hide(false);
    }
    
}
