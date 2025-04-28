//==========================
// - 文件名称: GameManager.cs
// - 创建者: #AuthorName# 
// - 创建时间: #CreateTime# 
// - 描述:
//==========================

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("是否运行")]
    public bool isRunning;
    [Header("关卡数据")]
    public List<LevelData> levelDatas;
    //游戏开始啦
    public Action onStartGame;

    public GameObject bossSceneGo;

    public LevelData levelData
    {
        get
        {
            return levelDatas[DataManager.instance.levelIndex];
        }
    }
    private List<DialogData> dialogDatas
    {
        get
        {
            return levelDatas[DataManager.instance.levelIndex].dialogDatas;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void Start()
    {
        StartGame();
        //判断是否是最后一关
        if (DataManager.instance.levelIndex == levelDatas.Count - 1)
        {
            bossSceneGo.SetActive(true);
        }
    }

    private void StartGame()
    {
        if (dialogDatas != null && dialogDatas.Count > 0) 
        {
            UIManager.instance.dialogPanel.SetData(dialogDatas, OnCompleteDialog);
        }
        //关卡文本
        UIManager.instance.UpdateLevelText(levelData.name);
    }

    /// <summary>
    /// 完成对话 开始游戏啦
    /// </summary>
    private void OnCompleteDialog()
    {
        Debug.Log("完成对话 开始游戏啦"); 
        isRunning = true;
        onStartGame?.Invoke();
    }


    /// <summary>
    /// 下一关
    /// </summary>
    public void NextLevel()
    {
        DataManager.instance.levelIndex++;
        if (DataManager.instance.levelIndex >= levelDatas.Count)
        {
            Debug.Log("全部关卡已经完成了");
            UIManager.instance.GameWinAnimation();
        }
        else
        {
            Debug.Log("下一关:" + DataManager.instance.levelIndex);
            SceneManager.LoadScene("01_Level");
        }
    }

}
