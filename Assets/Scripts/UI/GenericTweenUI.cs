using DG.Tweening;
using UnityEngine;

namespace DogukanKarabiyik.RunnerGame.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class GenericTweenUI : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _sequence = DOTween.Sequence();
        }

        [SerializeField] private bool isIndependentFromTimeScale = false;
        [SerializeField] private float animationTime = 1;
        [SerializeField] private Ease animationEase = Ease.Linear;
        [SerializeField] private bool canLoop = false;
        
        [SerializeField]  private int loopCount = -1;
        [SerializeField]  private LoopType loopType = LoopType.Yoyo;
        [SerializeField] private bool posChange = true;
        [SerializeField]  private Vector2 startPos = Vector3.zero;
        [SerializeField] private Vector2 endPos = Vector3.zero;
       
        [SerializeField] private bool scaleChange = false;
        [SerializeField]  private Vector3 startScale = Vector3.one;
        [SerializeField]  private Vector3 endScale = Vector3.one;
        [SerializeField] private bool rotChange = false;
        [SerializeField]  private Vector3 startRot = Vector3.zero;
        [SerializeField]  private Vector3 endRot = Vector3.zero;


        private void Start()
        {
            if (isIndependentFromTimeScale)
                _sequence.SetUpdate(true);

            if (posChange)
                _sequence.Join(_rectTransform.DOAnchorPos(endPos, animationTime).From(startPos).SetEase(animationEase));

            if (scaleChange)
                _sequence.Join(_rectTransform.DOScale(endScale, animationTime).From(startScale).SetEase(animationEase));

            if (rotChange)
                _sequence.Join(_rectTransform.DORotate(startRot, animationTime).From(endRot).SetEase(animationEase));

            if (canLoop)
                _sequence.SetLoops(loopCount, loopType);
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}
