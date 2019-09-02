using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Start,
    Runing,
    End

}
public class GameController : MonoBehaviour
{
    public GameState _State;
    public Button startBtn;
    // Start is called before the first frame update
    void Start()
    {
        _State = GameState.Start;
        startBtn = GameObject.Find("Canvas/Start").GetComponent<Button>();
        startBtn.onClick.AddListener(StartGame);
        PlayerController.GetInstance.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        if (_State==GameState.Runing)
        {
        PlayerController.GetInstance.Update();
            
        }
    }
    void StartGame()
    {
        startBtn.gameObject.SetActive(false);
        _State = GameState.Runing;
        PlayerController.GetInstance._pState = playerState.Alive;
    }
}
