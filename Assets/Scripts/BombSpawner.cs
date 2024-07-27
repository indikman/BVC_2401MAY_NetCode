using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BombSpawner : NetworkBehaviour
{
    [SerializeField] private NetworkObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //if i am a server, then just spawn
            if (IsServer && IsLocalPlayer)
            {
                PlaceBomb(OwnerClientId);
            }else if (IsClient && IsLocalPlayer) // if I am a client, then ask the server to spawn the bomb
            {
                PlaceBombRpc(); // this will executed in the server only
            }
            
        }
    }

    [Rpc(SendTo.Server)]
    private void PlaceBombRpc(RpcParams RpcParams=default)
    {
        PlaceBomb(RpcParams.Receive.SenderClientId);
    }

    private void PlaceBomb(ulong clientID)
    {
        // place a bomb over the network
        NetworkObject spawnedBomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        spawnedBomb.Spawn();
        spawnedBomb.GetComponent<Bomb>().clientID = clientID;
    }
}
