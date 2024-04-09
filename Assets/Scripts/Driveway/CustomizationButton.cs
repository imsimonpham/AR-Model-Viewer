using UnityEngine;
using UnityEngine.UI;

public class CustomizationButton : MonoBehaviour
{
    [SerializeField] private int _buttonID;
    [SerializeField] private Image _outline;

    private Color _originalColor;
    private Color _activeColor;
    private bool _isActive;

    private void Start()
    {
        _originalColor = new Color32(255, 255, 255, 255);
        _activeColor = new Color32(156, 217, 193, 255);
    }

    private void Update()
    {
        if(_isActive)
        {
            _outline.color = _activeColor;
        }else
        {
            _outline.color = _originalColor;
        }
    }

    public int GetButtonID()
    {
        return _buttonID;
    }

    public bool isActive()
    {
        return _isActive;
    }

    public void Activate(bool activate)
    {
        if(activate)
        {
            _isActive = true;
        }else
        {
            _isActive = false;
        }
    }
}
