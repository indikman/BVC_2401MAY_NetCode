using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private Dictionary<ulong, string> _playerNames = new Dictionary<ulong, string>();
    private Dictionary<ulong, int> _playerScores = new Dictionary<ulong, int>();

    public string LocalPlayerName;
    [SerializeField] private TMP_InputField txtPlayerName;
    [SerializeField] private TMP_Text txtScores;

    public void SetLocalPlayerName()
    {
        LocalPlayerName = txtPlayerName.text;
        Debug.Log($"Local player name: {LocalPlayerName}");
    }

    public void OnPlayerJoined(ulong playerClientID, string playerName)
    {
        _playerScores.Add(playerClientID, 0);
        _playerNames.Add(playerClientID, playerName);
        UpdateScores();
    }

    private void UpdateScores()
    {
        txtScores.text = $"Local Player: {LocalPlayerName}\n\n";

        foreach (var item in _playerNames)
        {
            // Player <key>: <name> : <score>\n
            txtScores.text += $"Player {item.Key}: {item.Value} : {_playerScores[item.Key]}\n";
        }
    }
}
