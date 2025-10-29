using System;
using UnityEngine;

public class Memory_Zone : MonoBehaviour
{
    [SerializeField] private Target_Fragment[] _targetFragment;
    public bool keycollected = false;
    public bool zone = false;
	private float Timer =5f;
    
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
			Debug.Log("ZONE");
			
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
		}
	}
}   