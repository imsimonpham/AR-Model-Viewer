using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] placementPrefabs;
    private Button _selectedButton;
    [SerializeField] private Color _selectedColor;
    private Color[] _originalButtonColors;
    [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;

    private void Start()
    {
        Debug.Log("STart: " + _selectedColor);

        _originalButtonColors = new Color[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            _originalButtonColors[i] = buttons[i].colors.normalColor;
        }
    }

    public void SetSelectedButton(Button button)
    {
        if(_selectedButton != button)
        {
            _selectedButton = button;
            foreach(var prefab in placementPrefabs)
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
        Debug.Log(_selectedColor);

        for (int i = 0; i < buttons.Length;i++)
        {
            ColorBlock cb = buttons[i].colors;
            cb.normalColor = (buttons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            cb.selectedColor = (buttons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            buttons[i].colors = cb;
        }
    }
}
