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

    public List<Role> roles = new List<Role>();

    public TMP_Text playerShower;

    public GameObject startScreen;

    public GameObject BlockerWithText;

    public GameObject playerTurnPrefab;

    public List<GameObject> playerTurns;

    public bool turnOver = false;

    public static GameManager Instance;

    public int currentPlayerId = 0;

    // Singleton instantiation
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
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

        int pos = 0;

        foreach(PlayerData player in players)
        {
            GameObject playerTurnCurrent = Instantiate(playerTurnPrefab, canvas.transform);

            Player playerPlayerComponent = playerTurnCurrent.GetComponent<Player>();

            playerPlayerComponent.id = pos;

            playerTurns.Add(playerTurnCurrent);

            int chosenRole = Random.Range(0, roles.Count);

            Debug.Log("chosen role pos = " + chosenRole);

            player.role = roles[chosenRole];

            playerPlayerComponent.playerName = player.name;

            roles[chosenRole].AddToGameObject(playerTurnCurrent);

            playerTurnCurrent.SetActive(false);

            pos++;
        }

        StartCoroutine(GoThroughPlayers());
    }

    public IEnumerator GoThroughPlayers()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        currentPlayerId = 0;
        foreach(GameObject currentPlayerTurn in playerTurns)
        {
            currentPlayerTurn.SetActive(true);
            Player currentPlayer = currentPlayerTurn.GetComponent<Player>();
            GameObject blocker = Instantiate(BlockerWithText, canvas.transform);
            blocker.GetComponentInChildren<TMP_Text>().text = "please pass this device to player: " + currentPlayer.playerName;
            yield return new WaitUntil(() => turnOver == true);
            turnOver = false;
            currentPlayerTurn.SetActive(false);
            currentPlayerId++;
        }

        GoThroughThePlayerAgaign();
    }

    public void GoThroughThePlayerAgaign()
    {
        StartCoroutine(GoThroughPlayers());
    }
}
