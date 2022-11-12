using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObj());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instant.IsLose) return;
        MoveTube();
    }

    public void SetPositon()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(-0.5f, 0.5f));
    }

    public void MoveTube()
    {
        transform.position += new Vector3(-1, 0) * Time.deltaTime * _speed;
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(this.gameObject);
    }
}
