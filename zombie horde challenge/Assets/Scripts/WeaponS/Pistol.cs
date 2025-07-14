using UnityEngine;

public class Pistol : WeaponBase // overrided weapon base for the pistol weapon to move according to mouse and fire
{
    Vector3 scale = Vector3.one;
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private Transform m_SpawnPos;

    private void Awake()
    {
        scale = transform.localScale;    
    }

    public override void Fire()
    {
       GameObject bullet = Instantiate(m_Bullet, m_SpawnPos.position, transform.rotation);
       bullet.GetComponent<BulletHandler>().m_Damage = m_WeaponData.damage;
    }

    public override void StopFire()
    {
        //stop pistol fire
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = mousePos - transform.position;
        transform.up = direction.normalized;

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        }
        else
        {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
    }
}
