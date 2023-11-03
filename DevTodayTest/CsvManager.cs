using DevTodayTest.DB;
using Sylvan.Data;
using Sylvan.Data.Csv;

namespace DevTodayTest
{
    internal partial class CsvManager
    {
        public IEnumerable<CabData> ParseFile(string filename)
        {
            var recordList = new List<CabData>();

            using var csv = CsvDataReader.Create(filename, new CsvDataReaderOptions
            {
                Schema = CsvSchema.Nullable
            });
            var tpep_pickup_datetimeIndex = csv.GetOrdinal(nameof(CabData.tpep_pickup_datetime));
            var tpep_dropoff_datetimeIndex = csv.GetOrdinal(nameof(CabData.tpep_dropoff_datetime));
            var passenger_countIndex = csv.GetOrdinal(nameof(CabData.passenger_count));
            var trip_distanceIndex = csv.GetOrdinal(nameof(CabData.trip_distance));
            var store_and_fwd_flagIndex = csv.GetOrdinal(nameof(CabData.store_and_fwd_flag));
            var PULocationIDIndex = csv.GetOrdinal(nameof(CabData.PULocationID));
            var DOLocationIDIndex = csv.GetOrdinal(nameof(CabData.DOLocationID));
            var fare_amountIndex = csv.GetOrdinal(nameof(CabData.fare_amount));
            var tip_amountIndex = csv.GetOrdinal(nameof(CabData.tip_amount));

            while (csv.Read())
            {
                try
                {
                    var result = new CabData
                    {
                        tpep_pickup_datetime = csv.GetDateTime(tpep_pickup_datetimeIndex),
                        tpep_dropoff_datetime = csv.GetDateTime(tpep_dropoff_datetimeIndex),
                        passenger_count = csv.GetInt16(passenger_countIndex),
                        trip_distance = csv.GetFloat(trip_distanceIndex),
                        store_and_fwd_flag = csv.GetString(store_and_fwd_flagIndex),
                        PULocationID = csv.GetInt16(PULocationIDIndex),
                        DOLocationID = csv.GetInt16(DOLocationIDIndex),
                        fare_amount = csv.GetFloat(fare_amountIndex),
                        tip_amount = csv.GetFloat(tip_amountIndex)
                    };
                    recordList.Add(result);
                }
                catch (FormatException ex)
                {
                    //log ex
                }
                catch(Exception ex) {
                    //log ex
                }
            }
            return recordList;
        }
        public void WriteFile(string filename, IEnumerable<CabData> records)
        {
            var recordReader = records.AsDataReader();
            using var csvWriter = CsvDataWriter.Create(filename);
            csvWriter.Write(recordReader);
        }
    }
}
