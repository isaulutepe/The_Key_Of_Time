using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DaktiloEffect : MonoBehaviour
{
    public Text text_box;
    private string Message = "" +
        "Nikola, having created a portal to examine quantum performance, finds himself trapped between two universes due to an unexpected malfunction. In order to return to the universe, he must collect the mysterious keys on the planet Astra. However, this is only possible within a seven-second period. Constantly pursued by aliens, Nikola struggles to collect the keys and return to the planet Zephyr. However, with each transition, alien attacks test Nikola’s resolve and complicate his mission to maintain inter-universal balance. As Nikola pushes the boundaries of science, he continues his mission to maintain the balance between universes amidst the extraordinary beauty of Astra and Zephyr.";
    private void Start()
    {
        StartCoroutine(Text_Player());
    }
    IEnumerator Text_Player()
    {
        foreach (char character in Message)
        {
            text_box.text = text_box.text + character;
            yield return new WaitForSeconds(0.08f);
        }
        StartCoroutine(playGame());
    }
    IEnumerator playGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
}
