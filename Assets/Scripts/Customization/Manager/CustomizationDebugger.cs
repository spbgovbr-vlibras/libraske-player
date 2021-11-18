using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationDebugger : MonoBehaviour
{
    public CustomizationHolderSO _customizationHolder;

    public int id;
    public bool print;

    private void Update()
    {
        if (print)
        {
            Debug.Log(_customizationHolder.GetColorsWithPersonalizationId(id).ToString());
            print = false;
        }
    }
}
