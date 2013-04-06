using UnityEngine;
using System.Collections;

public class GroundC : MonoBehaviour
{
	OTAnimatingSprite ground;
	public bool isAlive = true;
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			collider.SendMessage("AddCollisionArray", 1);//number should be enumerator
			Decay();
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			//remove ground
			collider.SendMessage("RemoveCollisionArray", 1);
		}
	}
	
	public void Decay()
	{
		ground = (OTAnimatingSprite)OT.ObjectByName (gameObject.name);
		
		if (isAlive == true)
		{
			ground.PlayOnce ("Decay");
			isAlive = false;
		}
	}
	
	public void Heal()
	{
		if (!isAlive)
		{
			ground.PlayBackward ("Decay");
			isAlive = true;
		}
	}
}
