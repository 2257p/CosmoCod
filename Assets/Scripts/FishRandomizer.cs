using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    // First check: 0 is common, 1 is rare, 2 is epic, 3 is legendary
    // Second check: 0 is bad, 1 is mediocre, 2 is good, 3 is great
    // Third check: Weight is randomized between 1 and 4

    int[] fishTypes = {0, 0, 0, 0, 1, 1, 1, 2, 2, 3};
    public void Randomizer()
    {
        int fishRank = UnityEngine.Random.Range(0, fishTypes.Length);

        int fishRarity = fishTypes[fishRank]; // First Check
        int fishType = UnityEngine.Random.Range(0, 3); // Second Check
        float fishMassUnrounded = UnityEngine.Random.Range(1f, 4f); // Third Check
        float fishMass = Mathf.Round(fishMassUnrounded * 100f) / 100f;

        Debug.Log(fishRarity);
        Debug.Log(fishType);
        Debug.Log(fishMassUnrounded);
        Debug.Log(fishMass);
    }
}
