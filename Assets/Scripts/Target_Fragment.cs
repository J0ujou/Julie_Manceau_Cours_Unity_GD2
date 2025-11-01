using System;
using System.Collections;
using UnityEngine;

public class Target_Fragment : MonoBehaviour
{ 
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 5f;
    [SerializeField] private GameObject _particuleEffect;
    [SerializeField] private Player_Collect _playerCollect;
    [SerializeField] Memory_Zone _memoryZone;
    [SerializeField] MusicManager sfxSource;
    private bool HasDoOnce = false;

	void Start()
	{
		_memoryZone = FindFirstObjectByType<Memory_Zone>();
        sfxSource = FindFirstObjectByType<MusicManager>();
	}

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
            sfxSource.PlayPickupFragmentSound();

        }
    }
    
   private void ToggleVisibility(bool newVisibility= true)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
    
    public void Hide(bool newVisibility = true)
    { 
        GetComponent<MeshRenderer>().enabled = newVisibility;
        Debug.Log("hide");
    }
    
    //TODO: Timer by deltatime
    private void Update()
    {
       if (_playerCollect.gameStarted)
       {
			if(!HasDoOnce)
            {
				StartCoroutine(ShadowTimerControl());
			}
               
       		if (_memoryZone.nbenter >=1)
       			{
           			if (_memoryZone.zone == true)
           			{
               			//Hide(true);
		                
           			}
           			else
           			{
               			//Hide(false);
           			}
				}
       }
		
       
       //if (_memoryZone.outofzone== true)
       //{
           //Hide(false);
       //}
       
    }
    
    
    //TODO: timer by coroutine
    public IEnumerator ShadowTimerControl()
    {
        yield return new WaitForSeconds(_shadowDuration);
        if (!HasDoOnce)
        {
            Hide(false);
            HasDoOnce = true;
        }
    }

	
}
