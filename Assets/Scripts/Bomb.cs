using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Bomb : NetworkBehaviour
{
    public ulong clientID
    {
        get;
        private set;
    }
    
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

    // This will only be executed in the server side
    public void UpdateClientID(ulong clientID)
    {
        this.clientID = clientID;
        UpdateClientIDClientRpc(clientID);
    }
    
    // This will be executed in the client side
    [Rpc(SendTo.NotServer)]
    private void UpdateClientIDClientRpc(ulong clientID)
    {
        this.clientID = clientID;
    }
}
