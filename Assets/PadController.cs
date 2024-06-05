using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadController : MonoBehaviour
{
    Pad[,] pads = new Pad[3, 4];
    public int current_octerve = 3;
    string[] current_strings = new string[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    KeyCode last_key = KeyCode.None;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<3; i++)
        {
            for(int j=0; j<4; j++)
            {
                string tmpname = (i+1).ToString() + (j+1).ToString();
                GameObject padobj = GameObject.Find(tmpname);
                Button button = padobj.GetComponent<Button>();
                Pad pad = padobj.GetComponent<Pad>();
                if(pad == null)
                {
                    Debug.Log("pad obj coud not be acchived");
                }
                pads[i, j] = pad;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            current_octerve = 4;
            last_key = KeyCode.UpArrow;
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            current_octerve = 2;
            last_key = KeyCode.DownArrow;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) 
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                current_octerve = 2;
            }
            else
            {
                current_octerve = 3;
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                current_octerve = 4;
            }
            else
            {
                current_octerve = 3;
            }
        }

        AsignScale(current_octerve, current_strings);
    }

    void AsignScale(int octerve,string[] strings)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                pads[i, j].text_name =strings[i*4+j] + octerve.ToString();
            }
        }
    }

    string[] GenerateShuffledScaleStrs()
    {
        string[] list = new string[] { "A", "A#","B","C","C#","D","D#","E","F","F#","G","G#" };
        for (int i = 12 - 1; i > 0; i--)
        {
            var j = Random.Range(0, i + 1); // ランダムで要素番号を１つ選ぶ（ランダム要素）
            var temp = list[i]; // 一番最後の要素を仮確保（temp）にいれる
            list[i] = list[j]; // ランダム要素を一番最後にいれる
            list[j] = temp; // 仮確保を元ランダム要素に上書き
        }
        return list;
    }
    public void Shuffle()
    {
        string[] strings = GenerateShuffledScaleStrs();
        current_strings = strings;
        AsignScale(this.current_octerve,strings);
    }
}
