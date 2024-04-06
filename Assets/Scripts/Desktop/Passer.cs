using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Passer : MonoBehaviour
{
    [SerializeField] private Actions _actions;

    public void RequestInstantiateMuzzleFlash()
    {
        _actions.InstantiateMuzzleFlash();
    }
}
