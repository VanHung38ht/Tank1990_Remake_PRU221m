using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImge : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public int rotationCount = 2;
    public float jumpHeight = 0.4f;
    public float jumpDuration = 0.3f;
    public float delayDuration = 0.1f;

    private void Start()
    {
        StartCoroutine(RotateAndJumpAnimation());
    }

    private IEnumerator RotateAndJumpAnimation()
    {
        // T�nh to�n g�c xoay t?i �a d?a tr�n s? v?ng xoay
        float maxRotationAngle = rotationCount * 360f;

        // L�u tr? v? tr� ban �?u
        Vector3 initialPosition = transform.localPosition;

        while (true)
        {
            // Xoay theo g�c xoay t?i �a
            float rotationAngle = 0f;
            while (rotationAngle < maxRotationAngle)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                rotationAngle += rotationSpeed * Time.deltaTime;
                yield return null;
            }

            // Nh?y l�n
            float jumpTime = 0f;
            while (jumpTime < jumpDuration)
            {
                float t = jumpTime / jumpDuration;
                float currentHeight = Mathf.Lerp(0f, jumpHeight, t);
                transform.localPosition = initialPosition + new Vector3(0f, currentHeight, 0f);
                jumpTime += Time.deltaTime;
                yield return null;
            }

            // R�i xu?ng
            float fallTime = 0f;
            while (fallTime < jumpDuration)
            {
                float t = fallTime / jumpDuration;
                float currentHeight = Mathf.Lerp(jumpHeight, 0f, t);
                transform.localPosition = initialPosition + new Vector3(0f, currentHeight, 0f);
                fallTime += Time.deltaTime;
                yield return null;
            }

            // �?i m?t kho?ng th?i gian tr�?c khi nh?y l�n ti?p
            yield return new WaitForSeconds(delayDuration);
        }
    }
}
