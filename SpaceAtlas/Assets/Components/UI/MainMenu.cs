using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _exitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        // ��� ������� �� ������������� �� ���� ��� �����������
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        // ��� ������� �� ������������� �� ���� ������� �� ����������
        _exitGameButton.onClick.AddListener(OnExitGameButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        GameBootstrapper.LoadGameScene();
    }

    private void OnExitGameButtonClicked()
    {
        _exitGameButton.onClick.RemoveListener(OnExitGameButtonClicked);
        GameBootstrapper.ExitGameScene();
    }
}
