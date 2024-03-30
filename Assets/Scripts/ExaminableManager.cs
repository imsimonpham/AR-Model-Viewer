using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] private Transform _examineTarget;
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
    }
}

