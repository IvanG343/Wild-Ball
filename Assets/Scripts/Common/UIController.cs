using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject actionTipPanel;

    public void ShowActionTip()
    {
        actionTipPanel.SetActive(true);
    }

    public void HideActionTip()
    {
        actionTipPanel.SetActive(false);
    }

}
