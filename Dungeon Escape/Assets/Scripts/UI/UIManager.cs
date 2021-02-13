using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is null");

            return _instance;
        }
    }

    public Text playerGemCount;
    public Text gemCountText;
    public Image selection;
    public Image[] lives;

    public void OpenShop(int gemsCount)
    {
        playerGemCount.text = gemsCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selection.rectTransform.anchoredPosition = new Vector2(selection.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        _instance = this;    
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                lives[i].enabled = false;
            }
        }
    }
}
