using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * CURRENT ISSUES
 *
 */

public class PlayerC : MonoBehaviour
{
	public enum enCollisionTypes
	{
		NoCollision = 0,
		Ground,
		Ladder,
		Leaf
	};
	private enCollisionTypes collisionPriority = enCollisionTypes.NoCollision;
	private List<int> collisions = new List<int> ();
	
	private enum enKeyPress
	{
		Left,
		Right,
		Up,
		Down
	};
	private enKeyPress enKey;
	public float moveSpeed = 100;
	public int jumpHeight = 200;
	public int gravityForce = 400;
	//private int jumps = 0;
	OTAnimatingSprite playerAnim;
	
	void Update()
	{
		Movement();
	}
	
	//takes an int which represents both the priority level of the colliding object and the objects id.
	//The priority level decides which set of movement rules to apply when for example, ground and vines are both colliding
	void AddCollisionArray(int collisionIDAndPriorityNumb)
	{
		//Overide current priority if this new collision value is greater
		if ((enCollisionTypes)collisionIDAndPriorityNumb > collisionPriority)
		{
			collisionPriority = (enCollisionTypes)collisionIDAndPriorityNumb;
		}
		
		collisions.Add(collisionIDAndPriorityNumb);
	}
	
	//Removes collisions from the list and checks if it has effected the priority
	void RemoveCollisionArray(int collisionIDAndPriorityNumb)
	{
		collisions.Remove(collisionIDAndPriorityNumb);
		
		if (collisions.Count <= 0)
		{
			collisionPriority = enCollisionTypes.NoCollision;	
		} 
		else
		{
			foreach (int collisionC in collisions)
			{
				if ((enCollisionTypes)collisionC > collisionPriority)
				{
					collisionPriority = (enCollisionTypes)collisionC;
				}
			}
		}
	}
	
	void Movement()
	{
		//Edge of map collision
		transform.position = ClampVector3(transform.position, GameManagerC.GetMinBoundary(), GameManagerC.GetMaxBoundary());//Refactor
		
		switch (collisionPriority)
		{
			#region enCollisionTypes.NoCollision
		case enCollisionTypes.NoCollision:
			{
				//Debug.Log("onNothing");
				
				//Gravity
				rigidbody.AddForce(0, -gravityForce, 0);
				if (Input.GetButton("Left"))
				{  
					rigidbody.velocity = new Vector3 (-moveSpeed, rigidbody.velocity.y, 0);
				}
				if (Input.GetButton("Right"))
				{
					rigidbody.velocity = new Vector3 (moveSpeed, rigidbody.velocity.y, 0);
				}
			}
			break;
			#endregion
			
			#region enCollisionTypes.Ground
		case enCollisionTypes.Ground:
			{
				//Gravity
				rigidbody.velocity = new Vector3 (0, 0, 0);
				
				//Keys
				if (Input.GetButton("Left"))
				{  
					rigidbody.velocity = new Vector3 (-moveSpeed, 0, 0);
				}
				if (Input.GetButton("Right"))
				{
					rigidbody.velocity = new Vector3 (moveSpeed, 0, 0);
				}
				if (Input.GetButton("Up"))
				{
					rigidbody.velocity = new Vector3 (0, jumpHeight, 0);//hard progaming jumpHeight breaks it
				}
			}
			break;
			#endregion
			
			#region enCollisionTypes.Ladder
		case enCollisionTypes.Ladder:
			{
				//Debug.Log("onLadder");
				rigidbody.velocity = new Vector3 (0, 0, 0);  //Character is holding on to ladder to stop movement unless pusing.
					
				if (Input.GetButton("Left"))
				{  
					rigidbody.velocity = new Vector3 (- moveSpeed, 0, 0);
				}
				if (Input.GetButton("Right"))
				{
					rigidbody.velocity = new Vector3 (moveSpeed, 0, 0);
				}
				if (Input.GetButton("Up"))
				{
					rigidbody.velocity = new Vector3 (rigidbody.velocity.x, moveSpeed, 0);		
				}
				if (Input.GetButton("Down"))
				{
					rigidbody.velocity = new Vector3 (rigidbody.velocity.x, -moveSpeed, 0);
				}
			}
			break;
			#endregion
			
			#region enCollisionTypes.Leaf
		case enCollisionTypes.Leaf:
			{
				//placeholder
			}
			break;
			#endregion
		}
	}
	
	public static Vector3 ClampVector3(Vector3 vec, Vector3 min, Vector3 max)
	{
		return Vector3.Min(max, Vector3.Max(min, vec));
	}
}
