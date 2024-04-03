using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ModelPlacementManager : MonoBehaviour
{
    /*private static ModelPlacementManager _instance;
    public static ModelPlacementManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Model Placement Manager is null");
            return _instance;
        }
    }*/
    private ModelButton _selectedModelButton;
    [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
    [SerializeField] private ModelButton[] _modelButtons;

    /*private void Awake()
    {
        _instance = this;
    }*/

    public void SetSelectedPlacementModel(ModelButton button)
    {
        if (button.IsSelected())
        {
            foreach (ModelButton modelButton in _modelButtons)
            {
                if (modelButton == button)
                {
                    _selectedModelButton = modelButton;
                    _ARPlacementInteractable.placementPrefab = _selectedModelButton.GetModelPrefab();
                }
                else
                {
                    modelButton.SetIsSelected(false);
                }
            }
        }
    }

    public void PlaceModel()
    {
        _selectedModelButton.SetIsSelected(false);
        _selectedModelButton.SetSpriteEmpty();
        _ARPlacementInteractable.placementPrefab = null;
    }

}
