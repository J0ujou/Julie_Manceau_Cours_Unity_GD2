using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    // Fonction appelé à chaque activation du monobehaviour
    private void OnEnable()
    {
        //Bind entre la fonction UpdateScore et l'action OnTargetCollected
        Player_Collect.OntargetCollected += UpdateScore;
    }

    // Fonction appelée à chaque désactivation du MonoBehaviour
    private void OnDisable()
    {
        // Unbind entre la fonction UpdateScore et l'action OnTargetCollection
        Player_Collect.OntargetCollected -= UpdateScore;
    }
    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int newScore)
    {
        _scoreText.text = $"Score : {newScore.ToString()}";
    }
}    
