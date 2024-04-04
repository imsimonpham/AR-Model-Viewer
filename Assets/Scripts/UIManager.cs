using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("UI Manager is null");
            return _instance;
        }
    }
    [SerializeField] private Button[] _functionButtions;
    [SerializeField] private GameObject[] _modals;
    private void Awake()
    {
        _instance = this;
    }

    public void Update()
    {
        //touching on non UI elements will close currently open modal
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (!IsPointerOverUIObject(touch))
                {
                    CloseAllModals();
                } 
            }
        }
    }


    public void ToggleModal(GameObject modal)
    {
        modal.SetActive(!modal.activeSelf);
    }

    private bool IsPointerOverUIObject(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
    private void CloseAllModals()
    {
        foreach (GameObject modal in _modals)
        {
            if (modal.activeSelf == true)
            {
                modal.SetActive(false);
            }
        }
    }

    public void ShowFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtions)
        {
            if (button.name == name)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void HideFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtions)
        {
            if (button.name == name)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public void DisableFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtions)
        {
            if (button.name == name)
            {
                button.interactable = false;
            }
        }
    }

    public void EnableFunctionButtonByName(string name)
    {
        foreach (Button button in _functionButtions)
        {
            if (button.name == name)
            {
                button.interactable = true;
            }
        }
    }


    /*[Header("Prefab Placement Fields")]
    [SerializeField] private Button[] _placementButtons;
    private Button _selectedButton;
    [SerializeField] private Color _selectedColor;
    private Color[] _originalButtonColors;
    [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
    [SerializeField] GameObject[] _placementPrefabs;

    [Header("Examine Fields")]
    [SerializeField] private ExaminableManager _examinableManager;
    private bool _inExamineMode;
    private Examinable _selectedExaminable;

    [Header("Function Fields")]
    [SerializeField] private Button[] _functionButtons;
    [SerializeField] private FunctionManager _functionManager;
    *//*private bool _funtionsTurnedOn;*//*


    private void Start()
    {
        //cache prefab buttons original color
        _originalButtonColors = new Color[_placementButtons.Length];
        for (int i = 0; i < _placementButtons.Length; i++)
        {
            _originalButtonColors[i] = _placementButtons[i].colors.normalColor;
        }
    }

    public void SetSelectedButton(Button button)
    {
        //select placement prefab based on button tap
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
            //double tap to unselect
            _selectedButton = null;
            _ARPlacementInteractable.placementPrefab = null;
        }
        
        UpdateButtonColors();
    }

    private void UpdateButtonColors()
    {
        //update a button's color to the selected color
        for (int i = 0; i < _placementButtons.Length;i++)
        {
            ColorBlock cb = _placementButtons[i].colors;
            cb.normalColor = (_placementButtons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            cb.selectedColor = (_placementButtons[i] == _selectedButton) ? _selectedColor : _originalButtonColors[i];
            _placementButtons[i].colors = cb;
        }
    }

   
    public void HidePrefabButtonOnPlacement()
    {
        //hide button if the corresponding prefab is placed
        foreach (Button button in _placementButtons)
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

    public void DisableButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.interactable = false;
            }
        }
    }

    public void EnableButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.interactable = true;
            }
        }
    }

    public void ShowButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void HideButtonByName(string name)
    {
        foreach (Button button in _functionButtons)
        {
            if (button.name == name)
            {
                button.gameObject.SetActive(false);
            } 
        }
    }

    public void RequestPlayActions()
    {
        if( _inExamineMode) { return; }
        _functionManager.PerformPlayActions();
    }

    public void RequestStopActions()
    {
        if (_inExamineMode) { return; }
        _functionManager.PerformStopActions();
    }*/
}
