using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList = new List<KitchenObjectSO>();

    private List<KitchenObjectSO> kitchenObjectsListSO = new List<KitchenObjectSO>();

    public bool TryAddIngrediate(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO)) return false;

        if (kitchenObjectsListSO.Contains(kitchenObjectSO))
        {
            return false;
        }
        else
        {
            kitchenObjectsListSO.Add(kitchenObjectSO);
            return true;
        }
    }
}
