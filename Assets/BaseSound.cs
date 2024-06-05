using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseSound : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] KeyCode key;
    [SerializeField] int octerve = 3;

    float volume = 1f;
    [SerializeField] float volumeExtinctionSpeed = 4f;
    bool flag = false;
    bool under_push = false;
    PadController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PadController").GetComponent<PadController>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (pc.current_octerve == octerve && Input.GetKeyDown(key))
        {
            OnButtonPlessed();
        }
        else if (pc.current_octerve != octerve || Input.GetKeyUp(key))
        {
            OnButtonReleased();
        }
        if (flag == true)
        {
            volume -= volumeExtinctionSpeed * Time.deltaTime;
            if (volume < 0f)
            {
                flag = false;
                source.volume = 1f;
                volume = 1f;
                source.Stop();
            }
            else
            {
                source.volume = volume;
            }
        }
    }
    public void OnButtonPlessed()
    {
        flag = false;
        under_push = true;
        Debug.Log("plessed");
        source.volume = 1f;
        volume = 1f;
        source.Play();
    }
    public void OnButtonReleased()
    {
        Debug.Log("released");
        flag = true;
        under_push = false;
    }
}
