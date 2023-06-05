using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStateManager : MonoBehaviour
{
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

    private void Awake()
    {
        btns_Pause = rect_Pause.GetComponentsInChildren<Button>();
        btns_StageSelect = rect_StageSelect.GetComponentsInChildren<Button>();
        btns_Start = rect_Start.GetComponentsInChildren<Button>();

        OnStartMenu();
        print("OnGame �Լ��� �߰��� �� �����");
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
    }







    public void OnGame(int _stageIndex)
    {
        curSceneState = SceneState.Game;

        stageIndex = _stageIndex;

        // + stage controll

        // + btn interact false
        BtnSetting(false, false, false);
    }

    public void OnPauseMenu()
    {
        curSceneState = SceneState.PauseMenu;
        BtnSetting(true, false, false);
    }

    public void OnStageSelectMenu()
    {
        curSceneState = SceneState.StageSelectMenu;
        stageIndex = 0;
        BtnSetting(false, true, false);
    }

    public void OnStartMenu()
    {
        curSceneState = SceneState.StartMenu;
        stageIndex = 0;
        BtnSetting(false, false, true);
    }







    private void BtnSetting(bool _pause, bool _stage, bool _start)
    {
        for (int i = 0; i < btns_Pause.Length; i++)
        {
            btns_Pause[i].gameObject.SetActive(_pause);
        }
        for (int i = 0; i < btns_StageSelect.Length; i++)
        {
            btns_StageSelect[i].gameObject.SetActive(_stage);
        }
        for (int i = 0; i < btns_Start.Length; i++)
        {
            btns_Start[i].gameObject.SetActive(_start);
        }
    }
}

public enum SceneState
{
    Game,
    PauseMenu,
    StageSelectMenu,
    StartMenu,
}
