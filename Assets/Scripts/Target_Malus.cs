using UnityEngine;

public class Target_Malus : MonoBehaviour
{
    public bool MalusActivated = false;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] MusicManager sfxSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            ToggleVisibility(false);
            MalusActivated = true;
            _playerMovement.ActivateMalus();
            Debug.Log("Malus activated");
            sfxSource.PlayMalusSound();
        }
    }
    

    private void ToggleVisibility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }
}
