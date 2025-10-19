using UnityEngine;

public class Target_Bonus : MonoBehaviour
{
    public bool BonusActivated = false;
    [SerializeField] PlayerMovement _playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            ToggleVisibility(false);
            BonusActivated = true;
            _playerMovement.ActivateBonus();
            Debug.Log("Bonus activated");
        }
    }
    

    private void ToggleVisibility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
}  
