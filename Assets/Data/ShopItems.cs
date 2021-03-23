using System;
using System.Collections.Generic;
using UnityEngine;

// Тут будут все все все товары 
//[CreateAssetMenu(menuName = "Create Shop Items Collection")]
public class ShopItems : ScriptableObject
{
    [SerializeField] public List<ScriptableObject> playerSkins;
    [SerializeField] public List<ScriptableObject> musicInstruments;
    public List<Backgrounds> allBackgrounds;

    [Serializable]
    public struct Backgrounds 
    {
        [SerializeField] public string shopName;
        [SerializeField] public GameObject backgroundGameObject;
        [SerializeField] public Sprite shopImage;
        [SerializeField] public int shopCost;
        [SerializeField] public bool isPurchased;
    }

    public List<Backgrounds> GetBackgrounds()
    {
        return allBackgrounds;
    }

    public List<ScriptableObject> GetSkins()
    {
        return playerSkins;
    }
}
