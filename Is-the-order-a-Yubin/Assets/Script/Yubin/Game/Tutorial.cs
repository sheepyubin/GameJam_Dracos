using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class Tutorial : MonoBehaviour
{
    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
