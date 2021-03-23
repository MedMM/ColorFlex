using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        playerSkin,
        Music,
        Background 
    }

    [SerializeField] private GameObject gameObject;
    [SerializeField] public ItemType itemType;
    [SerializeField] public string shopName;
    [SerializeField] public Sprite shopImage;
    [SerializeField] public int shopCost;
    [SerializeField] public bool isPurchased;
}