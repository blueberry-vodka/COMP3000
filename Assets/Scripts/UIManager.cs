using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("几波")]
    public Text waveText;
    [Header("关卡")]
    public Text levelText;
    public static UIManager instance;

    public Image[] hpImages;
    [Header("游戏失败")]
    public Animator gameOverAnim;
    [Header("对话面板")]
    public DialogPanel dialogPanel;
    [Header("游戏胜利")]
    public Animator gameWinAnim;

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void UpdateWaveText(int _num,int _maxNum)
    {
        if (_num <= 9)
            waveText.text = "WAVE 0" + _num.ToString();
        else
            waveText.text = "WAVE " + _num.ToString() + "/" + _maxNum;

        if (_maxNum < 9)
            waveText.text += "/0" + _maxNum;
        else
            waveText.text += "/" + _maxNum;
    }

    public void UpdateLevelText(string level)
    {
        levelText.text = level;
    }

    public void UpdateHp(int _hp)
    {
        for(int i = 0; i < hpImages.Length; i++)
        {
            if (i < _hp)
                hpImages[i].gameObject.SetActive(true);
            else
                hpImages[i].gameObject.SetActive(false);
        }
    }

    public void GameOverAnimation()
    {
        Time.timeScale = 0;
        gameOverAnim.gameObject.SetActive(true);
        gameOverAnim.SetTrigger("GameOver");
    }

    public void GameWinAnimation()
    {
        Time.timeScale = 0;
        gameWinAnim.gameObject.SetActive(true);
        gameWinAnim.SetTrigger("GameOver");
    } 

    /// <summary>
    /// 重新开始按钮
    /// </summary>
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("01_Level");
    }

    /// <summary>
    /// 返回按钮
    /// </summary>
    public void OnRetrnButtonClick()
    {
        SceneManager.LoadScene("00_Start");

    }
}
