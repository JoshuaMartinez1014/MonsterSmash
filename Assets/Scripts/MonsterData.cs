using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterData : MonoBehaviour
{
    public string monsterName;
    private float health;
    public float maxHealth;
    public float damage;
    public int maxTurnInt;
    public int turnInt;

    public Slider MonsterHealthSliderPrefab; // Slider UI Element ref 
    public Slider MonsterHealthSlider; // Reference to the instantiated Slider UI element

    public TMP_Text TurnIntTextPrefab;
    public TMP_Text TurnIntText;
    private MonsterManager MonsterManager; // Grab PlayerManagerObject

    public Canvas GameUi;


    void Awake()
    {
        // Grab CardManager Script
        MonsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();

        // Grab GameUI Canvas
        GameUi = GameObject.FindWithTag("GameUI").GetComponent<Canvas>();
    }

    void Start()
    {

        // Initialize health and update the health bar
        health = maxHealth;
        UpdateHealthBar();
        TurnIntText.SetText(maxTurnInt.ToString());

        gameObject.tag = "EnemyMonster";

    }

    public void CreateMonsterHealthSlider(int index)
    {

        // Spawn the health slider
        MonsterHealthSlider = Instantiate(MonsterHealthSliderPrefab, Vector3.zero, Quaternion.identity);
        MonsterHealthSlider.name = "MonsterHealthSlider" + index;
        MonsterHealthSlider.transform.SetParent(GameUi.transform, false);

        // Calculate the position relative to the MonsterData object
        Vector2 sliderPosition = transform.position + new Vector3(0f, 2f, 0f);
        MonsterHealthSlider.transform.position = sliderPosition;
    }

    public void CreateMonsterUI(int index)
    {

        // Instantiate the TextMeshPro - Text object
        TurnIntText = Instantiate(TurnIntTextPrefab, Vector3.zero, Quaternion.identity);

        TurnIntText.name = "TurnIntText : " + monsterName +
        " : " + index;
        TurnIntText.transform.SetParent(GameUi.transform, false);

         // Calculate the position relative to the MonsterData object
        Vector2 TurnIntPosition = transform.position + new Vector3(.75f, 1f, 0f);
        TurnIntText.transform.position = TurnIntPosition;
       

    }

    public void TakeDamage(int amount)
    {
        Debug.Log(monsterName + " took " + amount + " damage!");
        health -= damage;
        health = Mathf.Clamp(health, 0f, maxHealth); // Clamp health to be within [0, maxHealth]
        UpdateHealthBar();

        if (health <= 0f)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (MonsterHealthSlider != null)
        {
            MonsterHealthSlider.maxValue = maxHealth;
            MonsterHealthSlider.value = health;
        }
        else
        {
            Debug.LogWarning("MonsterHealthSlider is null");
        }
    }

    public void UpdateTurnInt()
    {
        turnInt--;
        TurnIntText.SetText(turnInt.ToString());
        if (turnInt == 0)
        {

            Ability();
            turnInt = maxTurnInt;
            TurnIntText.SetText(turnInt.ToString());
        }
    }

    public void Ability()
    {
        Debug.Log("Monster ability activated!");
         
    }

    void Die()
    {
        /*   int index = transform.GetSiblingIndex();
          MonsterManager.UpdateMonsterPositions(index); */
        // Perform death actions, such as destroying the monster GameObject

        Debug.Log(monsterName + " died!");
        Destroy(MonsterHealthSlider.gameObject);
        Destroy(gameObject);
        Destroy(TurnIntText.gameObject);
    }
}