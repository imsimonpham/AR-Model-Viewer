using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool _isInExaminemode;

    private void Start()
    {
        _isInExaminemode = false;
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        UIManager.Instance.UpdateCurrentModeText(scene.name + " Mode");
        if (scene.name == "Desktop")
        {
            if (_isInExaminemode)
            {
                ModelExamineManager.Instance.Enabled(true);
                ModelActionManager.Instance.Enabled(false);
                Desktop.ModelPlacementManager.Instance.Enabled(false);
            }
            else
            {
                ModelExamineManager.Instance.Enabled(false);
                ModelActionManager.Instance.Enabled(true);
                Desktop.ModelPlacementManager.Instance.Enabled(true);
            }
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

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
