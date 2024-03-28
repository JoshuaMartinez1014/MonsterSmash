using UnityEngine;
using UnityEngine.UI;

public class HeroMonsterData : MonoBehaviour
{
    public string HeroMonsterName;
    private float health;
    public float maxHealth;
    public float damage;
    public int turnInt;

    public Slider HeroMonsterHealthSliderPrefab; // Reference to the Slider UI element
    public Slider HeroMonsterHealthSlider; // Reference to the instantiated Slider UI element
    private MonsterManager HeroMonsterManager; // Grab PlayerManagerObject

    public Canvas GameUi;

    public void Ability()
    {
        Debug.Log("Monster ability activated!");
    }

    void Awake()
    {
        // Grab CardManager Script
        MonsterManager MonsterManager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();

        // Grab GameUI Canvas
        GameUi = GameObject.FindWithTag("GameUI").GetComponent<Canvas>();
    }

    void Start()
    {

        // Initialize health and update the health bar
        health = maxHealth;
        UpdateHealthBar();

        gameObject.tag = "EnemyMonster";

    }

    public void CreateMonsterHealthSlider(int index)
    {

        // Spawn the health slider
        HeroMonsterHealthSlider = Instantiate(HeroMonsterHealthSliderPrefab, Vector3.zero, Quaternion.identity);
        HeroMonsterHealthSlider.name = "MonsterHealthSlider" + index;
        HeroMonsterHealthSlider.transform.SetParent(GameUi.transform, false);

        // Calculate the position relative to the MonsterData object
        Vector2 sliderPosition = transform.position + new Vector3(0f, 2f, 0f);
        HeroMonsterHealthSlider.transform.position = sliderPosition;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(HeroMonsterName + " took " + amount + " damage!");
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
        if (HeroMonsterHealthSlider != null)
        {
            HeroMonsterHealthSlider.maxValue = maxHealth;
            HeroMonsterHealthSlider.value = health;
        }
        else
        {
            Debug.LogWarning("HeroMonsterHealthSlider is null");
        }
    }

    void Die()
    {
        /*   int index = transform.GetSiblingIndex();
          MonsterManager.UpdateMonsterPositions(index); */
        // Perform death actions, such as destroying the monster GameObject

        Debug.Log(HeroMonsterName + " died!");
        Destroy(HeroMonsterHealthSlider.gameObject);
        Destroy(gameObject);
    }
}
