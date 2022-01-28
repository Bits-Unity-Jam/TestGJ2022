using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMnager : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    public void BuyItem() 
    {
        var curentItem = items[0];

        if (CoinManager.Instance.CoinCount >= curentItem.cost)//curentItem.Cost)
        {
            CoinManager.Instance.CoinCount = -curentItem.cost;//curentItem.Cost;
            print("заебок");
            //curentItem.IsByed = true;
        }
        
    }


}
