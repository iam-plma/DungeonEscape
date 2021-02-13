using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPanel;
    public int currentSelectedItem = 1;
    public int currentItemCost = 400;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player = collision.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.gems);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            shopPanel.SetActive(false);
    }
    
    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(73);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-26);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-122);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.gems >= currentItemCost)
        {
            if (currentSelectedItem == 2)
                GameManager.Instance.HasKeyToCastle = true;

            _player.gems -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("not enough gems");
            shopPanel.SetActive(false);
        }
    }
}
