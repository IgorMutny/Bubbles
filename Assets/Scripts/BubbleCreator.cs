using UnityEngine;

public class BubbleCreator : MonoBehaviour
{
    [SerializeField] private GameObject _bubbleSample;

    private GameConfig _gameConfig;

    public void Initialize(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;

        EventBus.Subscribe<BubbleCreating>(OnBubbleCreating);
        EventBus.Subscribe<BubbleMerging>(OnBubbleMerging);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe<BubbleCreating>(OnBubbleCreating);
        EventBus.Unsubscribe<BubbleMerging>(OnBubbleMerging);
    }

    private void OnBubbleCreating(BubbleCreating e)
    {
        CreateBubble(e.Position, e.Size, false);
    }

    private void OnBubbleMerging(BubbleMerging e)
    {
        CreateBubble(e.Position, e.Size, true);

        EventBus.Invoke(new BubbleMerged(e.Bubble1, e.Bubble2));

        Destroy(e.Bubble1.gameObject);
        Destroy(e.Bubble2.gameObject);
    }

    private void CreateBubble(Vector2 position, int size, bool fromMerging)
    {
        Bubble newBubble = Instantiate(_bubbleSample, position, Quaternion.identity).GetComponent<Bubble>();
        newBubble.Initialize(size, _gameConfig, fromMerging);
        EventBus.Invoke(new BubbleCreated(newBubble));
    }
}
