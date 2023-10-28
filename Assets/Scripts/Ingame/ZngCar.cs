using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManagerへの統合やクラスを別で作って継承するなどの工夫をして見やすくしたい．
public class ZngCar : MonoBehaviour
{
    [SerializeField] private GameObject ZngPrefab;
    [SerializeField] private GameObject OjmPrefab;
    private float interval4Zng;
    private float interval4Ojm;
    // Before interval for Zng
    [SerializeField] private float MinSpeed4Zng = 1f;
    [SerializeField] private float MaxSpeed4Zng = 2f;
    [SerializeField] private float MinSpeed4Ojm = 3f;
    [SerializeField] private float MaxSpeed4Ojm = 5.5f;
    private float time4Zng = 0f;
    private float time4Ojm = 0f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float leftRightSpeed = 4f;
    [SerializeField] private float limit = 8.6f;
    private bool DirectionR = true;
    private bool OjmDirectionR = true;
    [SerializeField] private float x = 42f;

    // Start is called before the first frame update
    void Start()
    {
        interval4Ojm = Random.Range(MinSpeed4Ojm,MaxSpeed4Ojm);
        interval4Zng = Random.Range(MinSpeed4Zng,MaxSpeed4Zng);
        OjmDirectionR = Random.value > 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        time4Ojm += Time.deltaTime;
        time4Zng += Time.deltaTime;
        if (time4Zng > interval4Zng)
        {
            GameObject Zng = Instantiate(ZngPrefab);
            Vector3 ZngPos = this.transform.position;
            ZngPos.y = 2.3f;
            ZngPos.z -= 15f;
            Zng.transform.position = ZngPos;
            interval4Zng = Random.Range(MinSpeed4Zng,MaxSpeed4Zng);
            time4Zng = 0f;
        }
        if (time4Ojm > interval4Ojm) 
        {
            GameObject Ojm = Instantiate(OjmPrefab);
            Vector3 OjmPos = this.transform.position;
            OjmPos.y = 1.37f;
            OjmDirectionR = Random.value > 0.5;
            if (OjmDirectionR)
            {
                OjmPos.x = x;
            }else{
                OjmPos.x = -1*x;
            }
            Ojm.transform.position = OjmPos;
            interval4Ojm = Random.Range(MinSpeed4Ojm,MaxSpeed4Ojm);
            time4Ojm = 0f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (transform.position.x <= -limit)
        {
            DirectionR = true;
        }
        if (transform.position.x >= limit)
        {
            DirectionR = false;
        }
        if(DirectionR)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }else{
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }
}