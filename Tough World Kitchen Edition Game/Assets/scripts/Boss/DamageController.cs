using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public GameObject Lemon;
    public GameObject Boss;
    public bool IsAttacking;

    private Vector3 velocity = Vector3.zero;
    private float dampTime = 0.05f;
    public bool _IsLemonAttacking;
    public bool _IsBossAttacking;
    private bool _lemonReturn;
    private bool _bossReturn;

    private Vector3 _LemonDefaultPosition;
    private Vector3 _BossDefaultPosition;
    private Vector3 _BossOffset;
    private Vector3 _LemonOffset;

    public void AttackBoss()
    {
        _IsLemonAttacking = true;
        IsAttacking = true;
    }

    public void AttackLemon()
    {
        _IsBossAttacking = true;
        IsAttacking = true;
    }

    private void Update()
    {
        if (_IsLemonAttacking && Vector3.Distance(Lemon.transform.position, _BossOffset) < 0.005)
        {
            _IsLemonAttacking = false;
            _lemonReturn = true;
        }
        else if (_lemonReturn && Vector3.Distance(Lemon.transform.position, _LemonDefaultPosition) < 0.005)
        {
            _lemonReturn = false;
            IsAttacking = false;
        }

        if (_IsBossAttacking && Vector3.Distance(Boss.transform.position, _LemonOffset) < 0.005)
        {
            _IsBossAttacking = false;
            _bossReturn = true;
        }
        else if (_bossReturn && Vector3.Distance(Boss.transform.position, _BossDefaultPosition) < 0.005)
        {
            _bossReturn = false;
            IsAttacking = false;
        }

        if (_IsLemonAttacking)
        {
            Lemon.transform.position = Vector3.SmoothDamp(Lemon.transform.position, _BossOffset, ref velocity, dampTime);
        }
        else if (_lemonReturn)
        {
            Lemon.transform.position = Vector3.SmoothDamp(Lemon.transform.position, _LemonDefaultPosition, ref velocity, dampTime);
        }

        if (_IsBossAttacking)
        {
            Boss.transform.position = Vector3.SmoothDamp(Boss.transform.position, _LemonOffset, ref velocity, dampTime);
        }
        else if (_bossReturn)
        {
            Boss.transform.position = Vector3.SmoothDamp(Boss.transform.position, _BossDefaultPosition, ref velocity, dampTime);
        }

    }

    private void Start()
    {
        _LemonDefaultPosition = Lemon.transform.position;
        _BossDefaultPosition = Boss.transform.position;

        _BossOffset = new Vector3(Boss.transform.position.x - 2, Boss.transform.position.y, Boss.transform.position.z);
        _LemonOffset = new Vector3(Lemon.transform.position.x + 2, Lemon.transform.position.y, Boss.transform.position.z);
    }
}
