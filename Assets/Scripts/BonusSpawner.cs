using System;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
   [SerializeField] private GameObject _bonusPrefab;
   [SerializeField] private Transform[] _spawnPoints;
   private int _spawnPointIndex;
   private void OnEnable()
   {
      Player_Collect.OntargetCollected += SpawnNewBonus ;
   }

   private void OnDisable()
   {
      Player_Collect.OntargetCollected -= SpawnNewBonus;
   }

   private void SpawnNewBonus(int score)
   {
      if (_spawnPointIndex >= _spawnPoints.Length)
      {
         return;
      }
      Instantiate(_bonusPrefab, _spawnPoints[_spawnPointIndex].position,_spawnPoints[_spawnPointIndex].rotation);
      _spawnPointIndex++;
   }
}
