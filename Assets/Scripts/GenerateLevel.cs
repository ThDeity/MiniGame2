using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _platforms;
    [SerializeField] protected float _offset;
    [SerializeField] protected int _count;

    protected void OnTriggerEnter(Collider other)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + _offset * _count);
        GameObject platform = Instantiate(_platforms[Random.Range(0, _platforms.Count - 1)],pos, Quaternion.identity);

        Destroy(transform.parent.gameObject);
    }
}