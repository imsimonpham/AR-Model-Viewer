using UnityEngine;
using System;
using UnityEngine.UI;

namespace Desktop
{
    public class ModelButton : MonoBehaviour
    {
        [SerializeField] private Image _sprite;
        [SerializeField] private Image _greySprite;
        [SerializeField] private GameObject _modelPrefab;
        [SerializeField] private Image _bg;
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

        //Set functions
        public void SetSpriteEmpty()
        {
            _sprite.gameObject.SetActive(false);
            _greySprite.gameObject.SetActive(true);
            this.GetComponent<Button>().interactable = false;
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

        //show/hide functions
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

        //get functions
        public GameObject GetModelPrefab() { return _modelPrefab; }

        public bool IsSelected() { return _isSelected; }
    }
}

