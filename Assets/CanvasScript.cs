using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public int size = 5;

    [SerializeField] private GameObject Box;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject GG;

    public bool jump = false;
    //public bool ar = false;
    //public Vector3 HamPrevPos;
    public GameObject[,] Boxes;

    List<int[]> boxes_in_path = new List<int[]>();
    List<Vector3> path = new List<Vector3>();

    //добавить рисование пути в метод goodgame()
    public void goodgame()
    {
        Instantiate(GG, transform);

        foreach(int[] i in boxes_in_path)
        {
            Destroy(Boxes[i[0], i[1]]);
        }
        var line = GetComponent<LineRenderer>();
        line.positionCount = path.Count;
        line.SetPositions(path.ToArray());
    }

    int Hamsteri = 0;
    int Hamsterj = 0;
    GameObject[,] arrow;
    int getrot(int di, int dj)
    {
        switch (di)
        {
            case -1:
                switch (dj)
                {
                    case -1:
                        return 2;
                    case 0:
                        return 3;
                    case 1:
                        return 4;

                }
                break;
            case 0:
                switch (dj)
                {
                    case -1:
                        return 1;
                    case 1:
                        return 5;

                }
                break;
            case 1:
                switch (dj)
                {
                    case -1:
                        return 8;
                    case 0:
                        return 7;
                    case 1:
                        return 6;

                }
                break;
        }
        return 0;
    }

    Vector3 getrot2(int dir)
    {
        switch (dir)
        {
            case 1:
                return new Vector3(0, 0, 270);
            case 2:
                return new Vector3(0, 0, 225);
            case 3:
                return new Vector3(0, 0, 180);
            case 4:
                return new Vector3(0, 0, 135);
            case 5:
                return new Vector3(0, 0, 90);
            case 6:
                return new Vector3(0, 0, 45);
            case 7:
                return new Vector3(0, 0, 0);
            case 8:
                return new Vector3(0, 0, -45);
        }
        return new Vector3(0, 0, 0);
    }

    int[] getdidj(int dir)
    {
        switch (dir)
        {
            case 1:
                return new int[2] { 0, -1 };
            case 2:
                return new int[2] { -1, -1 };
            case 3:
                return new int[2] { -1, 0 };
            case 4:
                return new int[2] { -1, 1 };
            case 5:
                return new int[2] { 0, 1 };
            case 6:
                return new int[2] { 1, 1 };
            case 7:
                return new int[2] { 1, 0 };
            case 8:
                return new int[2] { 1, -1 };
        }
        return new int[2] { 0, 0 };
    }

    int GetOpportunities(int Hamsteri, int Hamsterj)
    {
        int num = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if ((i != 0 || j != 0) && size > Hamsteri + i && Hamsteri + i >= 0 && size > Hamsterj + j && Hamsterj + j >= 0 && Boxes[Hamsteri + i, Hamsterj + j] != null)
                {
                    num++;
                }
            }
        }
        return num;
    }

    // Start is called before the first frame update
    void Start()
    {
        Boxes = new GameObject[size, size];
        arrow = new GameObject[size, size];
        Hamsteri = Random.Range(1, size - 1);
        Hamsterj = Random.Range(1, size - 1);
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                Boxes[i, j] = Instantiate(Box, transform);
                Boxes[i, j].transform.localPosition = new Vector3((j - size / 2) * (900 / size), (size / 2 - i) * (900 / size), 0);
                Boxes[i, j].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 800 / size);
                Boxes[i, j].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800 / size);
                Boxes[i, j].GetComponent<BoxScript>().J = j;
                Boxes[i, j].GetComponent<BoxScript>().I = i;
            }
        }
        Boxes[Hamsteri, Hamsterj].GetComponent<BoxScript>().IsWithHamster = true;
        Boxes[Hamsteri, Hamsterj].GetComponent<Image>().color = new Color32(0, 0, 0, 255);

        path.Add(new Vector3((Hamsterj - size / 2) / (1.2f * size), (size / 2 - Hamsteri) / (1.2f * size), 0));
        boxes_in_path.Add(new int[2] { Hamsteri, Hamsterj });
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == true)
        {
            int di = 0, dj = 0;
            int border = GetOpportunities(Hamsteri, Hamsterj);
            //Debug.Log(border);
            int choice = Random.Range(1, border);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i != 0 || j != 0) && size > Hamsteri + i && Hamsteri + i >= 0 && size > Hamsterj + j && Hamsterj + j >= 0 && Boxes[Hamsteri + i, Hamsterj + j] != null)
                    {
                        choice--;
                        if (choice == 0)
                        {
                            di = i;
                            dj = j;
                            break;
                        }
                    }
                }
                if (choice == 0)
                {
                    break;
                }
            }

            if (arrow[Hamsteri, Hamsterj] == null)
            {
                arrow[Hamsteri, Hamsterj] = Instantiate(Arrow, transform);
                arrow[Hamsteri, Hamsterj].transform.localPosition = new Vector3((Hamsterj - size / 2) * (900 / size), (size / 2 - Hamsteri) * (900 / size), 0);
                arrow[Hamsteri, Hamsterj].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 800 / size);
                arrow[Hamsteri, Hamsterj].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800 / size);
                arrow[Hamsteri, Hamsterj].transform.SetAsFirstSibling();
            }
            Quaternion abc = new Quaternion();
            abc.eulerAngles = getrot2(getrot(di, dj));
            arrow[Hamsteri, Hamsterj].transform.rotation = abc;


            Hamsteri += di;
            Hamsterj += dj;

            path.Add(new Vector3((Hamsterj - size / 2) / (1.2f * size), (size / 2 - Hamsteri) / (1.2f * size), 0));
            boxes_in_path.Add(new int[2]{ Hamsteri, Hamsterj });

            if (GetOpportunities(Hamsteri, Hamsterj) == 0)
            {
                GameObject.Find("Vars").GetComponent<Vars>().Completed++;
                goodgame();
            }

            jump = false;
        }
    }
}