using UnityEngine;
using UnityEngine.UI;

namespace Driveway
{
    public class ModelButton : MonoBehaviour
    {
        [SerializeField] private Image _bg;
        [SerializeField] private GameObject _modelPrefab;
        private bool _isSelected;

        void Update()
        {
            if (_isSelected)
            {
                ShowBackground();
            }
            else
            {
                HideBackground();
            }
        }

        public void SetIsSelected(bool selected)
        {
            if (selected)
            {
                _isSelected = true;
            }
            else
            {
                _isSelected = false;
            }
        }

        public void ToggleIsSelected()
        {
            _isSelected = !_isSelected;
        }

        public void HideBackground()
        {
            _bg.gameObject.SetActive(false);
        }

        public void ShowBackground()
        {
            _bg.gameObject.SetActive(true);
        }

        public GameObject GetModelPrefab() { return _modelPrefab; }

        public bool IsSelected() { return _isSelected; }
    }
}

