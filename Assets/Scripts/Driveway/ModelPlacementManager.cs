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
                    Debug.LogError("Model Placement Manager is null");
                return _instance;
            }
        }

        private ModelButton _selectedModelButton;
        [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
        [SerializeField] private ModelButton[] _modelButtons;
        [SerializeField] private GameObject _modelButtonsContainer;
        [SerializeField] private ARPlaneManager _ARPlaneManager;

        private void Awake()
        {
            _instance = this;
        }

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
            UIManager.Instance.ShowFunctionButtonByName("Customize");

            Model placedModel = FindObjectOfType<Model>();
            if (placedModel != null)
            {
                Debug.Log("Placed Model is NOT null");
                UIManager.Instance.SetupCustomizationButtons(placedModel);
                CustomizationManager.Instance.ConfigureCurrentModel(placedModel);
            } else
            {
                Debug.LogError("Placed Model is null");
            }   
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
                Debug.LogError("Couldn't find placed model");
            }
            ShowModelButtonContainer();
            EnableARPlanes();
            UIManager.Instance.HideFunctionButtonByName("Return");
            UIManager.Instance.HideFunctionButtonByName("Customize");
        }
    }
}

