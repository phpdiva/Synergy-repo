using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractableObject : MonoBehaviour
{
    public bool startCorrupt = false;
    [HideInInspector]
    public bool isCorrupt = false;
    [HideInInspector]
    public Vector3 worldPosition;

    public AudioClip corruptSound;
    public AudioClip rejuvenateSound;

    private void Start()
    {
        if (startCorrupt)
        {
            gameObject.GetComponent<AnimateSprite>().SetFrameSet("idleCorrupt");
            LevelManager.levelManager.nonCorruptedObjects.Remove(gameObject);//take from one lsit
            LevelManager.levelManager.corruptedObjects.Add(gameObject);//and add to the other
            isCorrupt = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Corrupt();
        }
    }

    private void AnimationFinished(string frameSetName)
    {
        //LevelManager.levelManager.
    }

    public void Corrupt()
    {
        if (isCorrupt == false)
        {
            if (corruptSound != null)
            {
                audio.PlayOneShot(corruptSound);
            }
            gameObject.GetComponent<AnimateSprite>().PlayAnimation("Corrupt", 1);
            LevelManager.levelManager.nonCorruptedObjects.Remove(gameObject);//take from one lsit
            LevelManager.levelManager.corruptedObjects.Add(gameObject);//and add to the other
            isCorrupt = true;
        }
    }

    public void Rejuvenate(int corruptedObjectIndex)
    {
        if (corruptSound != null)
        {
            audio.PlayOneShot(rejuvenateSound);
        }
        AnimateSprite animateSprite = gameObject.GetComponent<AnimateSprite>();
        animateSprite.PlayAnimation("Rejuvenate", 1);
        isCorrupt = false;

        GameObject healedGameObject = LevelManager.levelManager.corruptedObjects[corruptedObjectIndex];//find object
        LevelManager.levelManager.nonCorruptedObjects.Add(healedGameObject);//add to heal list
        LevelManager.levelManager.corruptedObjects.RemoveAt(corruptedObjectIndex);//remove from corrupt list

    }

    public void voidRejuvenate()
    {
        audio.PlayOneShot(rejuvenateSound);
        AnimateSprite animateSprite = gameObject.GetComponent<AnimateSprite>();
        animateSprite.PlayAnimation("voidRejuvenate", 1);
    }

    public virtual void TriggerObject(Player player)
    {
        //overide with functionality
    }
    public virtual void TriggerObject()
    {
    }
}


//public virtual void PlayerCollision(Player player)
//{
//    if (isCorrupt == false)
//    {
//        if (canCorrupt == true)
//        {
//            Corrupt();
//        }
//        TriggerObject(player);                                              //how to decide which function to call?
//        TriggerObject();
//    }
//}