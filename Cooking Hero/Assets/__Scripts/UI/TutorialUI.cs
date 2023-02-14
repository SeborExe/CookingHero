using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TMP_Text keyMoveUpText;
    [SerializeField] private TMP_Text keyMoveDownText;
    [SerializeField] private TMP_Text keyMoveLeftText;
    [SerializeField] private TMP_Text keyMoveRightText;
    [SerializeField] private TMP_Text keyInteractText;
    [SerializeField] private TMP_Text keyAltInteractText;
    [SerializeField] private TMP_Text keyPauseText;
    [SerializeField] private TMP_Text keyGamepadInteractText;
    [SerializeField] private TMP_Text keyGamepadAltInteractText;
    [SerializeField] private TMP_Text keyGamepadPauseText;

    private void Start()
    {
        GameInputs.Instance.OnBindingRebind += GameInputs_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        UpdateVisual();

        ChangeVisibility(true);
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            ChangeVisibility(false);
        }
    }

    private void GameInputs_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveUp);
        keyMoveDownText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveDown);
        keyMoveLeftText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveLeft);
        keyMoveRightText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.MoveRight);
        keyInteractText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Interact);
        keyAltInteractText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.InteractAlt);
        keyPauseText.text = GameInputs.Instance.GetBindingText(GameInputs.Binding.Pause);
    }

    private void ChangeVisibility(bool show)
    {
        gameObject.SetActive(show);
    }
}
