using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    [Header("Generals")]
    [SerializeField] private string _prefabName;

    [Header("Plane Actions")]
    //Propeller
    [SerializeField] private GameObject _propeller;
    [SerializeField] private float _acceleration; 
    [SerializeField] private float _maxSpeed; 
    private float _currentSpeed = 0f;
    private bool _isExecutingActions = false; 
    //Bobbing
    [SerializeField] private float _bobbingSpeed;
    [SerializeField] private float _bobbingAmount;
    private float _defaultYPos;
    [SerializeField] private float _yPosBoost;
    private bool _defaultYPosSet = false;
    //Cached Data
    private Vector3 _cachedPos;
    private Quaternion _cachedRot;

    [Header("Tank Actions")]
    [SerializeField] private GameObject _turret;

    private void Start()
    {
        _cachedPos = transform.position;
        _cachedRot = transform.rotation;
        _defaultYPos = _cachedPos.y;
    }

    void Update()
    {
        switch (_prefabName)
        {
            case "Plane": 
                if (_isExecutingActions)
                {
                    SpinPropeller();
                    Bobbing();
                }
                else
                {
                    transform.position = _cachedPos;
                    transform.rotation = _cachedRot;
                }
                break;
        }
    }

    // Public method to start or stop spinning
    public void PlayActions(bool activated)
    {
        if (activated)
        {
            _isExecutingActions = true;
        } else
        {
            _isExecutingActions = false;
        }
    }

    void SpinPropeller()
    {
        // Check if the propeller is supposed to be spinning
        _currentSpeed += _acceleration * Time.deltaTime;
        if (_currentSpeed > _maxSpeed)
        {
            _currentSpeed = _maxSpeed;
        }

        // Rotate the propeller around the Z-axis at the current speed
        _propeller.transform.Rotate(0, 0, _currentSpeed * Time.deltaTime);
    }

    void Bobbing()
    {
        if (!_defaultYPosSet)
        {
            _defaultYPos += _yPosBoost;
            _defaultYPosSet = true; // Ensure this block only runs once
        }
        float bobbing = Mathf.Sin(Time.time * _bobbingSpeed) * _bobbingAmount;
        transform.position = new Vector3(transform.position.x, _defaultYPos + bobbing, transform.position.z);
    }

    public bool IsExecutingActions()
    {
        return _isExecutingActions;
    }
}
