using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;

    [HideInInspector]
    public SceneState curSceneState = SceneState.Game;
    private int stageIndex = 0;

    [SerializeField]
    private RectTransform rect_Pause;
    private Button[] btns_Pause;
    [SerializeField]
    private RectTransform rect_StageSelect;
    private Button[] btns_StageSelect;
    [SerializeField]
    private RectTransform rect_Start;
    private Button[] btns_Start;
    [SerializeField]
    private RectTransform rect_Fail;
    private Button[] btns_Fail;
    [SerializeField]
    private RectTransform rect_Clear;
    private Button[] btns_Clear;

    [SerializeField]
    private Transform[] playerPos;
    [SerializeField]
    private Movement playerCS;

    [SerializeField]
    private List<GameObject> starObjects;

    private Count timeCount;
    private RectTransform rect_timeCount;
    [SerializeField]
    private TextMeshProUGUI txt_remainingTime;

    private void Awake()
    {
        instance = this;

        btns_Pause = rect_Pause.GetComponentsInChildren<Button>();
        btns_StageSelect = rect_StageSelect.GetComponentsInChildren<Button>();
        btns_Start = rect_Start.GetComponentsInChildren<Button>();
        btns_Fail = rect_Fail.GetComponentsInChildren<Button>();
        btns_Clear = rect_Clear.GetComponentsInChildren<Button>();

        OnStartMenu();
        print("OnGame �Լ��� �߰��� �� �����"); // what is this?
    }

    private void Start()
    {
        timeCount = Count.instance;
        rect_timeCount = timeCount.GetComponent<RectTransform>();
        txt_remainingTime.text = "Time remaining: " + Mathf.Ceil(timeCount.time) + "s";
    }

    void Update()
    {
        InputCheck();
        Settings();
    }

    private void InputCheck()
    {
        if(curSceneState == SceneState.StartMenu)
        {
            if (Input.anyKeyDown)
            {
                OnStageSelectMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (curSceneState == SceneState.Game)
            {
                OnPauseMenu();
            }
            else if (curSceneState == SceneState.PauseMenu)
            {
                OnGame(stageIndex);
            }
        }
    }

    private void Settings()
    {
        Time.timeScale = curSceneState == SceneState.Game ? 1 : 0;

        rect_Start.anchoredPosition = curSceneState == SceneState.StartMenu ? Vector3.zero : Vector3.up * 5000;
        rect_Pause.anchoredPosition = curSceneState == SceneState.PauseMenu ? Vector3.zero : Vector3.up * 5000;
        rect_StageSelect.anchoredPosition = curSceneState == SceneState.StageSelectMenu ? Vector3.zero : Vector3.up * 5000;
        rect_Fail.anchoredPosition = curSceneState == SceneState.FailMenu ? Vector3.zero : Vector3.up * 5000;
        rect_Clear.anchoredPosition = curSceneState == SceneState.ClearMenu ? Vector3.zero : Vector3.up * 5000;
        rect_timeCount.anchoredPosition = curSceneState == SceneState.Game ? Vector3.zero : Vector3.up * 5000;
    }






    public void OnClear()
    {
        starObjects[0].SetActive(true);
        starObjects[1].SetActive(timeCount.time >= 60);
        starObjects[2].SetActive(timeCount.time >= 120);

        curSceneState = SceneState.ClearMenu;
        BtnSetting(SceneState.ClearMenu);

        txt_remainingTime.text = "Time remaining: " + Mathf.Ceil(timeCount.time) + "s";
        timeCount.time = timeCount.limitTime;
    }

    public void Restart()
    {
        OnGame(stageIndex);
    }

    public void OnGame(int _stageIndex)
    {
        curSceneState = SceneState.Game;
        stageIndex = _stageIndex;
        BtnSetting(SceneState.Game);

        playerCS.gameObject.transform.position = playerPos[_stageIndex - 1].position;
    }

    public void OnPauseMenu()
    {
        curSceneState = SceneState.PauseMenu;
        BtnSetting(SceneState.PauseMenu);
    }

    public void OnStageSelectMenu()
    {
        curSceneState = SceneState.StageSelectMenu;
        stageIndex = 0;
        BtnSetting(SceneState.StageSelectMenu);
    }

    public void OnStartMenu()
    {
        curSceneState = SceneState.StartMenu;
        stageIndex = 0;
        BtnSetting(SceneState.StartMenu);
    }

    public void OnFail()
    {
        curSceneState = SceneState.FailMenu;
        BtnSetting(SceneState.FailMenu);
        timeCount.time = timeCount.limitTime;
    }






    private void BtnSetting(SceneState _sceneState)
    {
        for (int i = 0; i < btns_Pause.Length; i++)
        {
            btns_Pause[i].gameObject.SetActive(_sceneState == SceneState.PauseMenu);
        }
        for (int i = 0; i < btns_StageSelect.Length; i++)
        {
            btns_StageSelect[i].gameObject.SetActive(_sceneState == SceneState.StageSelectMenu);
        }
        for (int i = 0; i < btns_Start.Length; i++)
        {
            btns_Start[i].gameObject.SetActive(_sceneState == SceneState.StartMenu);
        }
        for (int i = 0; i < btns_Fail.Length; i++)
        {
            btns_Fail[i].gameObject.SetActive(_sceneState == SceneState.FailMenu);
        }
        for (int i = 0; i < btns_Clear.Length; i++)
        {
            btns_Clear[i].gameObject.SetActive(_sceneState == SceneState.ClearMenu);
        }
    }
}

public enum SceneState
{
    Game,
    PauseMenu,
    StageSelectMenu,
    StartMenu,
    FailMenu,
    ClearMenu,
}
