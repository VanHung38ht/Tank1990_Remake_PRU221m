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
        // Tính toán góc xoay t?i ða d?a trên s? v?ng xoay
        float maxRotationAngle = rotationCount * 360f;

        // Lýu tr? v? trí ban ð?u
        Vector3 initialPosition = transform.localPosition;

        while (true)
        {
            // Xoay theo góc xoay t?i ða
            float rotationAngle = 0f;
            while (rotationAngle < maxRotationAngle)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                rotationAngle += rotationSpeed * Time.deltaTime;
                yield return null;
            }

            // Nh?y lên
            float jumpTime = 0f;
            while (jumpTime < jumpDuration)
            {
                float t = jumpTime / jumpDuration;
                float currentHeight = Mathf.Lerp(0f, jumpHeight, t);
                transform.localPosition = initialPosition + new Vector3(0f, currentHeight, 0f);
                jumpTime += Time.deltaTime;
                yield return null;
            }

            // Rõi xu?ng
            float fallTime = 0f;
            while (fallTime < jumpDuration)
            {
                float t = fallTime / jumpDuration;
                float currentHeight = Mathf.Lerp(jumpHeight, 0f, t);
                transform.localPosition = initialPosition + new Vector3(0f, currentHeight, 0f);
                fallTime += Time.deltaTime;
                yield return null;
            }

            // Ð?i m?t kho?ng th?i gian trý?c khi nh?y lên ti?p
            yield return new WaitForSeconds(delayDuration);
        }
    }
}
