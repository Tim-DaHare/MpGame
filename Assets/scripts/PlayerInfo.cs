using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInfo : NetworkBehaviour {

    [SyncVar]
    public string playerAccountId;

    void Start()
    {
        if (isLocalPlayer)
        {
            Cmd_SetPlayerId(PlayerPrefs.GetString("PlayerAccountId"));
        }
    }

    [Command]
    void Cmd_SetPlayerId (string id)
    {
        playerAccountId = id;
    }

    /*
    void RefreshPlayerList()
    {
        playerList.Clear();
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in playerObjects)
        {
            PlayerObjectAndId playerObjectAndId = new PlayerObjectAndId();
            playerObjectAndId.playerGameObject = obj;

            if (string.IsNullOrEmpty(obj.GetComponent<PlayerInfo>().playerAccountId))
            {
                Debug.LogError("geen Id gevonden voor speler.");
            }
            else
            {
                playerObjectAndId.playerAccountId = obj.GetComponent<PlayerInfo>().playerAccountId;
            }
            playerList.Add(playerObjectAndId);
        }
    }
    */

    //TIJDELIJK!!! Het ID WORD NIET VERWIJDERD ALS DIT GAMEOBJECT NIET IN DE SCENE IS!!!!
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("PlayerAccountId");
    }
}