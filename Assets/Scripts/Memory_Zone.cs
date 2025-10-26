using System;
using System.Collections;
using UnityEngine;

public class Memory_Zone : MonoBehaviour
{
    [SerializeField] private Target_Fragment[] _targetFragment;
    public bool keycollected = false;
    public bool zone = false;
    
    //void Start()
    //{
       // _targetFragment[] = FindObjectsOfType<Target_Fragment>();
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>()!= null && keycollected == true)
        {
            Target_Fragment[] _targetFragment = FindObjectsOfType<Target_Fragment>();
            foreach (var _targetFragment in _targetFragment)
            {
                zone = true;
                _targetFragment.Hide(true);
                Debug.Log("ZONE");
            }

            //_targetFragment.ShadowTimerControl();
        }
    }
}   