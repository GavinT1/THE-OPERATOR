using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject nodePrefab; // Drag your node prefab here
    public Sprite[] scribbleSprites; // Drag your UI_0, UI_1, etc. sprites here
    public GameObject[] allGridSlots; // Drag your 16 slots here

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        // 1. Pick two random slots for a RED connection
        int startIdx = Random.Range(0, 8); // Pick from first half
        int endIdx = Random.Range(8, 16);  // Pick from second half

        // 2. Create the Start Node
        SpawnNode(allGridSlots[startIdx], scribbleSprites[0], Color.red, "RedStart");

        // 3. Create the End Node
        SpawnNode(allGridSlots[endIdx], scribbleSprites[0], Color.red, "RedEnd");
    }

    void SpawnNode(GameObject slot, Sprite graphic, Color color, string nodeTag)
{
    // 1. Create a NEW copy of the prefab first
    GameObject newNode = Instantiate(nodePrefab, slot.transform.position, Quaternion.identity);

    // 2. Set the parent of the NEW copy (newNode), NOT the nodePrefab
    newNode.transform.SetParent(slot.transform); 

    // 3. Reset position to center it in the slot
    newNode.transform.localPosition = Vector3.zero;

    // 4. Now change the Sprite and Tag on the NEW copy
    SpriteRenderer sr = newNode.GetComponent<SpriteRenderer>();
    if(sr != null) {
        sr.sprite = graphic;
        sr.color = color;
    }
    newNode.tag = nodeTag; 
}
}