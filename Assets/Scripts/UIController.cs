using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _keyText;
    [SerializeField] private Player_Collect _playerCollect;
    public GameObject VictoryPanel;
    public GameObject DefeatPanel;
    public GameObject StartPanel;

    // Fonction appelé à chaque activation du monobehaviour
    private void OnEnable()
    {
        //Bind entre la fonction UpdateScore et l'action OnTargetCollected
        Player_Collect.OntargetCollected += UpdateScore;
        Player_Collect.OnkeyCollected += UpdateScorekey;
    }

    // Fonction appelée à chaque désactivation du MonoBehaviour
    private void OnDisable()
    {
        // Unbind entre la fonction UpdateScore et l'action OnTargetCollection
        Player_Collect.OntargetCollected -= UpdateScore;
        Player_Collect.OnkeyCollected -= UpdateScorekey;
    }
    private void Start()
    {
        UpdateScorekey(0);
        UpdateScore(0);
        VictoryPanel.SetActive(false);
        DefeatPanel.SetActive(false);
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = $"Objets : {newScore.ToString()} / 5";
    }
    
    public void UpdateScorekey(int newScore)
    {
        _keyText.text = $"Clef: {newScore.ToString()} / 1";
    }
    
    public void UpdateTimer(float newTimer)
    {
        int minutes = Mathf.FloorToInt(_playerCollect.timer / 60);
        int seconds = Mathf.FloorToInt(_playerCollect.timer % 61);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowVictory()
    {
        VictoryPanel.SetActive(true);
    }

    public void ClickStart()
    {
        UpdateScore(0);
        StartPanel.SetActive(false);
        DefeatPanel.SetActive(false);
        _playerCollect.gameStarted = true;
        Debug.Log("game started");
    }
    
    public void QuitGame()
    {
        Debug.Log("QuitGame called");
        Application.Quit();
    }

    public void ShowDefeat()
    {
        DefeatPanel.SetActive(true);
    }
}    
