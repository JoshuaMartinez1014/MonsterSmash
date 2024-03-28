using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CardManager CardManager; // Grab PlayerManagerObject
    public GameObject EnemySlots;
    public MonsterManager MonsterManager;

    public TMP_Text EnergyText;
    public int Energy = 3;

    void Awake()
    {
        // Grab CardManager Script
        CardManager = GameObject.Find("CardManager").GetComponent<CardManager>();

        EnemySlots = GameObject.Find("EnemySlots");/* .GetComponent<GameObject>(); */

    }

    private void Start()
    {
        EnergyText.SetText(Energy.ToString());
        Debug.Log("Start Game");
        CardManager.DrawFiveCards();

    }

    public void UseEnergy(int amount)
    {
        Energy -= amount;
        EnergyText.SetText(Energy.ToString());
    }

    public void ResetEnergy()
    {
        Debug.Log("Energy Reset");
        Energy = 3;
        EnergyText.SetText(Energy.ToString());
    }


    public void EndTurn()
    {
        /*  isPlayerTurn = !isPlayerTurn; */
        Debug.Log("End Turn");
        ResetEnergy();

        CardManager.ClearCards();
        CardManager.DrawFiveCards();

       MonsterManager.MonsterTurnInt();

        /* Play Monsters Turn */
        
    }

}