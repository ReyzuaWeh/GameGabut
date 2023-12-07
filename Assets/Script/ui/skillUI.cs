using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEngine;
using UnityEngine.UI;

public class skillUI : MonoBehaviour
{
    public SimplePlayerController user;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        user = user.GetComponent<SimplePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("SkillA")){
            slider.value = user.cd1 / user.delaySkill1;
        }else if(gameObject.CompareTag("SkillB")){
            slider.value = user.cd2 / user.delaySkill2;
        }else if(gameObject.CompareTag("SkillC")){
            slider.value = user.cd3/ user.delaySkill3;
        }else if(gameObject.CompareTag("SkillD")){
            slider.value = user.cd4 / user.delaySkill4;
        }
    }
}
