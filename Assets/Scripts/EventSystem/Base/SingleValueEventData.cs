
namespace Marsheleene.Events
{
    [System.Serializable]
    public abstract class SingleValueEventData<T> : GameEventData
    {
        public abstract T Value { get; set; }

        public SingleValueEventData()
        {
            Value = default;
        }

        public SingleValueEventData(T value)
        {
            Value = value;
        }
    }
}