using System;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
  [SerializeField] private ScoreDatas _scoreData;
  [SerializeField] private UIController _uiController;
  public int maxScore = 5;
  public float timer = 60f;
  public bool gameStarted=false;
  public bool victory = false;
  
  // Definition de l'action (event dispatcher), avec l'input entre <> ici un int
  public static Action<int> OntargetCollected;
  public void UpdateScore(int value)
  {
    _scoreData.ScoreValue = Mathf. Clamp(_scoreData.ScoreValue + value, 0, 5);
    //_uiController.UpdateScore(_scoreData.ScoreValue);
    // Call event dispatcher, en C# on invoke avec l'input entre parenthèses
    OntargetCollected?.Invoke(_scoreData.ScoreValue);

    if (_scoreData.ScoreValue >= maxScore)
    {
      _uiController.ShowVictory();
      victory = true;
    }
  }

  private void Update()
  {
    if (gameStarted)
    {
      timer -= Time.deltaTime;
      Debug.Log("Timer : " + timer);
      _uiController.UpdateTimer(timer);

      if (timer <= 0f)
      {
        timer = 60f;
        gameStarted = false;
        if (victory==false)
        {
          _uiController.ShowDefeat();
        }
      }
    }
  }
}
