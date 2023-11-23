using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UECDelete : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] private float interval = 10f;
    private bool NotOnPlayer;

    // Update is called once per frame
    void Update()
    {
        if (NotOnPlayer)
        {
            time += Time.deltaTime;
        }
        if (time > interval)
        {
            GameManager.Instance.MakeStage();
            Destroy(transform.root.gameObject);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NotOnPlayer = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NotOnPlayer = false;
            time = 0;
        }
    }
}
