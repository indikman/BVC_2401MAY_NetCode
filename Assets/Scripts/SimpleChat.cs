using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class SimpleChat : NetworkBehaviour
{
    [SerializeField] private TMP_InputField txtName;
    [SerializeField] private TMP_InputField txtMessage;
    [SerializeField] private TMP_Text txtChatView;

    private string _userName;
    
    public void SetUserName()
    {
        _userName = txtName.text;
        Debug.Log($"Username set to {_userName}");
    }

    public void SendMessage()
    {
        string message = $"<b>{_userName} :</b> {txtMessage.text}\n";
        DisplayMessageRpc(message);
    }

    private void DisplayMessage(string message)
    {
        txtChatView.text += message;
        txtMessage.text = "";
    }

    [Rpc(SendTo.Everyone)]
    private void DisplayMessageRpc(string message, RpcParams rpcParams=default)
    {
        DisplayMessage(message);
        DisplayMessage($"<i>clientID {rpcParams.Receive.SenderClientId}</i>");
    }
}
