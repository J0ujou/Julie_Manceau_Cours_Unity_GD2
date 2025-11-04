using System;
using UnityEngine;
using System.Collections;

public class Memory_Zone : MonoBehaviour
{
	[SerializeField] MusicManager sfxSource;
	[SerializeField] UIController uiController;
    public bool keycollected = false;
    //public bool zone = false;
    public int nbenter = 0;
	
	void OnTriggerEnter(Collider other)
    {
	    if (other.gameObject.GetComponent<Player_Collect>() != null && keycollected == true)
	    {
		    //zone = true;
		    nbenter = nbenter + 1;
		    Debug.Log(nbenter);
		    Debug.Log("ZONE");
		    sfxSource.PlayMemoryZoneSound();
			if (nbenter <=1)
			{
				uiController.ShowTutoMemory();
				uiController.HideTutoKey();
			}
		    Target_Fragment[] fragments = FindObjectsByType<Target_Fragment>(FindObjectsSortMode.None);
		    foreach (var f in fragments)
		    {
			    if (f != null)
			    {
				    f.Hide(true);
			    }

		    }
			
	    }
    }
	
	void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player_Collect>()!= null && keycollected == true)
		{
			//zone= false;
			Target_Fragment[] fragments = FindObjectsByType<Target_Fragment>(FindObjectsSortMode.None);
			foreach (var f in fragments)
			{
				if (f != null)
				{
					f.Hide(false);
				}

			}
			if (nbenter <=1)
			{
				uiController.HideTutoMemory();
			}
		}
	}
}   