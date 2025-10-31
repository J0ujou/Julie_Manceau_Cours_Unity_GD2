using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _keyText;
    [SerializeField] private Player_Collect _playerCollect;
    [SerializeField] MusicManager musicSource;
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
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Debug.Log("Level 2");
            _playerCollect.gameStarted= true;
            StartPanel.SetActive(false);
            musicSource.PlayGameMusic();
            // play game music ne marche pas
        }
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
        //TO DO: bloquer les mouvements du joueur
        musicSource.PlayVictoryMusic();
    }

    public void ClickStart()
    {
        UpdateScore(0);
		UpdateScorekey(0);
        musicSource.PlayGameMusic();
        StartPanel.SetActive(false);
        DefeatPanel.SetActive(false);
        _playerCollect.gameStarted = true;
        Debug.Log("game started");
    }
	
	public void ResetGame()
    {
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            SceneManager.LoadScene("Level_2");  
        }
        else
        {
            SceneManager.LoadScene("Level_1");  
        }
    }
    
    public void QuitGame()
    {
        Debug.Log("QuitGame called");
        Application.Quit();
    }

    public void ShowDefeat()
    {
        DefeatPanel.SetActive(true);
        _playerCollect.gameStarted = false;
        //TO DO: Bloquer les mouvements du joueur
        musicSource.PlayGameOverMusic();
    }

	public void NextLevel()
	{
        SceneManager.LoadScene("Level_2");
    }

   
}    
