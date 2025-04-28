//==========================
// - 文件名称: LevelData.cs
// - 创建者: #AuthorName# 
// - 创建时间: #CreateTime# 
// - 描述:
//==========================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    [Header("关卡id")]
    public int id;
    [Header("关卡名称")]
    public string name;
    [Header("对话数据")]
    public List<DialogData> dialogDatas;
    [Header("关卡类型")]
    public LevelType levelType;
    [Header("关卡次数")]
    public int waveNum;
    [Header("角色的位置")]
    public Vector3 position;
    [Header("摄像机的位置")]
    public Vector3 cameraPosition;
}

/// <summary>
/// 关卡类型
/// </summary>
public enum LevelType
{
    Level1, Level2, Level3, Level4, Level5
}
