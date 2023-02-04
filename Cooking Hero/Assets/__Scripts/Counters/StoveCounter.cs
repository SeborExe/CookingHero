using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangeEventArgs> OnProgressChange;
    public event EventHandler<OnStatsChangedEventArgs> OnStateChanged;
    public class OnStatsChangedEventArgs : EventArgs
    {
        public State currentState;
    }

    [SerializeField] private FryingRecipeSO[] fryingRecipes;
    [SerializeField] private BurningRecipeSO[] burningRecipes;

    private float fryingTimer;
    private float burningTimer;
    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;
    private State currentState;

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }

    private void Start()
    {
        currentState = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (currentState)
            {
                case State.Idle:
                    break;

                case State.Frying:
                    fryingTimer += Time.deltaTime;

                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs { 
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimerMax });

                    if (fryingTimer > fryingRecipeSO.fryingTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelfe();
                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        currentState = State.Fried;
                        burningTimer = 0f;

                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnStateChanged?.Invoke(this, new OnStatsChangedEventArgs { currentState = currentState });
                    }
                    break;

                case State.Fried:
                    burningTimer += Time.deltaTime;

                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs {
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax });

                    if (burningTimer > burningRecipeSO.burningTimerMax)
                    {
                        //Fried
                        GetKitchenObject().DestroySelfe();
                        KitchenObject.SpawnKitchenObject(burningRecipeSO.output, this);
                        currentState = State.Burned;

                        OnStateChanged?.Invoke(this, new OnStatsChangedEventArgs { currentState = currentState });
                        OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs { progressNormalized = 0f });
                    }
                    break;

                case State.Burned:
                    break;
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    currentState = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStatsChangedEventArgs { currentState = currentState });

                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs { 
                        progressNormalized = fryingTimer / fryingRecipeSO.fryingTimerMax });
                }
                else if (HasBurnRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    currentState = State.Fried;
                    burningTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStatsChangedEventArgs { currentState = currentState });

                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs
                    {
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                    });
                }
            }
            else
            {
                //Player not carrying anything
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                //Player is carrying something
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
                currentState = State.Idle;

                OnStateChanged?.Invoke(this, new OnStatsChangedEventArgs { currentState = currentState });
                OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeEventArgs { progressNormalized = 0f });
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private bool HasBurnRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        BurningRecipeSO burnedRecipeSO = GetBurningRecipeSOWithInput(inputKitchenObjectSO);
        return burnedRecipeSO != null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipes)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }

        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (BurningRecipeSO burningRecipe in burningRecipes)
        {
            if (burningRecipe.input == inputKitchenObjectSO)
            {
                return burningRecipe;
            }
        }

        return null;
    }
}
