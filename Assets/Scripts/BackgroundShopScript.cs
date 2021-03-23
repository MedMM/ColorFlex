using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundShopScript : MonoBehaviour
{
    [SerializeField] ShopItems shopItems; //Ссылка на ScriptableObject со всеми товарами из магазина
    [SerializeField] PlayerData playerData; //Ссылка на ScriptableObject с данными игрока
    [SerializeField] Text moneyText; //UI елемент отображающий деньги
    [SerializeField] Color transparentColor; //Прозрачный цвет
    [SerializeField] Color opaqueColor; //Непрозрачный цвет

    List<ShopItems.Backgrounds> backgrounds; //Лист всех фонов
    GameObject backgroundTemplate; // Пример игрового обьекта бекграунда на сцене
    int currentBackgroundIndex = 0;
    int backgroundCount = 0;


    void Start()
    {
        UpdateMoneyValueInUI();

        backgrounds = shopItems.GetBackgrounds();
        backgroundTemplate = transform.GetChild(0).gameObject;

        for (int i = 0; i < backgrounds.Count; i++)
        {
            GameObject g = Instantiate(backgroundTemplate, this.gameObject.transform);
            g.name =  $"BG_{backgrounds[i].shopName}";
            g.GetComponent<Image>().sprite = backgrounds[i].shopImage;
            g.GetComponent<Image>().color = opaqueColor;
            g.transform.GetChild(0).GetComponent<Text>().text = backgrounds[i].shopName;

            g.SetActive(false);
        }

        backgroundCount = transform.childCount;
    }

    public void ShowNextBackground()
    {
        if(currentBackgroundIndex >= backgroundCount - 1) { return; }
        currentBackgroundIndex++;
        ShowBackground(currentBackgroundIndex);
    }

    public void ShowPreviousBackground()
    {
        if (currentBackgroundIndex <= 0) { return; }
        currentBackgroundIndex--;
        ShowBackground(currentBackgroundIndex);
    }

    public void ShowBackground(int index)
    {
        for (int i = 0; i < backgroundCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(index == i);
        }
    }

    public void UpdateMoneyValueInUI()
    {
        moneyText.text = playerData.GetMoney().ToString();
    }
}
