using UnityEngine;

public class SteamVR_MenuToggle : MonoBehaviour
{
    private GameObject Menu;
    private SteamVR_TrackedObject Controller;

    public GameObject MenuPrefab;

    void Awake()
    {
        Menu = (GameObject)Instantiate(MenuPrefab, transform);
        Controller = GetComponent<SteamVR_TrackedObject>();

        // Disabled by default
        Menu.SetActive(false);
    }

    void Update()
    {
        var device = SteamVR_Controller.Input((int)Controller.index);

        var showMenu = device.GetTouch(SteamVR_Controller.ButtonMask.ApplicationMenu);

        Menu.SetActive(showMenu);
    }
}
