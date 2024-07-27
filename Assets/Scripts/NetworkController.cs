using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class NetworkController : MonoBehaviour
{
    public UnityEvent onStartHost;
    public UnityEvent onStartClient;
    
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        onStartHost?.Invoke();
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        onStartClient?.Invoke();
    }
}
