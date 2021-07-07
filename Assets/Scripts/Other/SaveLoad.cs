using UnityEngine;
using SaveSystem;

public class SaveLoad : MonoBehaviour
{
    private bool newGame = false;
    private GameObject _player;
    public Vector3 startPosition = new Vector3(-54, -12, -2);
    public float startPlayerHealth = 110;
    void Awake()
    {
        _player = GameObject.Find("Girl");
        if (_player != null)
        {
            if (EasySave.Load<bool>("newGame"))
            {
                _player.transform.position = startPosition;
                _player.GetComponent<Player>().health = startPlayerHealth;
            }
            else if (!EasySave.Load<bool>("newGame"))
            {
                _player.transform.position = EasySave.Load<Vector3>("playerPosition");
                _player.GetComponent<Player>().health = EasySave.Load<float>("playerHealth");
            }
            newGame = false;
            EasySave.Save("newGame", newGame);
        }
    }
    public void Save()
    {
        EasySave.Save("playerPosition", _player.transform.position);
        EasySave.Save("playerHealth", _player.GetComponent<Player>().health);
    }
    public void Load()
    {
        EasySave.Load<Vector3>("playerPosition");
        EasySave.Load<float>("playerHealth");
    }
    public void NewGame()
    {
        if (!newGame)
            newGame = true;
        EasySave.Save("newGame", newGame);
    }
}
