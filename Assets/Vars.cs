using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{

    public int Turns;
    public int Completed;
    public int record;

    public void reset()
    {
        Turns = 50;
        Completed = 0;
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Vars");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
// Start is called before the first frame update
    void Start()
    {
        record = PlayerPrefs.GetInt("record");
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
