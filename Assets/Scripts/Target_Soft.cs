using System;
using UnityEngine;

public class Target_Soft : MonoBehaviour
{ 
    [SerializeField] private int _targetValueSo = 1;
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            other.gameObject.GetComponent<Player_Collect>().UpdateScore(_targetValueSo);
            Destroy(gameObject);
        }
    }
}
