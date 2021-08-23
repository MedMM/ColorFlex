using UnityEngine;
using System.Collections.Generic;
using Components;

[CreateAssetMenu(menuName = "Create new Player Data")]
public class PlayerData : ScriptableObject
{
    public enum ControlsType
    {
        Solid,
        Smooth
    }

    [SerializeField] private int money;
    [SerializeField] private Item playerSkinItem;
    [SerializeField] private Item musicItem;
    [SerializeField] private Item backgroundItem;
    [SerializeField] private ControlsType controlsType;
    private List<Item> itemlist = new List<Item> { };

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int count)
    {
        money += count;
    }

    public void MinusMoney(int count)
    {
        money -= count;
    }

    public void SetItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.playerSkin:
                playerSkinItem = item;
                break;
            case Item.ItemType.Music:
                musicItem = item;
                break;
            case Item.ItemType.Background:
                backgroundItem = item;
                break;
            default:
                Debug.LogWarning("Unexpected Type");
                break;
        }
    }

    public bool IsItemSelected(Item item)
    {
        return (item == playerSkinItem || item == musicItem || item == backgroundItem);
    }

    public Component GetControlsScript(GameObject gameObject)
    {
        switch (controlsType)
        {
            case ControlsType.Solid:
                return new SolidController();
            case ControlsType.Smooth:
                return new SmoothController();
            default:
                throw new System.ArgumentNullException("Parameter cannot be null");
        }

        
    }

    public void SetControlsType(ControlsType controlsType)
    {
        this.controlsType = controlsType;
    }
}