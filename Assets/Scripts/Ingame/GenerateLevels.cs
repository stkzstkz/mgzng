using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject Stage;
    public int Pos = 34;
    public bool creatingLevel = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingLevel)
        {
            creatingLevel = true;
            StartCoroutine(GenerateLvl());
        }
    }

    IEnumerator GenerateLvl()
    {
        Instantiate(Stage, new Vector3(0, 0, Pos), Quaternion.identity);
        Pos += 12;
        yield return new WaitForSeconds(3);
        creatingLevel = false;
    }
}