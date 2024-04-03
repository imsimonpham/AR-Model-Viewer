using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    private bool _isSelected;
    private bool _isPlayingActions;

    private void Update()
    {
    }

    public void SelectModel()
    {
        _isSelected = true;
        ModelActionManager.Instance.SetSelectedPlacedModel(this);
    }

    public void UnselectModel()
    {
        _isSelected = false;
        ModelActionManager.Instance.SetUnselectedPlacedModel();
    }

    public void SetIsPlayingActions(bool playing)
    {
        if (playing)
        {
            _isPlayingActions = true;
        }else
        {
            _isPlayingActions = false;  
        }
    }

    public bool IsSelected()
    {
        return _isSelected;
    }

    public bool IsPlayingActions()
    {
        return _isPlayingActions;
    }
}
