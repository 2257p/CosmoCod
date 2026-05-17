using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    // First check: 0 is common, 1 is uncommon, 2 is rare, 3 is legendary
    // Second check: 0 is bad, 1 is mediocre, 2 is good, 3 is great
    // Third check: 0 is mini, 1 is small, 2 is medium, 3 is large
    int[] fishTypes = {0, 0, 0, 0, 1, 1, 1, 2, 2, 3};
    public void Randomizer()
    {
        int fishRank = UnityEngine.Random.Range(0, fishTypes.Length);
        int selectedFish = fishTypes[fishRank];

        int fishScale = UnityEngine.Random.Range(0, 3);
        int fishSize = UnityEngine.Random.Range(0, 3);

        Debug.Log(selectedFish);
        Debug.Log(fishScale);
        Debug.Log(fishSize);
    }
}
