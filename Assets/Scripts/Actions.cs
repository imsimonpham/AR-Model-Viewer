using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Actions : MonoBehaviour
{
    [Header("Generals")]
    [SerializeField] private string _prefabName;
    private bool _isExecutingActions = false;

    [Header("Plane Actions")]
    [SerializeField] private Animator _planeAnim;
    [SerializeField] private GameObject _propeller;
    [SerializeField] private float _propellerAcceleration; 
    [SerializeField] private float _maxSpinningSpeed;
    private float _currentSpinningSpeed = 0f; 

    [Header("Soldier Actions")]
    [SerializeField] private Animator _soldierAnim;

    [Header("Tank Actions")]
    [SerializeField] private GameObject _turret;
    [SerializeField] private Animator _tankAnim;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _firePoint;

    void Update()
    {
        switch (_prefabName)
        {
            case "Plane": 
                if (_isExecutingActions)
                {        
                    SpinPropeller();
                    _planeAnim.SetBool("Fly", true);
                }
                else
                {
                    _planeAnim.SetBool("Fly", false);
                }
                break;
            case "Soldier":
                if (_isExecutingActions)
                {
                    _soldierAnim.SetBool("Dance", true);
                } else
                {
                    _soldierAnim.SetBool("Dance", false);
                }            
                break;
            case "Tank":
                if (_isExecutingActions)
                {
                    _tankAnim.SetBool("Fire", true);
                }
                else
                {
                    _tankAnim.SetBool("Fire", false);
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
        _currentSpinningSpeed += _propellerAcceleration * Time.deltaTime;
        if (_currentSpinningSpeed > _maxSpinningSpeed)
        {
            _currentSpinningSpeed = _maxSpinningSpeed;
        }

        // Rotate the propeller around the Z-axis at the current speed
        _propeller.transform.Rotate(0, 0, _currentSpinningSpeed * Time.deltaTime);
    }

    public void InstantiateMuzzleFlash()
    {
        Instantiate(_muzzleFlash, _firePoint.transform.position, _turret.transform.rotation);
    }

    public bool IsExecutingActions()
    {
        return _isExecutingActions;
    }
}
