using System.Collections;
using System.Collections.Generic;
using Duskland.Enums;

namespace Duskland.Character
{
    public class Body : IDictionary<BodyLocation, BodyPart>
    {
        private Dictionary<BodyLocation, BodyPart> _bodyParts = new Dictionary<BodyLocation, BodyPart>();
        
        public IEnumerator<KeyValuePair<BodyLocation, BodyPart>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<BodyLocation, BodyPart> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<BodyLocation, BodyPart> item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<BodyLocation, BodyPart>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<BodyLocation, BodyPart> item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public void Add(BodyLocation key, BodyPart value)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(BodyLocation key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(BodyLocation key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(BodyLocation key, out BodyPart value)
        {
            throw new System.NotImplementedException();
        }

        public BodyPart this[BodyLocation key]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public ICollection<BodyLocation> Keys { get; }
        public ICollection<BodyPart> Values { get; }
    }
}