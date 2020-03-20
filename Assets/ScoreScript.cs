using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private GameObject GG;

    public Vars vars;
    // Start is called before the first frame update
    void Start()
    {
        vars = GameObject.Find("Vars").GetComponent<Vars>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Turns left: " + vars.Turns + "\n" + "Completed maps: " + vars.Completed;
        if(vars.Turns <= 0)
        {
            Instantiate(GG, transform.parent);
            if (vars.record < vars.Completed)
            {
                vars.record = vars.Completed;
                PlayerPrefs.SetInt("record", vars.record);
            }
            vars.reset();
        }
    }
}
