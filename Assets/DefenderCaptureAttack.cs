using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCaptureAttack : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public PlayerMovement defenderMov;

    public float rotationAngleStart = -30f;
    public float rotationAngleEnd = 30f;

    public float returnZPos;

    private void OnEnable()
    {
        transform.localPosition = new Vector3(0, 0, returnZPos);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(RotateInRange());

        defenderMov.playerSpeed = defenderMov.playerSpeed / 2.0f;
    }

    private void OnDisable()
    {
        defenderMov.playerSpeed = defenderMov.playerSpeed * 2.0f;
    }

    private IEnumerator RotateInRange()
    {
        // Rotate from rotationAngleStart to rotationAngleEnd
        transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), rotationAngleStart);

        // Begin rotating with rotationSpeed
        // Wait until reaches rotationAngleEnd
        while((transform.localRotation.eulerAngles.y - rotationAngleStart) % 360 < (rotationAngleEnd - rotationAngleStart))
        {
            transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
