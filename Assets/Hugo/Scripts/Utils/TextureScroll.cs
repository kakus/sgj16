using UnityEngine;
using System.Collections;

public class TextureScroll : MonoBehaviour
{
	public float ScrollSpeed = 1;

    private Material MeshMaterial;
	private float OffsetX = 0;
	
    void Start()
    {
		MeshMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
		MeshMaterial.SetTextureOffset("_MainTex", new Vector2(OffsetX += ScrollSpeed * Time.deltaTime, 0));
    }
}
