using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	
    public List<GameObject> Obsjects = new List<GameObject>();
    public List<Rigidbody> ORbs = new List<Rigidbody>();
    public List<GameObject> InsObs = new List<GameObject>();

    public List<float> RndNum = new List<float>();
    public List<float> RndForce = new List<float>();

    public GameObject _expl;

    GameObject _Gob;
    Rigidbody _Grb;


    public float _minRangeForce=0.2f;
    public float _maxRangeForce=0.4f;
    public float _minRangeDegree=30;
    public float _maxRangeDegree=80;

    public int _maxExObject = 60;
    public int _maxCount = 6;
    public float _timePerDis=0.01f;
    public int _timePerDisObject = 10;

    
	// Use this for initialization
	void Start () {
        //this.transform.parent = GameObject.Find(prObjName).transform;
        ORbs = Obsjects.Select(a => a.GetComponent<Rigidbody>()).ToList();
        for (int i = 0; i < _maxExObject*_maxCount; i++)
        {
            RndNum.Add(Random.Range(_minRangeDegree, _maxRangeDegree));
            RndForce.Add(Random.Range(_minRangeForce, _maxRangeForce));
        }
        Charge();
	}
	
    void Charge()
    {
        
        int a = Obsjects.Count();
        int b = RndNum.Count();
        
        for (int i = 1; i < RndNum.Count(); i++)
        {
            GameObject c = GameObject.Instantiate(Obsjects[i % a], Vector3.zero, Quaternion.identity) as GameObject;
            c.SetActive(false);
            InsObs.Add(c);
            ORbs.Add(c.GetComponent<Rigidbody>());
        }
    }

    public void ExFire(float delay)
    {
        Charge();
		StartCoroutine("Explosion_Co", delay);
    }
    IEnumerator Explosion_Co(float zz)
    {
		yield return new WaitForSeconds(zz);
        GameObject _exp = Instantiate(_expl, Vector3.zero, Quaternion.identity, this.transform);
        _exp.SetActive(true);
        _exp.transform.position = this.transform.position;
        _exp.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        int _objSum = 0;
        for (int i = 0; i < _maxCount; i++)
        {
            int d = _maxExObject;
            for (int j = 0; j < d; j++)
            {
                GameObject a = InsObs[_objSum];
                a.SetActive(true);
                a.transform.position = this.transform.position;
                a.GetComponent<Rigidbody>().velocity=new Vector3(0, RndNum[_objSum], 0).normalized*RndForce[_objSum];
                //Destroy(a, 1.0f);
                _objSum++;
                    yield return new WaitForSeconds(0.002f);
            }
            yield return new WaitForSeconds(_timePerDis);
            if (d < 1)
            {
                d =- _timePerDisObject;
            }
            
        }
        InsObs.Clear();
        yield return null;
    }
}
