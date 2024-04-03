using System.Collections.Generic;
using UnityEngine;

public class ModelActionManager : MonoBehaviour
{
    private static ModelActionManager _instance;
    public static ModelActionManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Model Action Manager is null");
            return _instance;
        }
    }   
    private Model _selectedPlacedModel;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (_selectedPlacedModel != null)
        {
            UIManager.Instance.ShowFunctionButtonByName("Play");
            UIManager.Instance.HideFunctionButtonByName("Pause");
        }
        else
        {
            UIManager.Instance.HideFunctionButtonByName("Play");
        }

        if (_selectedPlacedModel.IsPlayingActions())
        {
            UIManager.Instance.HideFunctionButtonByName("Play");
            UIManager.Instance.ShowFunctionButtonByName("Pause");
        } 
    }

    public void SetSelectedPlacedModel(Model model)
    {
        _selectedPlacedModel = model;
    }

    public void SetUnselectedPlacedModel()
    {
        _selectedPlacedModel = null;
    } 

    public void RequestPlayingActions()
    {
        _selectedPlacedModel.GetComponent<Actions>().PlayActions(true);
        _selectedPlacedModel.SetIsPlayingActions(true);
    }

    public void RequestStoppingActions()
    {
        _selectedPlacedModel.GetComponent<Actions>().PlayActions(false);
        _selectedPlacedModel.SetIsPlayingActions(false);
    }

    /*private Examinable _selectedExaminable;
    private bool _isPlayingFunctions;
    [SerializeField] private UIManager _uiManager;

    private void Update()
    {
       
    }

    public void SelectExaminable(Examinable examinable)
    {  
        if(_uiManager.IsInExamineMode()) { return; }
        if (_isPlayingFunctions) { return; }
        //execute these only when examinable is not in function
        _selectedExaminable = examinable;
        _uiManager.ShowButtonByName("Play");
    }

    public void UnselectExaminable()
    {
        if (_uiManager.IsInExamineMode()) { return; }
        if (_isPlayingFunctions) { return; }
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
        _uiManager.DisableButtonByName("Examine");
    }

    public void PerformStopActions()
    {
        if (_selectedExaminable == null) { return; }
        _selectedExaminable.GetActions().PlayActions(false);
        _isPlayingFunctions = false;
        _uiManager.EnableButtonByName("Examine");
        if (_selectedExaminable.GetIsSelected()) { return; }
        //execute this only when examinale is not selected
        UnselectExaminable();
    }*/
}
