using System.Buffers.Text;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public void Start()
    {

        // Find MonsterManager GO and Script
        GameObject MonsterManager = GameObject.Find("MonsterManager");
        MonsterManager monsterScript = MonsterManager.GetComponent<MonsterManager>();
    }
}
//
// Card Functionalities
//
public static class AxeAtkClass
{
    public static string name = "";
    public static int energy = 1;

    public static void Activate(string EnemyMonsterName)
    {
        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++AxeAtkCard activated!+++");

        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}

public static class FireBallClass
{
    public static string name = "FireBall";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++FireBall activated!+++");

        
        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}
public static class GroupShieldClass
{
    public static string name = "GroupShield";
    public static int energy = 1;

    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++GroupShield activated!+++");


        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}
public static class GrpSpawnClass
{
    public static string name = "GrpSpawn";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++GrpSpawn activated!+++");


        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}
public static class IceShardClass
{
    public static string name = "IceShard";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++IceShard activated!+++");



        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);
    }
}
public static class LightBeamClass
{
    public static string name = "LightBeam";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++LightBeam activated!+++");


        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}
public static class RangeAtkClass
{
    public static string name = "RangeAtk";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++RangeAtk activated!+++");


        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}
public static class ShieldClass
{
    public static string name = "Shield";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++Shield activated!+++");



        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);
    }
}
public static class SpawnClass
{
    public static string name = "Spawn";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++Spawn activated!+++");



        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);
    }
}
public static class SwordAtkClass
{
    public static string name = "SwordAtk";
    public static int energy = 1;
    public static void Activate(string EnemyMonsterName)
    {

        int damageAmount = 10;

        // Implement AxeAtk-specific functionality here
        Debug.Log("+++SwordAtk activated!+++");


        // Grab MonsterData Script
        MonsterData monsterData = GameObject.Find(EnemyMonsterName).GetComponent<MonsterData>();

        monsterData.TakeDamage(damageAmount);

    }
}