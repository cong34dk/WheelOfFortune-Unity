using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControllerScript : MonoBehaviour
{
    public float spinSpeed = 200f;
    private bool isSpinning = false;
    private float targetAngle;

    private void Update()
    {
        if (isSpinning)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, spinSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, angle);

            if (Mathf.Approximately(angle, targetAngle))
            {
                isSpinning = false;
                //Ket qua dung chay
                Debug.Log("Ket qua: " + GetResult());
            }
        }
    }

    public void StartSpin()
    {
        if (!isSpinning)
        {
            targetAngle = Random.Range(0, 360);
            isSpinning = true;
        }
    }

    private string GetResult()
    {
        float segmentAngle = 360f / 6;
        int result = Mathf.FloorToInt(targetAngle / segmentAngle);
        return "Phan " + (result + 1);
    }
}
