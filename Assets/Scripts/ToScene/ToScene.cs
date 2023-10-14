using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToIngame() 
    {
        SceneManager.LoadScene("Ingame");
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("Result");
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
