using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texscroll : MonoBehaviour {
	public Vector2 Spd;
	private Vector2 _offset;
	private Renderer _renderer;
	// Use this for initialization
	void Start () {
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		_offset += Spd * Time.deltaTime;
		_renderer.material.SetTextureOffset("_MainTex",_offset);
		
	}
}
