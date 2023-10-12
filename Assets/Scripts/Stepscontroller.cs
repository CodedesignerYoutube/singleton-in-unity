using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepscontroller : MonoBehaviour
{
    public void IncreaseStep()
    {
        SceneController.Instance.IncreaseStep();
    }
}
