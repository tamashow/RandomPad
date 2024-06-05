using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float volume = 1f;
    string last_name = "C3";
    [SerializeField] float volumeExtinctionSpeed = 4f;
    bool flag = false;
    AudioSource selectedAudioSource=null;
    bool under_push = false;
    string name_buffer = "C3";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedAudioSource != null)
        {
            if (flag == true)
            {
                volume -= volumeExtinctionSpeed * Time.deltaTime;
                if (volume < 0f)
                {
                    flag = false;
                    selectedAudioSource.volume = 1f;
                    volume = 1f;
                    selectedAudioSource.Stop();    
                }
                else
                {
                    selectedAudioSource.volume = volume;
                }
            }
        }

    }

    public void OnButtonPlessed()
    {
        under_push = true;
        GameObject.Find("PadController").GetComponent<PadController>().Shuffle();
        Debug.Log("plessed");
        volume = 1f;
        selectedAudioSource = GameObject.Find(text_name+"_source").GetComponent<AudioSource>();
        selectedAudioSource.Play();
    }
    public void OnButtonReleased()
    {
        Debug.Log("released");
        flag = true;
        under_push = false;
        GetComponentInChildren<TextMeshProUGUI>().text = name_buffer;
    }
    public string text_name
    {
        get{ return GetComponentInChildren<TextMeshProUGUI>().text; }
        set{
            if (under_push)
            {
                name_buffer = value;
            }
            else
            {
                GetComponentInChildren<TextMeshProUGUI>().text = value;
            }
        }
    }
}
