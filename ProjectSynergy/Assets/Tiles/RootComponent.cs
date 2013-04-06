using UnityEngine;
using System.Collections;

public class RootComponent : MonoBehaviour
{
    public GameObject newPlantType;
    private Object HealPlantClone;
    private void AnimationFinished(string frameSetName)
    {
        ReplacePlant();
    }

    public void ReplacePlant()
    {
        Vector3 newPos = this.transform.root.position;
        Instantiate(newPlantType, newPos, Quaternion.identity); 
        Destroy(this.transform.parent.gameObject);
    }
}
