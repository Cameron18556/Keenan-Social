using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string playerName;
    public Role role;
    public bool wolf;

    public int id;

    public float stockOwnership;

    public TMP_Text roleDescription;
    public TMP_Text stockDescription;
    public TMP_Text currentCashText;

    public List<Section> ownedSections = new List<Section>();
    public List<GameObject> sectionButtons = new List<GameObject>();

    public int currentCash;

    public Transform topOfStanderdList;
    public Transform topOfSectionList;

    public GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int income)
    {
        currentCash += income;
        currentCashText.text = "$" + currentCash;
        TurnOver();
    }

    public void Earn()
    {
        currentCash += role.OnEarn(role.standerdIncome);
        TurnOver();
    }

    public void TurnStart()
    {

    }

    public void TurnOver()
    {
        currentCash += role.standerdIncome;
        GameManager.Instance.turnOver = true;
    }

    public void SetUpButtons()
    {
        foreach(GameObject button in sectionButtons)
        {
            Destroy(button);
        }

        for (int i = 0; i < ownedSections.Count; i++)
        {
            Button currentButton = Instantiate(buttonPrefab, topOfSectionList).GetComponent<Button>();
            sectionButtons.Add(currentButton.gameObject);
            currentButton.GetComponentInChildren<TMP_Text>().text = ownedSections[i].name;
            currentButton.onClick.AddListener(ownedSections[i].operation);
            currentButton.transform.position = new Vector3(currentButton.transform.position.x, currentButton.transform.position.y + (currentButton.GetComponent<RectTransform>().rect.height * i), currentButton.transform.position.z);
        }
    }

    private void OnEnable()
    {
        currentCashText.text = "$" + currentCash;
        roleDescription.text = role.description;

        FindOwnership();

        stockDescription.text = "%" + stockOwnership.ToString();
    }

    public void FindOwnership()
    {
        float ownership = 0;

        foreach (Section section in ownedSections)
        {
            ownership += section.stockPercentage;
        }
        stockOwnership = ownership;
    }
}
