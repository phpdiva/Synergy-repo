using UnityEngine;
using System.Collections;

public class Stem : MonoBehaviour
{
    // Update is called once per frame
    private void AnimationFinished(string frameSetName)
    {
        string parentName = this.transform.parent.name;
        string animationName = "Grow" + parentName.Remove(0, 9);                    //removes pollenate and gets the name of the plants direction
        Transform seed = this.transform.parent.FindChild("SeedComponent");
        seed.gameObject.GetComponent<AnimateSprite>().PlayAnimation(animationName, 1, true);
    }
}
