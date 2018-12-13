using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRing : MonoBehaviour {
	private ParticleSystem particleSystem;
	public int particleNumber = 1000;       
	public float pingPong = 0.05f;
	public float size = 0.05f;             
	public float maxRadius = 1.4f;         
	public float minRadius = 1.2f;
	public float speed = 0.05f;             
	private float[] particleAngle;
	private float[] particleRadius; 

	private float time = 0;   
	private ParticleSystem.Particle[] particlesArray;
	//private ParticleSystem.MainModule settings;

	private Color[] changeColor = { 
		new Color(255, 246, 143),//Khaki1 
		new Color(0, 255, 255),//cyan
		new Color(106,90,205),//SlateBlue
		new Color(210, 180, 140), //Tan
		new Color(208,32,144),//VioletRed
		new Color(205, 16, 118),//DeepPink3 
		new Color(126,192,238),//SkyBlue2
		new Color(160,32,240),//purple
		new Color(106,90,205),//SlateBlue
		new Color(255,0,0)//new Color(18,34,34)//FireBrick
	};
	private float colorTimeOut = 0;
	private int color_index = 0;

	private Vector3 pos;

	void Start()
	{
		particleSystem = GetComponent<ParticleSystem>();
		particlesArray = new ParticleSystem.Particle[particleNumber];
		particleSystem.maxParticles = particleNumber;
		particleAngle = new float[particleNumber];
		particleRadius = new float[particleNumber];
		particleSystem.Emit(particleNumber);
		particleSystem.GetParticles(particlesArray);
		init();
		particleSystem.SetParticles(particlesArray, particlesArray.Length);  
		//settings = GetComponent<ParticleSystem> ().main;
	}
	void Update()
	{
		pos=GameObject.FindGameObjectWithTag("Player").transform.position+new Vector3(2.0f,-4.4f,0.0f);
		colorTimeOut += Time.deltaTime;
		for (int i = 0; i < particleNumber; i++)
		{
			time += Time.deltaTime;
			//settings.startColor = new ParticleSystem.MinMaxGradient (changeColor [color_index]);
			particlesArray[i].color = changeColor[color_index];
			particleRadius[i] += (Mathf.PingPong(time / minRadius / maxRadius, pingPong) - pingPong / 2.0f);
			if (i % 2 == 0)
			{
				particleAngle[i] += speed * (i % 10 + 1);
			}
			else
			{
				particleAngle[i] -= speed * (i % 10 + 1);
			}
			particleAngle[i] = (particleAngle[i] + 360) % 360;
			float rad = particleAngle[i] / 180 * Mathf.PI;

			particlesArray[i].position = pos+new Vector3(particleRadius[i] * Mathf.Cos(rad), particleRadius[i] * Mathf.Sin(rad), 0f);
		}
		particleSystem.SetParticles(particlesArray, particleNumber);
		for (int i = 0; i < particleNumber; i++)
		{
			float angle = Random.Range(0.0f, 360.0f);
			float rad = angle / 180 * Mathf.PI;
			float midRadius = (maxRadius + minRadius) / 2;
			float rate1 = Random.Range(1.0f, midRadius / minRadius);
			float rate2 = Random.Range(midRadius / maxRadius, 1.0f);
			float r = Random.Range(minRadius * rate1, maxRadius * rate2);
			particlesArray[i].size = size;
			particleAngle[i] = angle;
			particleRadius[i] = r;
			particlesArray[i].position = pos+new Vector3(r * Mathf.Cos(rad), r * Mathf.Sin(rad), 0.0f);
		}
		if (colorTimeOut >= 1.0f) {
			colorTimeOut = 0.0f;
			color_index = (color_index+1) % 10;
		}
	}
	void init()
	{
		for (int i = 0; i < particleNumber; i++)
		{
			float angle = Random.Range(0.0f, 360.0f);
			float rad = angle / 180 * Mathf.PI;
			float midRadius = (maxRadius + minRadius) / 2;
			float rate1 = Random.Range(1.0f, midRadius / minRadius);
			float rate2 = Random.Range(midRadius / maxRadius, 1.0f);
			float r = Random.Range(minRadius * rate1, maxRadius * rate2);
			particlesArray[i].size = size;
			particleAngle[i] = angle;
			particleRadius[i] = r;
			particlesArray[i].position =pos + new Vector3(r * Mathf.Cos(rad), r * Mathf.Sin(rad), 0.0f);
			pos=GameObject.FindGameObjectWithTag("Player").transform.position+new Vector3(2.0f,-4.4f,0.0f);
		}
	}

	public void OnParticleCollision(GameObject col){
		if (col.tag == "bottle") {
			Debug.Log ("bottle");
		}
	}
}