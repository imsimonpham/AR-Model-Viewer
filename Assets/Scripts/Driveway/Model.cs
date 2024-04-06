using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

namespace Driveway
{
    public class Model : MonoBehaviour
    {
        private bool _isSelected;
        [SerializeField] ARRotationInteractable _rotation;

        private void OnEnable()
        {
            ModelPlacementManager.Instance.AddPlacedModel(this);
        }
    }
}

