using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Crafting/New Ingredient", fileName = "Ingredient.asset")]
public class CraftingIngredient : ScriptableObject
{
    public ItemData IngredientItem;
    public int RequiredAmount;
}
