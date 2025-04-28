//==========================
// - 文件名称: StartSceneUI.cs
// - 创建者: #AuthorName# 
// - 创建时间: #CreateTime# 
// - 描述:
//==========================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUI : MonoBehaviour
{
    [Header("关于UI")]
    public GameObject aboutUIGo;
    [Header("设置UI")]

    public GameObject settingUIGo;

    public Slider musicSlider;
    public Toggle openToggle;
    // public Toggle closeToggle;

    void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        openToggle.onValueChanged.AddListener(OnOpenToggleValueChanged);
        musicSlider.value = DataManager.instance.musicVolume;
        openToggle.isOn = DataManager.instance.isOpenMusic;
        // closeToggle.onValueChanged.AddListener(OnCloseToggleValueChanged);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("01_Level");
    }

    public void OnAboutButtonClick()
    {
        aboutUIGo.SetActive(true);
    }

    public void OnEndButtonClick()
    {
        Application.Quit();
    }


    /// <summary>
    /// 关于界面关闭按钮点击
    /// </summary>
    public void OnAboutUICloseButtonClick()
    {
        aboutUIGo.SetActive(true);
    }

    public void OnSettingUButtonClick()
    {
        musicSlider.value = DataManager.instance.musicVolume;
        settingUIGo.SetActive(true);
    }

    public void OnMusicSliderValueChanged(float volume)
    {
        DataManager.instance.SetVolume(musicSlider.value);
    }

    public void OnOpenToggleValueChanged(bool open)
    {
        DataManager.instance.SetOpenMusic(open);
    }
}
