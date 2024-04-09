using Desktop;
using System.Collections.Generic;
using UnityEngine;

public class ModelActionManager : MonoSingleton<ModelActionManager>
{
    private Desktop.Model _selectedPlacedModel;
    private List<Desktop.Model> _modelsInActions = new List<Desktop.Model>();
    private bool _enabled;

    private void Update()
    {
        if (!_enabled)
        {
           _selectedPlacedModel = null;
            StopAllModelActions();
        } 

        if (_selectedPlacedModel != null)
        {
            UIManager.Instance.ShowFunctionButtonByName("Play");
            UIManager.Instance.HideFunctionButtonByName("Pause");
            UIManager.Instance.ShowFunctionButtonByName("Remove");
        }
        else
        {
            UIManager.Instance.HideFunctionButtonByName("Play");
            UIManager.Instance.HideFunctionButtonByName("Pause");
            UIManager.Instance.HideFunctionButtonByName("Remove");
        }

        if (_selectedPlacedModel != null && _selectedPlacedModel.IsPlayingActions())
        {
            UIManager.Instance.HideFunctionButtonByName("Play");
            UIManager.Instance.HideFunctionButtonByName("Remove");
            UIManager.Instance.ShowFunctionButtonByName("Pause");
        }
    }

    public void SetSelectedPlacedModel(Desktop.Model model)
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

    void StopAllModelActions()
    {
        foreach(Desktop.Model model in _modelsInActions)
        {
            model.GetComponent<Actions>().PlayActions(false);
            model.SetIsPlayingActions(false);
        }
    }

    public void AddToModelsInActionsList(Desktop.Model model)
    {
        _modelsInActions.Add(model);
    }

    public void RemoveFromModelsInActionsList(Desktop.Model model)
    {
        _modelsInActions.Remove(model);   
    }

    public void Enabled(bool enabled)
    {
        if (enabled)
        {
            _enabled = true;
        }
        else
        {
            _enabled = false;
        }
    }
     public void RemoveSelectedPlacedModel()
    {
        Model[] placedModels = FindObjectsOfType<Model>();
        if (placedModels.Length > 0)
        {
            foreach(Model placedModel in placedModels)
            {
                if(placedModel == _selectedPlacedModel)
                {
                    ModelButton modelButton = ModelPlacementManager.Instance.GetModelButtonByName(placedModel.gameObject.tag);
                    modelButton.SetSprite();
                    Destroy(placedModel.gameObject);
                }
            }
        }
        else
        {
            Debug.LogError("Couldn't find any placed models");
        }
    }
}
