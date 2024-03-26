using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] private Transform _examineTarget;

    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Examinable _currentExaminedObj;

    public void PerformExamine(Examinable examinable)
    {
        _currentExaminedObj = examinable;

        _cachedPos = _currentExaminedObj.transform.position;
        _cachedRot = _currentExaminedObj.transform.rotation;

        _currentExaminedObj.transform.position = _examineTarget.position;
        _currentExaminedObj.transform.parent = _examineTarget;
    }

    public void PerformUnexamine()
    {
        _currentExaminedObj.transform.parent = null; 
        _currentExaminedObj.transform.position = _cachedPos;
        _currentExaminedObj.transform.rotation = _cachedRot;   
    }
}

