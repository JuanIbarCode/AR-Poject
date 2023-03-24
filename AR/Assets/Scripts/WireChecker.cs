using DG.Tweening;
using UnityEngine;

public class WireChecker : MonoBehaviour
{
    public Colors targetColor;

    [Space]
    public Transform targetPos;

    [Space] 
    public GameObject pinNumber;
    public AudioClip clip;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Wire")) return;

        var wire = other.GetComponent<Wire>();

        if (wire.targetColor != targetColor) return;

        wire.canDrag = false;

        var endPos = wire.transform.parent.InverseTransformPoint(targetPos.position);
        
        var line = wire.GetComponentInParent<LineRenderer>();
        var tempPos = line.GetPosition(0);
        
        _source.PlayOneShot(clip);
        DOTween.To(() => tempPos, x => tempPos = x, endPos, clip.length - 0.45f)
            .OnUpdate(() =>
            {
                pinNumber.SetActive(true);
                line.SetPosition(0, tempPos);
            });
    }
}
