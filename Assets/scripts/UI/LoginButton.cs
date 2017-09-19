using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour {

    [SerializeField]
    private Text usernameText;
    [SerializeField]
    private Text passwordText;

    public void Login()
    {
        PlayerPrefs.SetString("PlayerAccountId", usernameText.text);
        SceneManager.LoadScene("scene");
    }
}
