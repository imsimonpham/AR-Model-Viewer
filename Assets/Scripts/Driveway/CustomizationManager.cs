using UnityEngine;

public class CustomizationManager : MonoSingleton<CustomizationManager>
{ 
    private Driveway.Model _currentModel;
    private CustomizationButton _currentlySelectedButton;
    [SerializeField] private CustomizationButton[] _customizationButtons;
    private Driveway.MaterialOption[] _materialOptionList;

    void SetActiveButtonByID(int buttonID)
    {
        foreach(CustomizationButton button in _customizationButtons)
        {
            if(button.GetButtonID() == buttonID)
            {
                _currentlySelectedButton = button;
                _currentlySelectedButton.Activate(true);
            }else
            {
                button.Activate(false);
            }
        }
    }

    public void ConfigureCurrentModel(Driveway.Model model)
    {
        _currentModel = model;
        _materialOptionList = model.GetMaterialOptions();
        SetActiveButtonByID(0);
    }

    public void ChangeCurrentModelColor(int buttonID)
    {     
        if (_currentModel != null) {
            SetActiveButtonByID(buttonID);
            if (!_currentModel.CompareTag("Tank"))
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
