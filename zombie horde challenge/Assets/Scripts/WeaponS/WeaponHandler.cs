using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Transform m_WeaponHolder;
    [SerializeField] private WeaponSO[] m_WeaponTypes;
    private WeaponBase m_CurrentWeapon;

    public void EquipWeapon(WeaponSO weaponSO)
    {
        if(m_CurrentWeapon != null)
        {
            Destroy(m_CurrentWeapon.gameObject);
        }

        GameObject weapon = Instantiate(weaponSO.weaponPrefab, m_WeaponHolder);
        m_CurrentWeapon = weapon.GetComponent<WeaponBase>();
        m_CurrentWeapon.Initialize(weaponSO);
    }

    public void Fire()
    {
        m_CurrentWeapon?.Fire();
    }

    public void StopFire()
    {
        m_CurrentWeapon?.StopFire();
    }

    private void Awake()
    {
        EquipWeapon(m_WeaponTypes[0]);
    }
}
