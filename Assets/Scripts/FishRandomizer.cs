using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    // First check: 0 is common, 1 is rare, 2 is epic, 3 is legendary
    // Second check: 0 is bad, 1 is mediocre, 2 is good, 3 is great
    // Third check: Weight is randomized between 1 and 4

    int[] fishScale = {0, 0, 0, 0, 1, 1, 1, 2, 2, 3};
    public void Randomizer()
    {
        int fishScaleCheck = UnityEngine.Random.Range(0, fishScale.Length); // For 1st check
        float fishMassUnrounded = UnityEngine.Random.Range(1f, 4f); // For 3rd check

        int fishRarity = fishScale[fishScaleCheck]; // First Check (Rarity)
        int fishType = UnityEngine.Random.Range(1, 5); // Second Check (Type)
        float fishMass = Mathf.Round(fishMassUnrounded * 100f) / 100f; // Third Check (Mass)

        float fishPrice = (20f * fishRarity + 5f * fishType) * fishMass;
        int valuePerMass = 20 * fishRarity + 5 * fishType;

        Debug.Log(fishRarity);
        Debug.Log(fishType);
        Debug.Log(fishMass);

        Debug.Log(fishPrice);
        Debug.Log($"${valuePerMass}/kg");

    }
}