
using System;
using UnityEngine;

[Serializable]
public class DialogData
{
    [Header("�Ի�����"), TextArea(10, 20)]
    public string content;
    [Header("ͷ����ͼ")]
    public Sprite sprite;
}
