using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _currentModeText;
    [SerializeField] private Button[] _functionButtions;
    [SerializeField] private GameObject[] _modals;

    [Header("Driveway")]
    [SerializeField] private Button[] _customizationButtons;
    [SerializeField] private GameObject _colorPalette;
    private Sprite[] _colorVariants;

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

    public void SetupCustomizationButtons(Driveway.Model model)
    {
        _colorVariants = model.GetColorVariants();
        // Ensure there's a matching number of buttons and color variants to avoid index out of range errors
        int count = Mathf.Min(_customizationButtons.Length, _colorVariants.Length);
        for (var i = 0; i < count; i++)
        {
            var button = _customizationButtons[i];
            var sprite = _colorVariants[i];

            // Get the Image component of the button's first child and set its sprite
            var image = button.transform.GetChild(0).GetComponent<Image>();
            if (image != null) // Check if the Image component is found
            {
                image.sprite = sprite;
            }
        }
    }

    public void ToggleColorPallete()
    {
        _colorPalette.SetActive(!_colorPalette.activeSelf);
    }

    public void HideColorPallete()
    {
        _colorPalette.SetActive(false);
    }

    public void UpdateCurrentModeText(string currentMode)
    {
        _currentModeText.text = currentMode;
    }
}
