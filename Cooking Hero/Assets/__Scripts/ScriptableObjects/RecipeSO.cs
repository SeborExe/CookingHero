using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe_", menuName = "Recipe Object")]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> kitchenObjectSOList;
    public string recipeName;
}
