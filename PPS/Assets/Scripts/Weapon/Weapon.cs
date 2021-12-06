using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] int projectileCount;
    [SerializeField] int spreadAngle;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject projectile;
    [SerializeField] float shootForce = 5f;

    public GameObject crosshair;

    public Slider slider;
    public void Shoot()
    {
        projectileCount = Mathf.RoundToInt(slider.value);
        for (int i = 0; i < projectileCount; i++)
        {
            Quaternion spread = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0f));
            GameObject g = Instantiate(projectile, muzzle.position, spread);
            Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
            Vector3 direction = (ray.GetPoint(100000f) - g.transform.position).normalized;
            g.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}
