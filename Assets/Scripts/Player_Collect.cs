using System;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
  [SerializeField] private ScoreDatas _scoreData;
  [SerializeField] private UIController _uiController;
  
  // Definition de l'action (event dispatcher), avec l'input entre <> ici un int
  public static Action<int> OntargetCollected;
  public void UpdateScore(int value)
  {
    _scoreData.ScoreValue = Mathf. Clamp(_scoreData.ScoreValue + value, 0, _scoreData.ScoreValue+ value);
    //_uiController.UpdateScore(_scoreData.ScoreValue);
    // Call event dispatcher, en C# on invoke avec l'input entre parenthèses
    OntargetCollected?.Invoke(_scoreData.ScoreValue);
  }
}
