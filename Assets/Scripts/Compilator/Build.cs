using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Build : MonoBehaviour
{
    public string Code;
    public StartProcess(){
        Code = GameObject.Find("Input").GetComponent<InputField>().text;
    }
}
