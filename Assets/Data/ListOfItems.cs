using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Item List")]
public class ListOfItems : ScriptableObject
{
    public List<Item> itemList;
}