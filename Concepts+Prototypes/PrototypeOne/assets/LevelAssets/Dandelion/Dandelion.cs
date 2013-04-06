using UnityEngine;
using System.Collections;

public class Dandelion : MonoBehaviour
{
	
	OTAnimatingSprite DandelionExplode;
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == ("player"))
		{
			HealEnvironment ();
			
			DandelionExplode = (OTAnimatingSprite)OT.ObjectByName ("DandelionExplode");
			DandelionExplode.depth = 0;
			DandelionExplode.Play ();
			
			Destroy (gameObject);
		}
	}
	
	void HealEnvironment()
	{
		// call the function in all grass onjects
		GameObject[] allGround = GameObject.FindGameObjectsWithTag ("Ground");
		GameObject[] allLadder = GameObject.FindGameObjectsWithTag ("Ladder");
			
		//FindGameObjectsWithTag("Ground") && GameObject.FindGameObjectsWithTag("Ladder"); 
		foreach (GameObject Ground in allGround)
		{
			Ground.SendMessage ("Heal");
		} 
		
		//Find nicer way of doing this.
		foreach (GameObject Ladder in allLadder)
		{
			Ladder.SendMessage ("Heal");
		} 
	}
}
