using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private PlatesCounter platesCounter;

    private List<GameObject> platesVisualList = new List<GameObject>();

    private void Awake()
    {
        platesCounter = GetComponentInParent<PlatesCounter>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float platesOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, platesOffsetY * platesVisualList.Count, 0);
        platesVisualList.Add(plateVisualTransform.gameObject);
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = platesVisualList[platesVisualList.Count - 1];
        platesVisualList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }
}
