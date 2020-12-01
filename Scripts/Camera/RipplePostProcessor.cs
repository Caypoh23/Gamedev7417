using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RipplePostProcessor : MonoBehaviour
{
    [SerializeField] private Material _rippleMaterial;
    [SerializeField] private float _maxAmount = 50f;
    [SerializeField] [Range(0,1)] private float _friction = .9f;
    private float Amount = 0f;
 
    private void Update()
    {
        this._rippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this._friction;
    }

    public void RippleEffect()
    {
        this.Amount = this._maxAmount;
        Vector3 pos = Input.mousePosition;
        this._rippleMaterial.SetFloat("_CenterX", pos.x);
        this._rippleMaterial.SetFloat("_CenterY", pos.y);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this._rippleMaterial);
    }
}
