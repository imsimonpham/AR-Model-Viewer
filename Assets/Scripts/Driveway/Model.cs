using UnityEngine;

namespace Driveway
{
    [System.Serializable]
    public class MaterialOption
    {
        [SerializeField] private Material[] _materials;
        public Material[] GetMaterialList()
        {
            return _materials;
        }
    }
    public class Model : MonoBehaviour
    {
        [SerializeField] private MaterialOption[] _options;

        [SerializeField] private GameObject[] _parts;
        [SerializeField] private Sprite[] _colorVariants;

        public Sprite[] GetColorVariants()
        {
            return _colorVariants;
        }

        public MaterialOption[] GetMaterialOptions()
        {
            return _options;
        }

        public GameObject GetParts(int index)
        {
            return _parts[index];
        }
    }
}

