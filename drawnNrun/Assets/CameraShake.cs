using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnShake(float duration, float strenght)
    {
        transform.DOShakePosition(duration, strenght);
    }
    public static void Shake(float duration, float strenght) => Instance.OnShake(duration, strenght);
}
