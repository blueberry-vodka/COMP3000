//==========================
// - 文件名称: DialogPanel.cs
// - 创建者: #AuthorName# 
// - 创建时间: #CreateTime# 
// - 描述:
//==========================

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [Header("文本内容")]
    public Text contentText;
    [Header("头像图片")]
    public Image avatorImage;
    //当前文本列表
    private List<DialogData> dialogDatas;
    //当前对话索引值
    private int index;

    private Action onComplete;

    public void SetData(List<DialogData> datas, Action onComplete)
    {
        dialogDatas = datas;
        index = 0;
        this.onComplete = onComplete;
        gameObject.SetActive(true);
        NextDialog();
    }

    private void NextDialog()
    {
        contentText.text = "";
        StartCoroutine(Typing(dialogDatas[index].content));
        if (dialogDatas[index].sprite == null)
        {
            avatorImage.gameObject.SetActive(false);
        }
        else
        {
            avatorImage.sprite = dialogDatas[index].sprite;
            avatorImage.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 打字机效果
    /// </summary>
    /// <returns></returns>
    IEnumerator Typing(string content)
    {
        for (int i = 0; i < content.Length; i++)  //循环
        {
            contentText.text += content[i];  //逐个输出保存在GetString变量中的文字
            yield return new WaitForSeconds(0.1f);  //每输出一个字，等待0.1秒
        }
    }

    public void OnButtonClick()
    {
        index++;
        Debug.Log(index);
        if (index < dialogDatas.Count)
        {
            NextDialog();
        }
        //最后一个啦
        else if(index == dialogDatas.Count)
        {
            gameObject.SetActive(false);
            onComplete();
        }
    }
}

