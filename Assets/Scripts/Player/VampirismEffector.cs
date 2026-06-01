using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(VampirismSwitch))]
public class VampirismEffector : MonoBehaviour
{
    private VampirismSwitch _vampirismSwitch;
    private SpriteRenderer _spriteRenderer;
    private LineRenderer _lineRenderer;
    private Enemy _target;
    private float _diameter;
    private float _lineWidth = 0.1f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _vampirismSwitch = GetComponent<VampirismSwitch>();

        _spriteRenderer.enabled = false;
    }

    private void Start()
    {
        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;

        if (_vampirismSwitch != null)
        {
            _diameter = _vampirismSwitch.VampireAttackRadius;
        }

        SetDiameter(_diameter);
    }

    private void Update()
    {
        if (_spriteRenderer.enabled && _target != null)
        {
            _lineRenderer.SetPosition(0, gameObject.transform.position);
            _lineRenderer.SetPosition(1, _target.transform.position);
        }
    }

    private void OnEnable()
    {
        VampirismSwitch.AttackStateChanged += ToggledSprite;
        VampirismSwitch.TargetSelected += TargetChoose;
        VampirismSwitch.TargetLose += ToggledleLine;
    }

    private void OnDisable()
    {
        VampirismSwitch.AttackStateChanged -= ToggledSprite;
        VampirismSwitch.TargetSelected -= TargetChoose;
        VampirismSwitch.TargetLose -= ToggledleLine;
    }

    private void SetDiameter(float diameter)
    {
        float originalWidth = _spriteRenderer.size.x;
        float scale = diameter / originalWidth;
        transform.localScale = Vector3.one * scale;
    }

    private void ToggledSprite(bool isVisible)
    {
        if (isVisible)
            _spriteRenderer.enabled = true;
        else
            _spriteRenderer.enabled = false;
    }

    private void TargetChoose(Enemy enemy)
    {
        _target = enemy;
        _lineRenderer.enabled = true;
    }
    private void ToggledleLine()
    {
        _lineRenderer.enabled = false;
    }
}
