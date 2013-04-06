using UnityEngine;
using System.Collections;

public class RockC : MonoBehaviour 
{
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log("works");
			collision.collider.SendMessage("AddCollisionArray", 1);//number should be enumerator
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//remove ground
			collision.collider.SendMessage("RemoveCollisionArray", 1);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			collider.SendMessage("AddCollisionArray", 1);//number should be enumerator
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
}
