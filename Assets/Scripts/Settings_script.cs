using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    [SerializeField] private Toggle fullscreen;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curr = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curr = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curr;
        resolutionDropdown.RefreshShownValue();
    }

    public void setFull(bool isfull)
    {
        Screen.fullScreen = isfull;
    }

    public void Setres(int resolutionindex)
    {
        Screen.SetResolution(resolutions[resolutionindex].width, resolutions[resolutionindex].height, Screen.fullScreen);
    }
}
