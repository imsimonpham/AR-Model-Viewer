using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.SceneManagement;

namespace Driveway
{
    public class ModelPlacementManager : MonoBehaviour
    {
        private static ModelPlacementManager _instance;
        public static ModelPlacementManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.Log("Model Placement Manager is null");
                return _instance;
            }
        }

        private ModelButton _selectedModelButton;
        private Model _placedModel;
        [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
        [SerializeField] private ModelButton[] _modelButtons;
        [SerializeField] private GameObject _modelButtonsContainer;
        [SerializeField] private ARPlaneManager _ARPlaneManager; 
        private List<Model> _placedModels = new List<Model>();

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
            else
            {
                _ARPlacementInteractable.placementPrefab = null;
            }
        }

        public void PlaceModel()
        {
            _selectedModelButton.SetIsSelected(false);      
            _ARPlacementInteractable.placementPrefab = null;
            HideModelButtonContainer();
            DisableARPlanes();
            UIManager.Instance.ShowFunctionButtonByName("Return");
        }

        public void AddPlacedModel(Model model)
        {
            _placedModels.Add(model);
        }

        public void ShowModelButtonContainer()
        {
            _modelButtonsContainer.SetActive(true);
        }

        public void HideModelButtonContainer()
        {
            _modelButtonsContainer.SetActive(false);
        }

        public void DisableARPlanes()
        {
            _ARPlaneManager.SetTrackablesActive(false);
            _ARPlaneManager.enabled = false;
        }

        public void EnableARPlanes()
        {
            _ARPlaneManager.SetTrackablesActive(true);
            _ARPlaneManager.enabled = true;
        }

        public void RemovePlacedModel()
        {
            Model placedModel = FindObjectOfType<Model>();
            if (placedModel != null)
            {
                Destroy(placedModel.gameObject);
            }
            else
            {
                Debug.Log("Couldn't find placed model");
            }
            ShowModelButtonContainer();
            EnableARPlanes();
            UIManager.Instance.HideFunctionButtonByName("Return");
        }
    }
}

