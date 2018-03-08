using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    public  Frotation _Frota;

    public  Brotation _Brota;

    public  Urotation _Urota;

    public  Drotation _Drota;

    public  Lrotation _Lrota;

    public  Rrotation _Rrota;

    public  bool ButtonPush;

    Stack<string> Aremember = new Stack<string>(){};

    int shufnum;

    bool fin;

    public Texture text;

    // Use this for initialization
    void Start()
    {
        ButtonPush = false;
        shufnum = 10;
        fin = false;
    }

    IEnumerator Shuffle()
    {
        int i;

        for (i = 0; i < shufnum; i++)
        {
            yield return new WaitForSeconds(0.1f);
            switch (Random.Range(0, 12))
            {
                case 0: _Frota.RcolF = true;
                    Aremember.Push("F");
                    break;
                case 1: _Frota.colF = true;
                    Aremember.Push("Shift + F");
                    break;
                case 2: _Brota.RcolB = true;
                    Aremember.Push("B");
                    break;
                case 3: _Brota.colB = true;
                    Aremember.Push("Shift + B");
                    break;
                case 4: _Urota.RcolU = true;
                    Aremember.Push("U");
                    break;
                case 5: _Urota.colU = true;
                    Aremember.Push("Shift + U");
                    break;
                case 6: _Drota.RcolD = true;
                    Aremember.Push("D");
                    break;
                case 7: _Drota.colD = true;
                    Aremember.Push("Shift + D");
                    break;
                case 8: _Rrota.RcolR = true;
                    Aremember.Push("R");
                    break;
                case 9: _Rrota.colR = true;
                    Aremember.Push("Shift + R");
                    break;
                case 10: _Lrota.RcolL = true;
                    Aremember.Push("L");
                    break;
                case 11: _Lrota.colL = true;
                    Aremember.Push("Shift + L");
                    break;
                default:
                    break;
            }
        }
        yield return new WaitForSeconds(0.3f);
        ButtonPush = false;
        yield return null;
    }

    void OnGUI()
    {
        if (Aremember.Count == 0 && !fin)
        {
            // ボタンを表示する
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "シャッフル"))
            {
                ButtonPush = true;
                StartCoroutine("Shuffle");
            }
        }
        // ラベルを表示する
        if (Aremember.Count > 0 && !ButtonPush)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), Aremember.Peek());
            fin = true;
        }
        else if (fin == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Congratulations!!");
            if (GUILayout.Button("リロード")) {
                Application.LoadLevel("test2kake2"); // シーンの名前かインデックスを指定
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(_Frota.RcolF || _Frota.colF || _Brota.RcolB || _Brota.colB || _Urota.RcolU || _Urota.colU ||
            _Drota.RcolD || _Drota.colD || _Lrota.RcolL || _Lrota.colL || _Rrota.RcolR || _Rrota.colR || ButtonPush))
        {
            if (Input.GetKeyDown(KeyCode.F) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + F")
                {
                    _Frota.RcolF = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (Aremember.Peek() == "F")
                    {
                        _Frota.colF = true;
                        Aremember.Pop();
                    }
                }

            if (Input.GetKeyDown(KeyCode.B) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + B")
                {
                    _Brota.RcolB = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.B))
                {
                    if (Aremember.Peek() == "B")
                    {
                        _Brota.colB = true;
                        Aremember.Pop();
                    }
                }

            if (Input.GetKeyDown(KeyCode.U) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + U")
                {
                    _Urota.RcolU = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.U))
                {
                    if (Aremember.Peek() == "U")
                    {
                        _Urota.colU = true;
                        Aremember.Pop();
                    }
                }

            if (Input.GetKeyDown(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + D")
                {
                    _Drota.RcolD = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (Aremember.Peek() == "D")
                    {
                        _Drota.colD = true;
                        Aremember.Pop();
                    }
                }

            if (Input.GetKeyDown(KeyCode.L) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + L")
                {
                    _Lrota.RcolL = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.L))
                {
                    if (Aremember.Peek() == "L")
                    {
                        _Lrota.colL = true;
                        Aremember.Pop();
                    }
                }

            if (Input.GetKeyDown(KeyCode.R) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                if (Aremember.Peek() == "Shift + R")
                {
                    _Rrota.RcolR = true;
                    Aremember.Pop();
                }
            }
            else
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (Aremember.Peek() == "R")
                    {
                        _Rrota.colR = true;
                        Aremember.Pop();
                    }
                }
        }
    }
}