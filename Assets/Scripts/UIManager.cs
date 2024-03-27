using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class UIManager : MonoBehaviour
{
    [Header("Prefab Placement Fields")]
    [SerializeField] private Button[] _placementButtons;
    private Button _selectedButton;
    [SerializeField] private Color _selectedColor;
    private Color[] _originalButtonColors;
    [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
    [SerializeField] GameObject[] _placementPrefabs;

    [Header("Utility Fields")]
    [SerializeField] private ExaminableManager _examinableManager;
    [SerializeField] private Button[] _functionButtons;
    private bool _inExamineMode;


    private void Start()
    {
        _originalButtonColors = new Color[_placementButtons.Length];
        for (int i = 0; i < _placementButtons.Length; i++)
        {
            _originalButtonColors[i] = _placementButtons[i].colors.normalColor;
        }
    }

    public void SetSelectedButton(Button button)
    {
        if(_selectedButton != button)
        {
            _selectedButton = button;
            foreach (var prefab in _placementPrefabs)
            {
                if(_selectedButton.name == prefab.name)
                {
                    _ARPlacementInteractable.placementPrefab = prefab;
                }
            }
            
        } else
        {
            _selectedButton = null;
            _ARPlacementInteractable.placementPrefab = null;
        }
        
        UpdateButtonColors();
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < _placementButtons.Length;i++)
        {
            ColorBlock cb = _placementButtons[i].colors;
            cb.normalColor = (_placementButtons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            cb.selectedColor = (_placementButtons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            _placementButtons[i].colors = cb;
        }
    }

    public void DisablePrefabButtonOnPlacement()
    {
        foreach(Button button in _placementButtons)
        {
            if (button.name == _selectedButton.name)
            {
                button.gameObject.SetActive(false);
                _ARPlacementInteractable.placementPrefab = null;
            }
        }        
    }


    public void SwitchToExamineMode()
    {
        _inExamineMode = true;
    }

    public void SwitchToPickAndPlaceMode()
    {
        _inExamineMode = false;
    }

    public bool IsInExamineMode()
    {
        return _inExamineMode;
    }

    public void DisableFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.interactable = false;
            }
        }
    }

    public void EnableFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.interactable = true;
            }
        }
    }
}
