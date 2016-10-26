using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickSceneLoader : MonoBehaviour
{
    public string SceneName;

    void Awake()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        var operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = true;
    }
}
