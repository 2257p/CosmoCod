using UnityEngine;

public class FishRandomizer : MonoBehaviour
{
    int[] fishTypes = {0, 0, 0, 0, 1, 1, 1, 2, 2, 3};
    public void Randomizer()
    {
        int num = UnityEngine.Random.Range(0, fishTypes.Length);
        int selectedFish = fishTypes[num];
        Debug.Log(selectedFish);
    }
}
