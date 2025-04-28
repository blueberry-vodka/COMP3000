
using System;
using UnityEngine;

[Serializable]
public class DialogData
{
    [Header("对话内容"), TextArea(10, 20)]
    public string content;
    [Header("头像贴图")]
    public Sprite sprite;
}
