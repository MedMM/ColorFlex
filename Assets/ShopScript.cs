using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] Text playerMoneyText;
    [SerializeField] List<Item> items;
    [SerializeField] float outscreenPositionX = -1500;
    [SerializeField] float outscreenAnimationTime;
    private int currentItemIndex = 0;

    void Awake()
    {
        UpdatePlayerMoney();
        currentItemIndex = 0;
        ShowItem(currentItemIndex);
    }

    void UpdatePlayerMoney()
    {
        playerMoneyText.text = playerData.GetMoney().ToString();
    }

    public void ShowNextItem()
    {
        if (currentItemIndex >= items.Count - 1) { return; }
        currentItemIndex++;
        ShowItem(currentItemIndex);
    }

    public void ShowPreviousItem()
    {
        if (currentItemIndex <= 0) { return; }
        currentItemIndex--;
        ShowItem(currentItemIndex);
    }

    private void ShowItem(int index)
    {
        if (index > items.Count) { return; }
        Item item = items[index];
        gameObject.SetActive(true);
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = item.shopImage; //change sprite
        gameObject.transform.GetChild(1).GetComponent<Text>().text = item.shopName; // change item description
        gameObject.transform.GetChild(2).GetComponent<Text>().text = item.isPurchased ? "Bought✓" : item.shopCost.ToString(); //change text cost
        gameObject.transform.GetChild(3).gameObject.GetComponentInChildren<Text>().text = "Buy"; //change text on buy button
        gameObject.transform.GetChild(3).GetComponent<Button>().interactable = true;
        if (item.isPurchased)
        {
            gameObject.transform.GetChild(3).gameObject.GetComponentInChildren<Text>().text = playerData.IsItemSelected(item)? "Selected" : "Select";
            gameObject.transform.GetChild(3).GetComponent<Button>().interactable = !playerData.IsItemSelected(item);
        }
    }

    public void SetShopItems(ListOfItems list)
    {
        currentItemIndex = 0;
        items = list.itemList;
        ShowItem(0);
    }

    public void BuyItem()
    {
        //Debug.Log(playerData.IsItemSelected(items[currentItemIndex]));

        if (items[currentItemIndex].shopCost <= playerData.GetMoney())
        {
            items[currentItemIndex].isPurchased = true;
            playerData.MinusMoney( items[currentItemIndex].shopCost);
        }
        else if (items[currentItemIndex].isPurchased)
        {

        }
        else
        {
            LeanTween.rotateZ(playerMoneyText.gameObject, 90, 0.2f).setLoopPingPong(2);
            return;
        }
        playerData.SetItem(items[currentItemIndex]);
        ShowItem(currentItemIndex);
        UpdatePlayerMoney();
    }
}
