using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{

    public GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        string text = objs.Length.ToString();

        GameObject.Find("enemyCount").GetComponent<TextMeshProUGUI>().SetText(text);

    }
}
