using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    public List<Vector2> MonsterSlotPositionsList;
    public List<GameObject> MonsterPrefabsList;
    public GameObject EnemySlots; // Enemy Parent Holder
    public GameObject MonsterHealthSliderPrefab;

    public List<GameObject[]> monsterGroups; // List of MonsterGroup instances
    public GameObject[] MonstersWeak = new GameObject[4];

    public float MonsterSlotPositionsYPosition = -2f;

    void Start()
    {

        MonsterSlotPositionsList = new List<Vector2>
    {
        new(4.5f, MonsterSlotPositionsYPosition),
        new(6.5f, MonsterSlotPositionsYPosition),
        new(8.5f, MonsterSlotPositionsYPosition),
        new(10.5f, MonsterSlotPositionsYPosition),
    };

        // Initialize the list of monster groups and add groups
        monsterGroups = new List<GameObject[]>
        {
            MonstersWeak
        };

    }

    public void SpawnMonsters(GameObject[] monsters)
    {
        int i = -1;
        foreach (GameObject monster in monsters)
        {
            i++;
            if (monster != null)
            {
                GameObject Monster = Instantiate(monster, MonsterSlotPositionsList[i], Quaternion.identity);

                Monster.name = monster.name + i;

                Monster.transform.SetParent(EnemySlots.transform, false);

                // Add a 2D Box Collider
                BoxCollider2D collider = Monster.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(1.8f, 3f);
                collider.offset = new Vector2(0f, 0.5f); // Centered

                // Grab CardManager Script
                MonsterData MonsterDataScript = Monster.GetComponent<MonsterData>();
                MonsterDataScript.CreateMonsterHealthSlider(i);
                MonsterDataScript.CreateMonsterUI(i);
            }
        }
    }

    public void MonsterTurnInt()
{
    Transform enemySlotsTransform = EnemySlots.transform;

    if (enemySlotsTransform == null)
    {
        Debug.LogError("EnemySlots not found!");
        return;
    }

    for (int i = 0; i < enemySlotsTransform.childCount; i++)
    {
        Transform childTransform = enemySlotsTransform.GetChild(i);
        MonsterData monsterData = childTransform.GetComponent<MonsterData>();

        if (monsterData != null)
        {
            monsterData.UpdateTurnInt();
        }
        else
        {
            Debug.LogError("MonsterData not found on child " + i + " of EnemySlots.");
        }
    }
}

    public void SpawnWeakMonsters(){
        // Spawn the monsters
        SpawnMonsters(MonstersWeak);
    }

   /*  public void UpdateMonsterPositions(int index)
    {
        Transform enemySlotsParent = EnemySlots.transform;

        for (int i = index; i < enemySlotsParent.childCount; i++)
        {
            Transform EnemySlotTransform = enemySlotsParent.GetChild(i);
            Vector2 currentPosition = new Vector2(EnemySlotTransform.position.x, EnemySlotTransform.position.y);
            Vector2 newPosition = currentPosition - new Vector2(-2f, 0f);
            EnemySlotTransform.position = new Vector3(newPosition.x, newPosition.y, EnemySlotTransform.position.z);
        }
    } */


}

