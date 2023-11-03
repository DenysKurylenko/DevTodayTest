using DevTodayTest.DB;

internal partial class Program
{
    public class CabDataEqualityComparer : IEqualityComparer<CabData>
    {
        public bool Equals(CabData x, CabData y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.tpep_pickup_datetime == y.tpep_pickup_datetime
                && x.tpep_dropoff_datetime == y.tpep_dropoff_datetime
                && x.passenger_count == y.passenger_count;
        }

        public int GetHashCode(CabData obj)
        {
            if (ReferenceEquals(obj, null))
                return 0;

            int hashTpep_pickup_datetime = obj.tpep_pickup_datetime.GetHashCode();
            int hashTpep_dropoff_datetime = obj.tpep_dropoff_datetime.GetHashCode();
            int hashPassenger_count = obj.passenger_count.GetHashCode();

            return hashTpep_pickup_datetime * hashTpep_dropoff_datetime * hashPassenger_count;
        }
    }
}