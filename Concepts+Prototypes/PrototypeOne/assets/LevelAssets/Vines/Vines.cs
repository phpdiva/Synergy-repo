using UnityEngine;
using System.Collections;

public class Vines : MonoBehaviour
{
	OTAnimatingSprite vines;
	public bool isAlive = true;

	void Start()
	{
		vines = this.GetComponent<OTAnimatingSprite>();
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			collider.SendMessage("AddCollisionArray", 2);//number should be enumerator
			Decay();
		}
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			//remove ground
			collider.SendMessage("RemoveCollisionArray", 2);
		}
	}
	
	public void Decay()
	{
		vines = (OTAnimatingSprite)OT.ObjectByName(gameObject.name);
		
		if (isAlive == true)
		{
			vines.Play();
			isAlive = false;
		}
	}
	
	public void Heal()
	{
		if(!isAlive)
		{
			vines.PlayBackward(vines._animationFrameset);
			isAlive = true;
		}
	}
}
