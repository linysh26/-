using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {
	public ParticleSystem particleSystem;
	public ParticleSystem head;
	public ParticleSystem hand1;
	public ParticleSystem hand2;
	private ParticleSystem.Particle[] particlesArray;
	private ParticleSystem.Particle[] particlesArrayH0;
	private ParticleSystem.Particle[] particlesArrayH1;
	private ParticleSystem.Particle[] particlesArrayH2;
	private Vector3[] particlePosition;

	public int seaResolution = 100;
	public float noiseScale = 0.1f;
	public float WaveScale = 3.0f;
	public float scale = 0.001f;
	public float spacing = 0.25f;
	//perlin noise's parameters
	public float perlinNoiseAnimX;
	public float perlinNoiseAnimY;

	void Start() {
		particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
		particlePosition = new Vector3[seaResolution * seaResolution];
		particleSystem.maxParticles = seaResolution * seaResolution;
		particleSystem.Emit(seaResolution * seaResolution);
		particleSystem.GetParticles(particlesArray);
		perlinNoiseAnimX = 0.1f;
		perlinNoiseAnimY = 0.1f;
		for (int i = 0; i < seaResolution; i++) {
			for (int j = 0; j < seaResolution; j++) {
				float x = seaResolution/3 - i + 10;
				float z = seaResolution/3 - j + 10;
				particlesArray [i * seaResolution + j].position = new Vector3 (x, 10, z);
				particlePosition [i * seaResolution + j] = new Vector3 (x, 10, z);
			}
		}

		particleSystem.SetParticles(particlesArray, particlesArray.Length);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < seaResolution; i++) {
			for (int j = 0; j < seaResolution; j++) {
				float wave = Mathf.PerlinNoise (i * noiseScale + perlinNoiseAnimX, j * noiseScale + perlinNoiseAnimY) * WaveScale;
				particlesArray [i * seaResolution + j].position = new Vector3 (particlePosition[i * seaResolution + j].x * spacing + wave, wave, particlePosition[i * seaResolution + j].z * spacing + wave);
			}
		}
		perlinNoiseAnimX += 0.004f;
		perlinNoiseAnimY += 0.004f;

		particleSystem.SetParticles(particlesArray, particlesArray.Length);
	}
}
