using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private GameObject hasProgressGameObject;
    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
            Debug.LogError("GameObject" + hasProgressGameObject.name + "doesn't have IHasProgress component");

        hasProgress.OnProgressChange += HasProgress_OnProgressChange;

        barImage.fillAmount = 0f;
        ChangeVisibility(false);
    }

    private void HasProgress_OnProgressChange(object sender, IHasProgress.OnProgressChangeEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            ChangeVisibility(false);
        }
        else
        {
            ChangeVisibility(true);
        }
    }

    private void ChangeVisibility(bool show)
    {
        gameObject.SetActive(show);
    }
}
