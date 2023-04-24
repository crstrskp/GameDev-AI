using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour, IDestructible
{
    public void OnDestruction(GameObject destroyer)
    {
        Debug.Log("Destroyed: " + gameObject.name + " by " + destroyer.name);
        Destroy(gameObject);
    }
}
