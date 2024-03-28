using UnityEngine;

public class CardDragHandler : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    private Vector2 originalPosition;
    [SerializeField]
    private Vector2 raisedPosition;
    private CardManager CardManager;
    public GameObject EnemySlots;


    void Awake()
    {

        // Grab CardManager Script
        CardManager = GameObject.Find("CardManager").GetComponent<CardManager>();

        EnemySlots = GameObject.Find("EnemySlots");
    }

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        isDragging = false;
        transform.position = originalPosition;

        // Check if the mouse is over the activation area
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapPointAll(new Vector2(GetMouseWorldPosition().x, GetMouseWorldPosition().y));
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("EnemyMonster"))
            {

                string monsterName = collider.gameObject.name;

                Debug.Log(gameObject.name + " dragged on " + monsterName);

                int cardIndex = transform.GetSiblingIndex();
                CardManager.ActivateCard(gameObject, monsterName, cardIndex);
                break;
            }
            /*  else if (collider.CompareTag("HeroActivationZone"))
             {
                 // This card activates over heroes
                 Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

                 int index = transform.GetSiblingIndex();

                 // Activate the card for heroes
                 CardManager.ActivateHeroCard(gameObject, index, gameObject.name);
                 Debug.Log("Hero Card activated!");
                 break;
             } */
        }
    }


    void OnMouseEnter()
    {
        if (!isDragging)
        {
            originalPosition = transform.position;
            raisedPosition = new(originalPosition.x, originalPosition.y + 1f);

            transform.position = raisedPosition;
        }
    }

    void OnMouseExit()
    {
        if (!isDragging)
        {
            transform.position = originalPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


}