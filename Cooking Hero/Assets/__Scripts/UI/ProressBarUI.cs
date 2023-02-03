using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private CuttingCounter cuttingCounter;

    private void Start()
    {
        cuttingCounter.OnProgressChange += CuttingCounter_OnProgressChange;
        barImage.fillAmount = 0f;
        ChangeVisibility(false);
    }

    private void CuttingCounter_OnProgressChange(object sender, CuttingCounter.OnProgressChangeEventArgs e)
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
