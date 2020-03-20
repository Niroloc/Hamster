using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    public int I = 0;
    public int J = 0;
    public bool IsWithHamster = false;
    public int Direction = 0;
    [SerializeField] private GameObject GG;
    [SerializeField] private GameObject Arrow;

    private GameObject Turns = null;
    public void OnClick()
    {
        gameObject.GetComponentInParent<CanvasScript>().jump = true;
        gameObject.GetComponentInParent<CanvasScript>().Boxes[I, J] = null;
        
        GameObject.Find("Score").GetComponent<ScoreScript>().vars.Turns -= 1;

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
