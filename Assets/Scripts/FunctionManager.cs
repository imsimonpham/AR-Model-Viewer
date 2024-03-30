using UnityEngine;

public class FunctionManager : MonoBehaviour
{
    private Examinable _selectedExaminable;
    private bool _isPlayingFunctions;
    [SerializeField] private UIManager _uiManager;

    private void Update()
    {
       
    }

    public void SelectExaminable(Examinable examinable)
    {  
        if (_isPlayingFunctions) { return; }
        //execute these only when examinable is not in function
        _selectedExaminable = examinable;
        _uiManager.ShowButtonByName("Play");
    }

    public void UnselectExaminable()
    {
        if(_isPlayingFunctions) { return; }
        //execute these only when examinable is not in function
        _selectedExaminable = null;
        _uiManager.HideButtonByName("Play");
        _uiManager.HideButtonByName("Pause");
    }

    public void PerformPlayActions()
    { 
        if (_selectedExaminable == null) { return; }
        _selectedExaminable.GetActions().PlayActions(true);
        _isPlayingFunctions = true;
    }

    public void PerformStopActions()
    {
        if (_selectedExaminable == null) { return; }
        _selectedExaminable.GetActions().PlayActions(false);
        _isPlayingFunctions = false;
        if (_selectedExaminable.GetIsSelected()) { return; }
        //execute this only when examinale is not selected
        UnselectExaminable();
    }
}
