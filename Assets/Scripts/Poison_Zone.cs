using UnityEngine;

public class Poison_Zone : MonoBehaviour
{
   [SerializeField] UIController _uiController;
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<Player_Collect>() != null)
      {
         _uiController.ShowDefeat();
      }
   }
}
