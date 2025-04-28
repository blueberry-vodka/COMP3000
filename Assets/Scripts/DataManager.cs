//==========================
// - 文件名称: DataManager.cs
// - 创建者: #AuthorName# 
// - 创建时间: #CreateTime# 
// - 描述:
//==========================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static DataManager _instance;
    public static DataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
    }

    public int levelIndex;
    /// <summary>
    /// 音量
    /// </summary>
    public float musicVolume = 1;

    public bool isOpenMusic = true;

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        AudioListener.volume = volume;
    }

    public void SetOpenMusic(bool isOpenMusic)
    {
        this.isOpenMusic = isOpenMusic;
        if (isOpenMusic)
        {
            AudioListener.volume = musicVolume;
        }
        else
        {
            AudioListener.volume = 0;
        }

    }
}
