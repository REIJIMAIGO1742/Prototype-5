using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private Gamemanager gamemanager;

    public int difficulty;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gamemanager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDIfficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDIfficulty()
    {
        Debug.Log(gameObject.name + "Was cliked");
        gamemanager.StartGame(difficulty);
    
    }
}
