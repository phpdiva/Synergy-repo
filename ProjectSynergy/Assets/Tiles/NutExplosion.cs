using UnityEngine;
using System.Collections;

public class NutExplosion : MonoBehaviour
{
    private void AnimationFinished(string frameSetName)
    {
        LevelManager.levelManager.healingFinished = true;
        Destroy(this.gameObject);
    }
}
