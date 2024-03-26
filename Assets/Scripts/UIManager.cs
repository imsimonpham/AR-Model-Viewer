using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class UIManager : MonoBehaviour
{
    [Header("Prefab Placement Fields")]
    [SerializeField] private Button[] _buttons;
    private Button _selectedButton;
    [SerializeField] private Color _selectedColor;
    private Color[] _originalButtonColors;
    [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
    [SerializeField] GameObject[] _placementPrefabs;

    [Header("Utility Fields")]
    private Examinable _selectedExaminable;
    private bool _inExamineMode;
    [SerializeField] private ExaminableManager _examinableManager;
    [SerializeField] private Button _examineButton; 

    private void Start()
    {
        _originalButtonColors = new Color[_buttons.Length];
        for (int i = 0; i < _buttons.Length; i++)
        {
            _originalButtonColors[i] = _buttons[i].colors.normalColor;
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
        for (int i = 0; i < _buttons.Length;i++)
        {
            ColorBlock cb = _buttons[i].colors;
            cb.normalColor = (_buttons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            cb.selectedColor = (_buttons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            _buttons[i].colors = cb;
        }
    }

    public void DisablePrefabButtonOnPlacement()
    {
        foreach(Button button in _buttons)
        {
            if (button.name == _selectedButton.name)
            {
                button.gameObject.SetActive(false);
                _ARPlacementInteractable.placementPrefab = null;
            }
        }        
    }

    public void EnablePrefabButtonOnPlacement()
    {
        
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

   /* public void RequestExamine()
    {
        if(_selectedExaminable != null)
        {
            _selectedExaminable.IsExamined(true);
            _examinableManager.PerformExamine(_selectedExaminable);
        }  
    }

    public void RequestUnexamine()
    {
        _examinableManager.PerformUnexamine();
    }*/
}
