using UnityEngine;

public class ModelExamineManager : MonoBehaviour
{
    private static ModelExamineManager _instance;
    public static ModelExamineManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Examinable Manager is null");
            return _instance;
        }
    }

    [SerializeField] private Transform _examineTarget;
    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Model _currentExaminedModel;
    private Vector3 _cachedScale;
    private Transform _cachedParent;

    private float _rotSpeed = 0.5f;
    private bool _isExamining = false;

    private bool _enabled;

    private void Awake()
    {
        _instance = this;
    }

    public void PerformExamine(Model model)
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



    /*[SerializeField] private Transform _examineTarget;
    [SerializeField] private UIManager _uiManager;

    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Examinable _currentExaminedObj;
    private Vector3 _cachedScale;
    private Transform _cachedParent;

    private float _rotSpeed = 0.5f;
    private bool _isExamining = false;

    private void Update()
    {
        if(_isExamining)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Moved ) {
                    _currentExaminedObj.transform.Rotate(touch.deltaPosition.x * _rotSpeed, touch.deltaPosition.y * _rotSpeed, 0, Space.Self);
                }
            }
        }
    }

    public void PerformExamine(Examinable examinable)
    {
        _currentExaminedObj = examinable;

        //hide selection vis
        _currentExaminedObj.GetSelectionVis().GetComponent<MeshRenderer>().enabled = false;

        //cache the examinable transform data
        _cachedPos = _currentExaminedObj.transform.position;
        _cachedRot = _currentExaminedObj.transform.rotation;
        _cachedScale = _currentExaminedObj.transform.localScale;
        _cachedParent = _currentExaminedObj.transform.parent;

        //move the examinable to the target position (parent first)
        _currentExaminedObj.transform.parent = _examineTarget;
        _currentExaminedObj.transform.position = _examineTarget.position;
        

        //offset the examinable's scalse
        _currentExaminedObj.transform.localScale = _cachedScale * _currentExaminedObj.GetExamineScaleOffset();

        //disable pick and place button
        _uiManager.DisableButtonByName("PickandPlace");

        _isExamining = true;
    }

    public void PerformUnexamine()
    {
        //unhide selection vis
        _currentExaminedObj.GetSelectionVis().GetComponent<MeshRenderer>().enabled = true;

        //restore all transform data (parent first)
        _currentExaminedObj.transform.parent = _cachedParent;
        _currentExaminedObj.transform.position = _cachedPos;
        _currentExaminedObj.transform.rotation = _cachedRot;
        _currentExaminedObj.transform.localScale = _cachedScale;
        

        //enable pick and place button
        _uiManager.EnableButtonByName("PickandPlace");

        _isExamining = false;
        _currentExaminedObj = null;
    }*/
}

