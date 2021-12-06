using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static int projectileCount;

    [SerializeField] float projectileLifeTime = 1.0f;

    Rigidbody rigidbody;
    float power = 5000f;
    float radius = 5000f;
    private void Awake()
    {
        projectileCount += 1;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (MenuManager.Instance.toggleBigProjectile.isOn)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (MenuManager.Instance.toggleRedProjectile.isOn)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        if (MenuManager.Instance.toggleExplodeProjectile.isOn)
        {
            StartCoroutine(ExplodeInSeconds(1));
        }

        Destroy(this.gameObject, projectileLifeTime);
    }

    IEnumerator ExplodeInSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        Explode();
        yield break;
    }

    void Explode()
    {
        
        Destroy(this.gameObject);
    }
}
