using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedArgs> OnIngredientAdded;
    public class OnIngredientAddedArgs: EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

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
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedArgs { kitchenObjectSO = kitchenObjectSO });
            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectsListSO;
    }
}
