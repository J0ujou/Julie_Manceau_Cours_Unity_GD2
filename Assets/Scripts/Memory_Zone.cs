using System;
using UnityEngine;
using System.Collections;

public class Memory_Zone : MonoBehaviour
{
    [SerializeField] private Target_Fragment[] _targetFragment;
	[SerializeField] MusicManager sfxSource;
    public bool keycollected = false;
    public bool zone = false;
	private float Timer =5f;
    public int nbenter = 0;
	public bool outofzone =false;
    void Update()
    {
		if(zone==true)
		{
			Timer -= Time.deltaTime;
			if (Timer<=0f)
			{
			zone= false;
			}
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>()!= null && keycollected == true)
        {
			zone = true;
			nbenter = nbenter + 1;
			Debug.Log("ZONE");
			outofzone= false;
			sfxSource.PlayMemoryZoneSound();
            //Target_Fragment[] _targetFragment = FindObjectsOfType<Target_Fragment>();
            //foreach (var _targetFragment in _targetFragment)
            //{
                
                //_targetFragment.Hide(true);
                
            //}

            //_targetFragment.ShadowTimerControl();
        }
    }
	
	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>()!= null && keycollected == true)
		{
			zone= false;
			outofzone = true;
		}
	}
}   