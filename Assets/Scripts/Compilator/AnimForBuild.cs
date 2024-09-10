using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimForBuild : MonoBehaviour
{
    public Animator Picture;
    public Animator Description;

    public void GoPicture(){
        Picture.SetTrigger("GOTO");
    }
    public void LeavePicture(){
        Picture.SetTrigger("RETURN");
    }
    public void GoDescription(){
        Description.SetTrigger("GOTO");
    }
    public void LeaveDescription(){
        Description.SetTrigger("RETURN");
    }
}
