using UnityEngine;
using System.Collections;

public class spectrum : MonoBehaviour {	
	public float radius = 10.0f;
	public int objsNum = 24;
	public GameObject prefab;
	public GameObject[] cubes;
	public float scale = 10.0f;
	public float height = 0.3f;

	// Use this for initialization
	void Start () {
		float angle = 2* Mathf.PI/objsNum;
		cubes = new GameObject[objsNum];
		for(int i =0;i<objsNum; ++i)
		{
			Vector3 pos =new Vector3(Mathf.Cos(i*angle),0, Mathf.Sin(i*angle))*radius;
			cubes[i]=(GameObject)Instantiate(prefab,pos,Quaternion.identity);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = AudioListener.GetSpectrumData(128,0,FFTWindow.Hamming);
		for(int i=0;i<objsNum;++i)
		{
			Vector3 prePos = cubes[i].transform.localScale;
			prePos.y = Mathf.Abs(spectrum[i]*scale) + height;
			cubes[i].transform.localScale = prePos;
		}
	}
}
