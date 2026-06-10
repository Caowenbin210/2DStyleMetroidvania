using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实体受击特效
/// </summary>
public class Entity_VFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("受伤特效")]
    [SerializeField] private Material onDamageMaterial;
    [SerializeField] private float onDamageVfxDuration = .2f;

    private Material originalMaterial;
    private Coroutine onDamageVfxCoroutine;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;
    }

    /// <summary>
    /// 调用受击特效
    /// </summary>
    public void PlayOnDamageVfx()
    {
        if(onDamageVfxCoroutine != null)
            StopCoroutine(OnDamageVfxCo());

        onDamageVfxCoroutine = StartCoroutine(OnDamageVfxCo());
    }

    private IEnumerator OnDamageVfxCo()
    {
        sr.material = onDamageMaterial;

        yield return new WaitForSeconds(onDamageVfxDuration);
        sr.material = originalMaterial;
    }

}
