using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const int MENU_SCENE_INDEX = 1; // Сцене с меню присваиваем значение 1
    private const int GAME_SCENE_INDEX = 2; // Игровой сцене присваиваем значение 2
    private LevelLoader _levelLoader;  // ссылка на объект LevelLoader
    private static GameBootstrapper _instance; // синглтон
    private Game _game;

    private void Awake()
    {
        // проверяем, если у нас еще не создан _instance (GameBootstrapper), то присваиваем _instance_у GameBootstrapper
        // если GameBootstrapper уже создан, то новый GameBootstrapper удалаем, так как двух GameBootstrapper не может существовать.
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            DestroyImmediate(_instance);
        }

        _levelLoader = new LevelLoader(); // инициализируем LevelLoader

        DontDestroyOnLoad(this); // Команда, которая делает объект неудаляемым. 

        LoadMenuScene();
    }

    public static void LoadGameScene()
    {
        _instance._levelLoader.LoadScene(GAME_SCENE_INDEX, _instance, onLoaded: _instance.OnGameSceneLoadedCallback);

    }

    // Этим методом передаем управление всеми игровыми процессами экземпляру класса Game
    private void OnGameSceneLoadedCallback()
    {
        // если _game не равно null, очищаем ресурсы, запускаем новую игру  
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
        Debug.Log("Нажата кнопка Выход");
    }

    private void OnDestroy()
    {
        if (_game != null)
        {
            _game.Dispose();
        }
    }

}
