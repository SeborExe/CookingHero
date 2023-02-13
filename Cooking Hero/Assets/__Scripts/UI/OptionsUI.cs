using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_Text soundEffectText;
    [SerializeField] private TMP_Text musicText;

    [Header("Key Bindings")]
    [SerializeField] private Binding MoveUpBinding;
    [SerializeField] private Binding MoveDownBinding;
    [SerializeField] private Binding MoveLeftBinding;
    [SerializeField] private Binding MoveRightBinding;
    [SerializeField] private Binding InteractBinding;
    [SerializeField] private Binding InteractAltBinding;
    [SerializeField] private Binding PauseBinding;
    [SerializeField] private Transform pressToRebindTransform;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        UpdateVisual();

        ChangePressToRebaindTransformVisibility(false);
        ChangeVisiblity(false);
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        ChangeVisiblity(false);
    }

    private void OnEnable()
    {
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        backButton.onClick.AddListener(() =>
        {
            ChangeVisiblity(false);
        });

        MoveUpBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.MoveUp); });
        MoveDownBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.MoveDown); });
        MoveLeftBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.MoveLeft); });
        MoveRightBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.MoveRight); });
        InteractBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.Interact); });
        InteractAltBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.InteractAlt); });
        PauseBinding.bindingButton.onClick.AddListener(() => { RebindBinding(GameInputs.Binding.Pause); });
    }

    private void OnDisable()
    {
        soundEffectsButton.onClick.RemoveAllListeners();
        musicButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
    }

    private void UpdateVisual(bool fake = false)
    {   
        soundEffectText.text = $"Sound Effects: {Mathf.Round(SoundManager.Instance.GetVolume() * 10f)}";
        musicText.text = $"Music: {Mathf.Round(MusicManager.Instance.GetVolume() * 10f)}";

        MoveUpBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveUp);
        MoveDownBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveDown);
        MoveLeftBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveLeft);
        MoveRightBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveRight);
        InteractBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Interact);
        InteractAltBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.InteractAlt);
        PauseBinding.bindingText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Pause);
    }

    public void ChangeVisiblity(bool show)
    {
        gameObject.SetActive(show);
    }

    public void ChangePressToRebaindTransformVisibility(bool show) 
    { 
        pressToRebindTransform.gameObject.SetActive(show);
    }

    private void RebindBinding(GameInputs.Binding binding)
    {
        ChangePressToRebaindTransformVisibility(true);
        GameInputs.Instance.RebindBinding(binding, (bool show) =>
        {
            ChangePressToRebaindTransformVisibility(false);
            UpdateVisual(false);
        });
    }
}
