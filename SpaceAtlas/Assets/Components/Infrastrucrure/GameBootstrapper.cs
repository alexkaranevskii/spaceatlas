using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const int MENU_SCENE_INDEX = 1; // ����� � ���� ����������� �������� 1
    private const int GAME_SCENE_INDEX = 2; // ������� ����� ����������� �������� 2
    private LevelLoader _levelLoader;  // ������ �� ������ LevelLoader
    private static GameBootstrapper _instance; // ��������
    private Game _game;

    private void Awake()
    {
        // ���������, ���� � ��� ��� �� ������ _instance (GameBootstrapper), �� ����������� _instance_� GameBootstrapper
        // ���� GameBootstrapper ��� ������, �� ����� GameBootstrapper �������, ��� ��� ���� GameBootstrapper �� ����� ������������.
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            DestroyImmediate(_instance);
        }

        _levelLoader = new LevelLoader(); // �������������� LevelLoader

        DontDestroyOnLoad(this); // �������, ������� ������ ������ �����������. 

        LoadMenuScene();
    }

    public static void LoadGameScene()
    {
        _instance._levelLoader.LoadScene(GAME_SCENE_INDEX, _instance, onLoaded: _instance.OnGameSceneLoadedCallback);

    }

    // ���� ������� �������� ���������� ����� �������� ���������� ���������� ������ Game
    private void OnGameSceneLoadedCallback()
    {
        // ���� _game �� ����� null, ������� �������, ��������� ����� ����  
        if (_game != null)
        {
            _game.Dispose();
        }
        _game = new Game(_levelLoader);
    }

    public void LoadMenuScene()
    {
        _levelLoader.LoadScene(MENU_SCENE_INDEX, this);
    }
    public static void ExitGameScene()
    {
        Debug.Log("������ ������ �����");
    }

    private void OnDestroy()
    {
        if (_game != null)
        {
            _game.Dispose();
        }
    }

}
