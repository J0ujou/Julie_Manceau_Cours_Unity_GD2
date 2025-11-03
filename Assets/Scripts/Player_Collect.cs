using System;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
  [SerializeField] private ScoreDatas _scoreData;
  [SerializeField] private UIController _uiController;
  [SerializeField] Memory_Zone _memoryZone;
  public int maxScore = 5;
  public float timer = 90f;
  public bool gameStarted=false;
  public bool victory = false;
  
  // Definition de l'action (event dispatcher), avec l'input entre <> ici un int
  public static Action<int> OntargetCollected;
  public static Action<int> OnkeyCollected;
  public void UpdateScore(int value)
  {
    _scoreData.ScoreValue = Mathf. Clamp(_scoreData.ScoreValue + value, 0, 5);
    //_uiController.UpdateScore(_scoreData.ScoreValue);
    // Call event dispatcher, en C# on invoke avec l'input entre parenthèses
    OntargetCollected?.Invoke(_scoreData.ScoreValue);

    if (_scoreData.ScoreValue >= maxScore)
    {
      _uiController.ShowVictory();
      victory = true; //sert à quoi??
    }
  }

  public void UpdateScorekey(int value)
  {
    _scoreData.NbKey = Mathf.Clamp(_scoreData.NbKey + value, 0, 1);
    //_uiController.UpdateScore(_scoreData.ScoreValue);
    // Call event dispatcher, en C# on invoke avec l'input entre parenthèses
    OnkeyCollected?.Invoke(_scoreData.NbKey);
    //if (_scoreData.NbKey >= maxScore)
    //{
      //_memoryZone.keycollected = true;
    //}
    //sert à quoi??
  }

  private void Update()
  {
    if (gameStarted)
    {
      timer -= Time.deltaTime;
      _uiController.UpdateTimer(timer);

      if (timer <= 0f)
      {
        timer = 90f;
        gameStarted = false;
        if (victory==false)
        {
          _uiController.ShowDefeat();
        }
      }
    }
	else
	{
		timer= 90f;
	}
  }
}
