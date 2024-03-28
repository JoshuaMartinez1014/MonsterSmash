using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{

    public List<GameObject> deck;  // Holds Each Card
    public List<GameObject> playDeck;  // Creates Playing List for Cards
    public GameObject CardSlots; // Game Object for Cards when created
    private GameManager GameManager; // Grab PlayerManagerObject
    public List<GameObject> playerHand;  // Holds the cards in the player's hand

    public float xUpdatePosition = 2f;

    public Vector2 StartingCardSlot = new Vector2(-4f, -4.25f);


    private bool isCardSlotEmpty = true;

    void Awake()
    {
        // Grab CardManager Script
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Create a new playDeck from the main deck
        playDeck = new List<GameObject>(deck);
    }

 

    public void DrawCard()
    {
        // Shuffle the deck if it's empty
        if (playDeck.Count == 0)
        {
            ShufflePlayDeck();

        }

        // Shuffle the deck if it's empty
        if (playDeck.Count == 0)
        {
            ShufflePlayDeck();
        }

        // Get a random card from the deck
        int randomIndex = Random.Range(0, playDeck.Count);
        GameObject cardPrefab = playDeck[randomIndex];

        string cardName = cardPrefab.name;
        Debug.Log("===Drawing Card:" + cardName + "===");

        if (isCardSlotEmpty)
        {
            // Instantiate the card prefab
            GameObject card = Instantiate(cardPrefab, StartingCardSlot, Quaternion.identity);
            card.transform.SetParent(CardSlots.transform, false);

            card.name = cardPrefab.name; // Remove "(clone)" from the name

            // Add the CardDrag script to the card
            CardDragHandler cardDrag = card.AddComponent<CardDragHandler>();

            // Add a collider to the card
            BoxCollider2D collider = card.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(2f, 3f); // Set collider size as needed
        }
        else
        {
            Transform lastChild = CardSlots.transform.GetChild(CardSlots.transform.childCount - 1);
            Vector2 lastChildPosition = lastChild.position;
            lastChildPosition += new Vector2(xUpdatePosition, 0f);

            // Instantiate the card prefab
            GameObject card = Instantiate(cardPrefab, lastChildPosition, Quaternion.identity);
            card.transform.SetParent(CardSlots.transform, false);

            card.name = cardPrefab.name; // Remove "(clone)" from the name
            card.transform.SetParent(CardSlots.transform, false);

            // Add the CardDrag script to the card
            CardDragHandler cardDrag = card.AddComponent<CardDragHandler>();

            // Add a collider to the card
            BoxCollider2D collider = card.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(2f, 3f); // Set collider size as needed

        }

        // Remove the drawn card from the deck
        playDeck.RemoveAt(randomIndex);

        // Add card to player hand prevent to copies
        playerHand.Add(cardPrefab);
    }

    public void DrawFiveCards()
    {
        Debug.Log("Drawing 5 Cards");
        for (int i = 0; i < 5; i++)
        {

            // Shuffle the deck if it's empty
            if (playDeck.Count == 0)
            {
                ShufflePlayDeck();
            }

            // Get a random card from the deck
            int randomIndex = Random.Range(0, playDeck.Count);
            GameObject cardPrefab = playDeck[randomIndex];

            string cardName = cardPrefab.name;
         /*    Debug.Log("===Drawing Card:" + cardName + "===");
 */
            if (isCardSlotEmpty)
            {
                // Instantiate the card prefab
                GameObject card = Instantiate(cardPrefab, StartingCardSlot, Quaternion.identity);
                card.transform.SetParent(CardSlots.transform, false);


                card.name = cardPrefab.name; // Remove "(clone)" from the name
                card.transform.SetParent(CardSlots.transform, false);


                // Add the CardDrag script to the card
                CardDragHandler cardDrag = card.AddComponent<CardDragHandler>();

                // Add a collider to the card
                BoxCollider2D collider = card.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(2f, 3f); // Set collider size as needed

                card.GetComponent<SpriteRenderer>().sortingOrder = 5;

                isCardSlotEmpty = false;
            }
            else
            {
                Transform lastChild = CardSlots.transform.GetChild(CardSlots.transform.childCount - 1);
                Vector2 lastChildPosition = lastChild.position;
                lastChildPosition += new Vector2(xUpdatePosition, 0f);

                // Instantiate the card prefab
                GameObject card = Instantiate(cardPrefab, lastChildPosition, Quaternion.identity);
                card.transform.SetParent(CardSlots.transform, false);

                card.name = cardPrefab.name; // Remove "(clone)" from the name
                card.transform.SetParent(CardSlots.transform, false);

                // Add the CardDrag script to the card
                CardDragHandler cardDrag = card.AddComponent<CardDragHandler>();

                // Add a collider to the card
                BoxCollider2D collider = card.AddComponent<BoxCollider2D>();
                collider.size = new Vector2(2f, 3f); // Set collider size as needed

            }

            // Remove the drawn card from the deck
            playDeck.RemoveAt(randomIndex);

            // Add card to player hand prevent to copies
            playerHand.Add(cardPrefab);

        }
    }

    public void DeleteCard()
    {
        Debug.Log("Removing Card");
        // Get the last child of the "Cards" GameObject
        int lastChildIndex = CardSlots.transform.childCount - 1;
        if (lastChildIndex >= 0)
        {
            Transform lastChild = CardSlots.transform.GetChild(lastChildIndex);

            // Destroy the last child
            Destroy(lastChild.gameObject);
        }
    }

    public void ActivateCard(GameObject cardObject, string EnemyMonsterName, int index)
    {

        if (GameManager.Energy < 1)
        {
            Debug.Log("Not enough energy to activate card");
            return;
        }
        else
        {
            switch (cardObject.name)
            {
                case "AxeAtk":
                    AxeAtkClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(AxeAtkClass.energy);
                    break;
                case "FireBall":
                    FireBallClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(FireBallClass.energy);
                    break;
                case "GroupShield":
                    GroupShieldClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(GroupShieldClass.energy);
                    break;
                case "GrpSpawn":
                    GrpSpawnClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(GrpSpawnClass.energy);
                    break;
                case "IceShard":
                    IceShardClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(IceShardClass.energy);
                    break;
                case "LightBeam":
                    LightBeamClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(LightBeamClass.energy);
                    break;
                case "RangeAtk":
                    RangeAtkClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(RangeAtkClass.energy);
                    break;
                case "Shield":
                    ShieldClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(ShieldClass.energy);
                    break;
                case "Spawn":
                    SpawnClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(SpawnClass.energy);
                    break;
                case "SwordAtk":
                    SwordAtkClass.Activate(EnemyMonsterName);
                    GameManager.UseEnergy(SwordAtkClass.energy);
                    break;
                default:
                    Debug.LogWarning("Unknown card: " + cardObject.name);
                    break;
            }

            Transform cardsParent = CardSlots.transform;

            for (int i = index; i < cardsParent.childCount; i++)
            {
                Transform cardTransform = cardsParent.GetChild(i);
                Vector2 currentPosition = new Vector2(cardTransform.position.x, cardTransform.position.y);
                Vector2 newPosition = currentPosition - new Vector2(xUpdatePosition, 0f);
                cardTransform.position = new Vector3(newPosition.x, newPosition.y, cardTransform.position.z);
            }


            // Delete the card
            Destroy(cardObject);


        }
    }

    public void ClearCards()
    {
        Debug.Log("Clearing Cards");


        // Loop through all child objects and destroy them
        foreach (Transform child in CardSlots.transform)
        {
            Destroy(child.gameObject);
        }

           isCardSlotEmpty = true;

    }

    public void ShufflePlayDeck()
    {
        // Create a new playDeck from the main deck excluding cards in the player's hand
        playDeck = new List<GameObject>(deck);

        /* foreach (GameObject deckCard in deck)
        {
            // Check if the Cards GameObject contains the card
            bool cardAlreadyInPlay = false;
            foreach (Transform cardTransform in CardSlots.transform)
            {
                if (cardTransform.gameObject.name == deckCard.name)
                {
                    cardAlreadyInPlay = true;
                    break;
                }
            }

            if (!cardAlreadyInPlay)
            {
                playDeck.Add(deckCard);
            }
        } */

        isCardSlotEmpty = true;
    }

};

