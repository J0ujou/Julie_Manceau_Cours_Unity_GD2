using System;
using UnityEngine;

public class Target_Key : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] Memory_Zone _memoryZone;
    [SerializeField] MusicManager sfxSource;
    [SerializeField] UIController uiController;
    private bool tutorial = false;
    private float timer = 3f;
    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.GetComponent<Player_Collect>() != null)
      {
          other.gameObject.GetComponent<Player_Collect>().UpdateScorekey(_targetValue);
          Destroy(gameObject);
          _memoryZone.keycollected = true;
          Debug.Log("key collected");
          sfxSource.PlayPickupKeySound();
          uiController.ShowTutoKey();
          tutorial = true;
      }
    }

    void Update()
    {//marche pas
        if (tutorial)
        {
            timer = -Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0f)
            {
                uiController.HideTutoKey();
                tutorial = false;
            }
        }
    }
}


