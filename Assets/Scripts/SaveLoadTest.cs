using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SaveLoadTest : MonoBehaviour
{

    private static GameObject player;
    public GameObject textPrefab;

    private void Start()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(GameObject obj in allObjects)
        {
            if (obj.CompareTag("Player"))
            {
                player = obj;
                break;
            }
        }
    }

    void Update()
    {
        SaveDetect();
        LoadDetect();
    }

    private void SaveDetect()
    {
        if (Keyboard.current[Key.S].wasPressedThisFrame)
        {
            SaveLoadFile.Save();
            GameObject txt = Instantiate(textPrefab);
            txt.GetComponent<TMP_Text>().text = "game saved";
            txt.transform.position = player.transform.position + new Vector3(-6f, 3f);
            txt.transform.parent = player.transform;
            StartCoroutine(textFadeOut(txt));
        }
    }

    private void LoadDetect()
    {
        if (Keyboard.current[Key.L].wasPressedThisFrame)
        {
            SaveLoadFile.Load();
            GameObject txt = Instantiate(textPrefab);
            txt.GetComponent<TMP_Text>().text = "game loaded";
            txt.transform.position = player.transform.position + new Vector3(-6f, 3f);
            txt.transform.parent = player.transform;
            StartCoroutine(textFadeOut(txt));
        }
    }

    IEnumerator textFadeOut(GameObject text)
    {

        yield return new WaitForSeconds(1);

        for(int i = 30; i > 0; i--)
        {
            Color col = text.GetComponent<TMP_Text>().color;
            col.a -= 0.1f;
            text.GetComponent<TMP_Text>().color = col;
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(text);
    }

}
