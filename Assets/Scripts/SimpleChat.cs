using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleChat : MonoBehaviour
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
        txtChatView.text += $"\n<b>{_userName} :</b> {txtMessage.text}";
        txtMessage.text = "";
    }
}
