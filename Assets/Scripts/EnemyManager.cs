using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] randTrans;
    public GameObject[] enemyWaves;

    private GameObject enemyWave;
    private bool isCompleted;

    private int randWaveNum;

    [HideInInspector] public int waveNum;

    [Header("宝箱")]
    public GameObject chestGo;


    public GameObject enemyUIPrefab;

    public static EnemyManager instance;



    private void Awake()
    {
        instance = this;
        waveNum = 1;
    }

    void OnDestroy()
    {
        instance = null;
    }

    private void Start()
    {
        GameManager.instance.onStartGame += StartGame;
    }

    private void StartGame()
    {
        int randPosNum = Random.Range(0, randTrans.Length);
        enemyWave = Instantiate(enemyWaves[0], randTrans[randPosNum].position, Quaternion.identity);
    }

    private void Update()
    {
        if (GameManager.instance.isRunning)
        {
            if (enemyWave.transform.childCount == 0)
            {
                isCompleted = true;
            }

            if (isCompleted)
            {
                //关卡wave小
                if (waveNum < GameManager.instance.levelData.waveNum) 
                {
                    int randNum = Random.Range(0, randTrans.Length);

                    waveNum++;
                    UIManager.instance.UpdateWaveText(waveNum, GameManager.instance.levelData.waveNum);

                    enemyWave = Instantiate(enemyWaves[randWaveNum], randTrans[randNum].position, Quaternion.identity);
                    isCompleted = false;
                }
                //关卡都结束了
                else
                {
                    ShowChest();
                }
            }
        }
        return;
        if (GameManager.instance.isRunning)
        {
            if (enemyWave.transform.childCount == 0)
            {
                isCompleted = true;
                randWaveNum = Random.Range(0, enemyWaves.Length);
            }

            if (isCompleted)
            {
                int randNum = Random.Range(0, randTrans.Length);

                waveNum++;
                //UIManager.instance.UpdateWaveText(waveNum);

                enemyWave = Instantiate(enemyWaves[randWaveNum], randTrans[randNum].position, Quaternion.identity);
                isCompleted = false;
            }
        }
    }
    public void ShowChest()
    {
        chestGo.transform.position = randTrans[randWaveNum].position;
        chestGo.SetActive(true);
    }
}
