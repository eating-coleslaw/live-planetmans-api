namespace LivePlanetmans.App.CensusStream.Models
{
    public class ContinentLockPayload : PayloadBase, IEquatablePayload<ContinentLockPayload>
    {
		public int MetagameEventId { get; set; }
        public int TriggeringFaction { get; set; }
        public int PreviousFaction { get; set; }
		
        public float VsPopulation { get; set; }
		public float NcPopulation { get; set; }
		public float TrPopulation { get; set; }

        public int EventType { get; set; } // TODO: keep this? is type correct?


        #region IEquitable
        public override bool Equals(object obj)
        {
            return this.Equals(obj as ContinentLockPayload);
        }

        public bool Equals(ContinentLockPayload p)
        {
            if (ReferenceEquals(p, null))
            {
                return false;
            }

            if (ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.GetType() != p.GetType())
            {
                return false;
            }

            return (p.Timestamp == Timestamp
                    && p.WorldId == WorldId
                    && p.ZoneId == ZoneId);
        }

        public static bool operator ==(ContinentLockPayload lhs, ContinentLockPayload rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                if (ReferenceEquals(rhs, null))
                {
                    return true;
                }

                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ContinentLockPayload lhs, ContinentLockPayload rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            var id = $"t{Timestamp:yyyyMMddTHHmmss}w{WorldId}z{ZoneId}";
            return id.GetHashCode();
        }
        #endregion IEquitable
    }
}
