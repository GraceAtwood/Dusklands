using System.Collections;
using System.Collections.Generic;
using Duskland.Enums;

namespace Duskland.Character
{
    public class Body : IDictionary<BodyLocation, BodyPart>
    {
        private readonly Dictionary<BodyLocation, BodyPart> bodyParts = new Dictionary<BodyLocation, BodyPart>();

        public IEnumerator<KeyValuePair<BodyLocation, BodyPart>> GetEnumerator()
        {
            return bodyParts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<BodyLocation, BodyPart> item)
        {
            bodyParts.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            bodyParts.Clear();
        }

        public bool Contains(KeyValuePair<BodyLocation, BodyPart> item)
        {
            return bodyParts.TryGetValue(item.Key, out var bodyPart) && bodyPart.Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<BodyLocation, BodyPart>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<BodyLocation, BodyPart> item)
        {
            if (!Contains(item))
                return false;

            return bodyParts.Remove(item.Key);
        }

        public int Count => bodyParts.Count;
        public bool IsReadOnly => false;

        public void Add(BodyLocation key, BodyPart value)
        {
            bodyParts.Add(key, value);
        }

        public bool ContainsKey(BodyLocation key)
        {
            return bodyParts.ContainsKey(key);
        }

        public bool Remove(BodyLocation key)
        {
            return bodyParts.Remove(key);
        }

        public bool TryGetValue(BodyLocation key, out BodyPart value)
        {
            return bodyParts.TryGetValue(key, out value);
        }

        public BodyPart this[BodyLocation key]
        {
            get => bodyParts[key];
            set => bodyParts[key] = value;
        }

        public ICollection<BodyLocation> Keys => bodyParts.Keys;
        public ICollection<BodyPart> Values => bodyParts.Values;
    }
}