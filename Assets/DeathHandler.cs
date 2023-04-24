using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour, IDestructible
{
    public void OnDestruction(GameObject destroyer)
    {
        Destroy(gameObject);
    }
}
