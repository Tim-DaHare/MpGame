using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerList : NetworkBehaviour {

    public List<GameObject> connectedPlayersList = new List<GameObject>();

    private void OnPlayerConnected(NetworkPlayer player)
    {
        Rpc_RefreshConnectedPlayersList();
    }

    private void OnPlayerDisconnected(NetworkPlayer player)
    {
        Rpc_RefreshConnectedPlayersList();
    }

    [ClientRpc]
    void Rpc_RefreshConnectedPlayersList()
    {
        connectedPlayersList.Clear();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            connectedPlayersList.Add(player);
        }
    }

}
