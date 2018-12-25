using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newchangepicture : MonoBehaviour {

    public Sprite newImage;
    Sprite oldImage;
    AudioSource aus;
    Sprite tmpImage;
    // Use this for initialization
    void Start()
    {
        oldImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        tmpImage = gameObject.GetComponent<SpriteRenderer>().sprite;
        aus = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;
        mouse_touch();
    }

    public void MouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = tmpImage;
    }

    public void MouseClick()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newImage;

    }
    void mouse_touch()
    {
        AudioClip clip = (AudioClip)Resources.Load("Audios/coe/通用/鼠标接触", typeof(AudioClip));
        aus.clip = clip;
        aus.Play();
    }

}
