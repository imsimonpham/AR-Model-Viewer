using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

namespace Desktop
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
        [SerializeField] private ARPlacementInteractable _ARPlacementInteractable;
        [SerializeField] private ModelButton[] _modelButtons;
        private List<Model> _placedModels = new List<Model>();
        private bool _enabled;

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            if (!_enabled)
            {
                UnselectAllModelButtons();
                ShowModelButtons(false);
                _selectedModelButton = null;
                _ARPlacementInteractable.placementPrefab = null;
                foreach (Model placedModel in _placedModels)
                {
                    placedModel.DisableInteractables();
                }
            }
            else
            {
                ShowModelButtons(true);
                foreach (Model placedModel in _placedModels)
                {
                    placedModel.EnableInteractables();
                }
            }
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
            _selectedModelButton.SetSpriteEmpty();
            _ARPlacementInteractable.placementPrefab = null;
        }

        public void AddPlacedModel(Model model)
        {
            _placedModels.Add(model);
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

        private void ShowModelButtons(bool enabled)
        {
            if (enabled)
            {
                foreach (ModelButton modelButton in _modelButtons)
                {
                    modelButton.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (ModelButton modelButton in _modelButtons)
                {
                    modelButton.gameObject.SetActive(false);
                }
            }
        }

        private void UnselectAllModelButtons()
        {
            foreach (ModelButton modelButton in _modelButtons)
            {
                modelButton.SetIsSelected(false);
            }
        }
    }
}

