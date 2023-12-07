using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    public SimplePlayerController user;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = user.hpNow / user.maxHP;
    }
}
