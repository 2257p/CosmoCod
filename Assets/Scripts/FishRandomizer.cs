using UnityEngine;
using UnityEngine.SceneManagement;

public class FishRandomizer : MonoBehaviour
{
    // 1st check (Rarity): 0 is common, 1 is rare, 2 is epic, 3 is legendary
    // 2nd check (Type): 1 is bad, 2 is mediocre, 3 is good, 4 is great
    // 3rd check (Mass): Randomized between 1 and 4
    public Vector3 previousPosition;
    int[] fishScale = {0, 0, 0, 0, 1, 1, 1, 2, 2, 3};

    public void Randomizer()
    {
        int fishScaleCheck = UnityEngine.Random.Range(0, fishScale.Length);
        float fishMassUnrounded = UnityEngine.Random.Range(1f, 4f);

        int fishRarity = fishScale[fishScaleCheck]; // (Rarity)
        int fishType = UnityEngine.Random.Range(1, 5); // (Type)
        float fishMass = Mathf.Round(fishMassUnrounded * 100f) / 100f; // (Mass)

        float fishPrice = (20f * fishRarity + 5f * fishType) * fishMass;
        int valuePerMass = 20 * fishRarity + 5 * fishType;

        SceneManager.LoadScene("CC Planet");
        Player.selectorX = 0;
        Player.selectorY = 0;
        Player.upperButtons = false;

        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(GameObject obj in allObjects)
        {
            if (obj.CompareTag("Player"))
            {
                obj.transform.position = previousPosition;
                break;
            }
        }

        string[] fishNames = {"Cod", "Salmon", "Pike", "Bluey", "Redfin", "Sparklefin", "Starfin", "Bubblefin", "Clownfish", "Firefish", "Anglerfish", "Beefish", "Frostking", "Goldking", "Rainbowking", "Sunking"};

        Inventory.addFish(new Fish(fishNames[valuePerMass / 5 - 1], fishRarity, fishPrice, fishMass));
    }
}