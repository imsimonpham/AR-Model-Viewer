using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Examinable : MonoBehaviour
{
    /*private ExaminableManager _examinableManager;
    private FunctionManager _functionManager;
    private UIManager _uiManager;
    private bool _isSelected;

    [SerializeField] private GameObject _selectionVis;
    [SerializeField] private float _examineScaleOffset;
    [SerializeField] private Actions _actions;
    [SerializeField] private Button _playButton;

    [Header("Interactables")]
    [SerializeField] ARTranslationInteractable _translation;
    [SerializeField] ARRotationInteractable _rotation;
    [SerializeField] ARScaleInteractable _scale;

    private void Start()
    {
        _examinableManager = GameObject.FindObjectOfType<ExaminableManager>();
        if (_examinableManager == null)
        {
            Debug.LogError("Examinable Manager is null");
        }
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        if(_uiManager == null)
        {
            Debug.LogError("UI Manager is null");
        }
        _functionManager = GameObject.FindObjectOfType<FunctionManager>();
        if(_functionManager == null)
        {
            Debug.LogError("Function Manager is null");
        }

    }

    private void Update()
    {
        if (_uiManager.IsInExamineMode()) {
            _translation.enabled = false;
            _rotation.enabled = false;
            _scale.enabled = false;
        } else
        {
            _translation.enabled = true;
            _rotation.enabled = true;
            _scale.enabled = true;
        }
    }

    public void RequestExamine()
    {
        if (_uiManager.IsInExamineMode())
        {
            _examinableManager.PerformExamine(this);
        } 
    }

    public void RequestUnexamine()
    {
        if (_uiManager.IsInExamineMode())
        {
            _examinableManager.PerformUnexamine();
        }  
    }

    public void RequestSelectExaminable()
    {
        _functionManager.SelectExaminable(this);
    }

    public void RequestUnselectExaminable()
    {
        _functionManager.UnselectExaminable();
    }

    public GameObject GetSelectionVis() { return _selectionVis; }

    public float GetExamineScaleOffset() { return _examineScaleOffset; }

    public Actions GetActions() { return _actions; }

    public void SetIsSelected(bool isSelected)
    {
        if (isSelected)
        {
            _isSelected = true;
        }else
        {
            _isSelected = false;
        }
    }

    public bool GetIsSelected()
    {
        return _isSelected;
    }*/
}
