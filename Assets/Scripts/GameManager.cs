using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Game Manager is null!");
            return _instance;
        }
    }

    private bool _isInExaminemode;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _isInExaminemode = false;
    }

    private void Update()
    {
        if (_isInExaminemode)
        {
            ModelExamineManager.Instance.Enabled(true);
            ModelActionManager.Instance.Enabled(false);
            ModelPlacementManager.Instance.Enabled(false);
        }
        else
        {
            ModelExamineManager.Instance.Enabled(false);
            ModelPlacementManager.Instance.Enabled(true);
            ModelActionManager.Instance.Enabled(true);
        }
    }

    public void EnableExamineMode(bool enabled)
    {
        if (enabled)
        {
            _isInExaminemode = true;
        } else
        {
            _isInExaminemode = false;
        }
    }
}
