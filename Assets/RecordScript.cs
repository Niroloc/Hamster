using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScript : MonoBehaviour
{
    Vars vars;
    // Start is called before the first frame update
    void Start()
    {
        vars = GameObject.Find("Vars").GetComponent<Vars>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Best: " + vars.record;
    }
}
