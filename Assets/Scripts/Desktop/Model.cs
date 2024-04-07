using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

namespace Desktop
{
    public class Model : MonoBehaviour
    {
        private bool _isSelected;
        private bool _isPlayingActions;

        [Header("Examinable Fields")]
        [SerializeField] private GameObject _selectionVis;
        [SerializeField] private float _examineScaleOffset;

        [Header("Interactables")]
        [SerializeField] ARTranslationInteractable _translation;
        [SerializeField] ARRotationInteractable _rotation;
        [SerializeField] ARScaleInteractable _scale;

        private void OnEnable()
        {
            ModelPlacementManager.Instance.AddPlacedModel(this);
        }

        public void SelectModel()
        {
            _isSelected = true;
            ModelPlacementManager.Instance.EnableARPlanes();
            ModelActionManager.Instance.SetSelectedPlacedModel(this);
        }

        public void UnselectModel()
        {
            _isSelected = false;
            ModelPlacementManager.Instance.DisableARPlanes();
            ModelActionManager.Instance.SetUnselectedPlacedModel();
        }

        public void SetIsPlayingActions(bool playing)
        {
            if (playing)
            {
                _isPlayingActions = true;
                ModelActionManager.Instance.AddToModelsInActionsList(this);
                ModelPlacementManager.Instance.DisableARPlanes();
            }
            else
            {
                _isPlayingActions = false;
                ModelActionManager.Instance.RemoveFromModelsInActionsList(this);
                if (!_isSelected) { return; }
                ModelPlacementManager.Instance.EnableARPlanes();
            }
        }

        public void DisableInteractables()
        {
            _translation.enabled = false;
            _rotation.enabled = false;
            _scale.enabled = false;
        }

        public void EnableInteractables()
        {
            _translation.enabled = true;
            _rotation.enabled = true;
            _scale.enabled = true;
        }


        public void DisableSelectionVis()
        {
            _selectionVis.GetComponent<MeshRenderer>().enabled = false;
        }

        public void EnableSelectionVis()
        {
            _selectionVis.GetComponent<MeshRenderer>().enabled = true;
        }

        public void RequestExamine()
        {
            ModelExamineManager examineManager = ModelExamineManager.Instance;
            if (examineManager.IsEnabled())
            {
                examineManager.PerformExamine(this);
            }
        }

        public void RequestUnexamine()
        {
            ModelExamineManager examineManager = ModelExamineManager.Instance;
            if (examineManager.IsEnabled())
            {
                examineManager.PerformUnexamine();
            }
        }

        public float GetExamineScaleOffset() { return _examineScaleOffset; }

        public bool IsSelected() { return _isSelected; }

        public bool IsPlayingActions() { return _isPlayingActions; }
    }
}

