using System.Collections;
using System.Collections.Generic;
using Duskland.Enums;

namespace Duskland.Character
{
    public class Body
    {
        private readonly Dictionary<BodyLocation, BodyPart> bodyParts = new Dictionary<BodyLocation, BodyPart>();

        public IEnumerator<KeyValuePair<BodyLocation, BodyPart>> GetEnumerator()
        {
            return bodyParts.GetEnumerator();
        }

        public int Count => bodyParts.Count;

        public bool TryGetBodyPart(BodyLocation key, out BodyPart value)
        {
            return bodyParts.TryGetValue(key, out value);
        }

        public BodyPart this[BodyLocation key] => bodyParts[key];

        public void ApplyBodyPart(BodyPart bodyPart)
        {
            if (TryGetBodyPart(bodyPart.bodyLocation, out var currentBodyPart))
                currentBodyPart.Hide();

            bodyParts[bodyPart.bodyLocation] = bodyPart;
            bodyPart.Show();
        }

        public ICollection<BodyLocation> BodyLocations => bodyParts.Keys;
        public ICollection<BodyPart> BodyParts => bodyParts.Values;
    }
}