using UnityEngine;
using System.Collections;

public class spectrum : MonoBehaviour {	
	public float radius = 10.0f;
	public int objsNum = 24;
	public GameObject prefab;
	public GameObject[] cubes;
	public float scale = 10.0f;
	public float height = 0.3f;

	private int freq=0;
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
		if(++freq % 4 !=0){
			
			return ;
		}
		freq =0;
		//float [] spectrum = new float[128];
		//AudioListener.GetOutputData(spectrum,1);
		float[] spectrum = AudioListener.GetOutputData(32,0);
		for(int i=0;i<objsNum;++i)
		{
			Vector3 preScale = cubes[i].transform.localScale;
			preScale.y = Mathf.Abs(spectrum[i]*scale)+height;
			cubes[i].transform.localScale = preScale;
			Vector3 prePostion = cubes[i].transform.position;
			prePostion.y = preScale.y/2;
			cubes[i].transform.position = prePostion;

			int red = (int)preScale.y;
			if(red>255) red =255;
			int g = Random.Range(0,255);
			int b = Random.Range(0,255);
			GameObject d = cubes[i];
			var render = d.GetComponent<Renderer>();
			render.material.color = new Color(red,g,b);
		}
	}
}
