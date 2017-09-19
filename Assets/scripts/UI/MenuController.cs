using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    GameObject facialExpresssionsMenu;

    [SerializeField]
    GameObject[] menusToDisable;

    void ReturnButton()
    {
        CloseAllSubMenus();
    }

    void FacialExpressionsButton()
    {
        CloseAllSubMenus();
        facialExpresssionsMenu.SetActive(true);
    }

    void CloseAllSubMenus()
    {
        foreach (GameObject obj in menusToDisable)
        {
            obj.SetActive(false);
        }
    }
}
