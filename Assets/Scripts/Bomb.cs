using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Bomb : NetworkBehaviour
{
    public ulong clientID;
    
    // after 2 secods delay, despawn the bomb.
    
    void Start()
    {
        StartCoroutine(DestroyAfter(2));
    }

    private IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyBomb();
    }

    private void DestroyBomb()
    {
        this.NetworkObject.Despawn();
    }
    
}
