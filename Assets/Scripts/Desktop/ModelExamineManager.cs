using UnityEngine;

public class ModelExamineManager : MonoSingleton<ModelExamineManager>
{
    [SerializeField] private Transform _examineTarget;
    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Desktop.Model _currentExaminedModel;
    private Vector3 _cachedScale;
    private Transform _cachedParent;

    private float _rotSpeed = 0.5f;
    private bool _isExamining = false;

    private bool _enabled;

    private void Update()
    {
        if (_isExamining)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    _currentExaminedModel.transform.Rotate(touch.deltaPosition.x * _rotSpeed, touch.deltaPosition.y * _rotSpeed, 0, Space.Self);
                }
            }
        }
    }

    public void PerformExamine(Desktop.Model model)
    {
        _currentExaminedModel = model;

        //disable selection vis
        _currentExaminedModel.DisableSelectionVis();

        //cache the examinable transform data
        _cachedPos = _currentExaminedModel.transform.position;
        _cachedRot = _currentExaminedModel.transform.rotation;
        _cachedScale = _currentExaminedModel.transform.localScale;
        _cachedParent = _currentExaminedModel.transform.parent;

        //move the examinable to the target position (parent first)
        _currentExaminedModel.transform.parent = _examineTarget;
        _currentExaminedModel.transform.position = _examineTarget.position;

        //offset the examinable's scalse
        _currentExaminedModel.transform.localScale = _cachedScale * _currentExaminedModel.GetExamineScaleOffset();

        //disable return button
        UIManager.Instance.DisableFunctionButtonByName("Return");

        _isExamining = true;
    }

    public void PerformUnexamine()
    {
        //enable selection vis
        _currentExaminedModel.EnableSelectionVis();

        //restore all transform data (parent first)
        _currentExaminedModel.transform.parent = _cachedParent;
        _currentExaminedModel.transform.position = _cachedPos;
        _currentExaminedModel.transform.rotation = _cachedRot;
        _currentExaminedModel.transform.localScale = _cachedScale;

        //enable return button
        UIManager.Instance.EnableFunctionButtonByName("Return");

        _isExamining = false;
        _currentExaminedModel = null;
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

    public bool IsEnabled() { return _enabled; }

    public bool IsExamining() { return _isExamining; }
}

