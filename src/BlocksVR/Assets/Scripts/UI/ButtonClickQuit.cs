using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickQuit : MonoBehaviour
{
    void Awake()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(Quit);
    }

    void Quit()
    {
        // Save?

        Application.Quit();
    }
}
