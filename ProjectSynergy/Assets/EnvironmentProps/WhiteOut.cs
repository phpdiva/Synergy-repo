using UnityEngine;
using System.Collections;

public class WhiteOut : MonoBehaviour 
{
	public float speed = 0.5f;
	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<AnimateRGB>().SetRGBA(4, 0, speed);
	}
}
