using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected WeaponSO m_WeaponData;

    public virtual void Initialize(WeaponSO data)
    {
        m_WeaponData = data;
    }

    public abstract void Fire();
    public abstract void StopFire();
}
