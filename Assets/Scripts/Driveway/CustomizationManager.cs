using UnityEngine.UI;
using UnityEngine;
using System.Runtime.CompilerServices;

public class CustomizationManager : MonoBehaviour
{
    private static CustomizationManager _instance;
    public static CustomizationManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Customization Manager is null");
            return _instance;
        }
    }

    private Driveway.Model _currentModel;
    [SerializeField] private Button[] _customizationButtons;
    private Driveway.MaterialOption[] _materialOptionList;

    private void Awake()
    {
        _instance = this;
    }

    public void ConfigureCurrentModel(Driveway.Model model)
    {
        _currentModel = model;
        _materialOptionList = model.GetMaterialOptions();
    }

    public void ChangeCurrentModelColor(int buttonID)
    {     
        if (_currentModel != null) {
            Debug.Log(_currentModel.name);
            if (_currentModel.name != "Tank(Clone)")
            {
                Renderer renderer = _currentModel.GetParts(0).GetComponent<Renderer>();
                renderer.material = _materialOptionList[buttonID].GetMaterialList()[0];
            }
            else
            {
                Renderer renderer1 = _currentModel.GetParts(0).GetComponent<Renderer>();
                Renderer renderer2 = _currentModel.GetParts(1).GetComponent<Renderer>();
                Renderer renderer3 = _currentModel.GetParts(2).GetComponent<Renderer>();
                renderer1.material = _materialOptionList[buttonID].GetMaterialList()[0];
                renderer2.material = _materialOptionList[buttonID].GetMaterialList()[1];
                renderer3.material = _materialOptionList[buttonID].GetMaterialList()[1];
            }       
        } else
        {
            Debug.LogError("Current model is null");
        }
    }
}
