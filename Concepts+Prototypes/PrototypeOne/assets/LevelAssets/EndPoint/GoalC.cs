using UnityEngine;
using System.Collections;

public class GoalC : MonoBehaviour 
{
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			
			int nextLevel = Application.loadedLevel;
			nextLevel++;
			Application.LoadLevel(nextLevel);
			//collider.SendMessage("AddCollisionArray", 2);//number should be enumerator
		}
	}
}
