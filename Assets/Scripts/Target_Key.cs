using System;
using UnityEngine;

public class Target_Key : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] Memory_Zone _memoryZone;
    [SerializeField] MusicManager sfxSource;
    [SerializeField] UIController uiController;
    [SerializeField] private GameObject _particuleEffect;

    void Awake()
    {
        _particuleEffect.SetActive(false);
    }

    void Start()
    {
        _memoryZone.keycollected = false;
    }
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
          _particuleEffect.SetActive(true);
      }
    }
}


