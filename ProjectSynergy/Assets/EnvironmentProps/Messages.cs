using UnityEngine;
using System.Collections;

public class Messages : MonoBehaviour 
{
    public Texture texture;

    private void OnTriggerEnter(Collider collider)
    {
        renderer.material.mainTexture = texture;
    }
}
