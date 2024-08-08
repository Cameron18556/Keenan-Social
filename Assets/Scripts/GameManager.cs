using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData
{
    public string name;
    public Role role;
}

public class GameManager : MonoBehaviour
{
    public GameObject canvas;

    public TMP_InputField nameInput;

    public List<string> playerNames;

    public List<PlayerData> players = new List<PlayerData>();

    public List<Role> roles;

    public TMP_Text playerShower;

    public GameObject startScreen;

    public GameObject BlockerWithText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerName()
    {
        if (nameInput.text == null || nameInput.text == "")
        {
            return;
        }

        playerNames.Add(nameInput.text);
        

        PlayerData player = new PlayerData();

        player.name = nameInput.text;

        int chosenRole = Random.Range(0, roles.Count);

        player.role = roles[chosenRole];
        players.Add(player);
        roles.RemoveAt(chosenRole);

        string playersShowText = "Players: \n";

        foreach (string p in playerNames)
        {
            playersShowText += p + "\n";
        }

        playerShower.text = playersShowText;

        nameInput.text = "";
    }

    public void ReadyPressed()
    {
        startScreen.SetActive(false);

        foreach(PlayerData player in players)
        {
            GameObject currentBlocker = Instantiate(BlockerWithText, canvas.transform);

            string message = "GIVE THE DEVICE TO PLAYER " + player.name;

            currentBlocker.GetComponentInChildren<TMP_Text>().text = message;
        }
    }
}
