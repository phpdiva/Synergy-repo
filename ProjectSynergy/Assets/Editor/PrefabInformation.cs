using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR 
public class PrefabInformation : MonoBehaviour
{

    List<GameObject> FindAllPrefabInstances(string name)//UnityEngine.Object myPrefab
    {
        List<GameObject> result = new List<GameObject>();
        GameObject[] allObjects = (GameObject[])FindObjectsOfType(typeof(GameObject));
        foreach (GameObject GO in allObjects)
        {
            if (PrefabUtility.GetPrefabType(GO) == PrefabType.PrefabInstance)  //if the prefab type of the object is = user created prefab
            {
                UnityEngine.Object GO_prefab = PrefabUtility.GetPrefabParent(GO);
                if (name == GO_prefab.name)
                    result.Add(GO);
            }

            if (PrefabUtility.GetPrefabType(GO) == PrefabType.Prefab)  //if the prefab type of the object is = user created prefab
            {
                UnityEngine.Object GO_prefab = PrefabUtility.GetPrefabParent(GO);
                if (name == GO_prefab.name)
                    result.Add(GO);
            }
        }
        return result;
    }
}
#endif