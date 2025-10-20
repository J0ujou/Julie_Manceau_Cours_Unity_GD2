using Unity.VisualScripting;
using UnityEngine;

public class Memory_Zone : MonoBehaviour
{
    public bool keycollected = false;

    void OncollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() != null && keycollected == true)
        {
            //TO DO: appeller une fonction dans target fragment qui reaffiche tout les target fragment pendant 5 sec
        }
    }
}   