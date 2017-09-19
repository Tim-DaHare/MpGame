using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SkinManager : NetworkBehaviour
{
    public GameObject[] players;
    //Herringering: check OnStartClient voor misschien minder omslachtigheid.
    void Start()
    {
        if (isLocalPlayer)
        {
            StartCoroutine(SkinPlayers());           
        }
        else
        {
            StartCoroutine(SkinNewPlayer(gameObject));
        }

    }

    private IEnumerator SkinPlayers()
    {
        //Wait untill the player id is set
        while (string.IsNullOrEmpty(GetComponent<PlayerInfo>().playerAccountId))
        {
            yield return null;
        }

        //get an array of all the player objects and then skin them
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            StartCoroutine(SkinPlayer(player, player.GetComponent<PlayerInfo>().playerAccountId));
        }
    }

    private IEnumerator SkinNewPlayer(GameObject obj)
    {
        while (string.IsNullOrEmpty(obj.GetComponent<PlayerInfo>().playerAccountId))
        {
            yield return null;
        }
        Rpc_SkinNewPlayer(obj);
    }

    //Tell all clients to skin a player
    [ClientRpc]
    private void Rpc_SkinNewPlayer(GameObject obj)
    {
        StartCoroutine(SkinPlayer(obj, obj.GetComponent<PlayerInfo>().playerAccountId));
    }

    //Skin a player
    [Client]
    private IEnumerator SkinPlayer(GameObject obj, string accountId)
    {
        string url = @"http://localhost/GameWebsite/web/uploads/skins/" + accountId + ".png";
        SkinnedMeshRenderer[] meshRenderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>();

        WWW www = new WWW(url);
        //Returning the www object will automatically wait until the download is done
        yield return www;

        //Only skin player if no errors found
        if (string.IsNullOrEmpty(www.error))
        {
            meshRenderers[1].material.mainTexture = www.texture;          
        }
        //Errors
        else
        {
            Debug.Log("Skin niet gevonden voor Id: " + accountId);
            Debug.Log(www.error);
        }
    }
}