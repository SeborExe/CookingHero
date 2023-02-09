using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeList_", menuName = "Recipe List")]
public class RecipeListSO : ScriptableObject
{
    public List<RecipeSO> recipeSOList;
}
