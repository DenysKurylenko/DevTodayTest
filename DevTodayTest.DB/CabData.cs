using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevTodayTest.DB
{
    public class CabData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime tpep_pickup_datetime { get; set; }
        [Required]
        public DateTime tpep_dropoff_datetime { get; set; }
        [Required]
        public int passenger_count { get; set; }
        [Required]
        public float trip_distance { get; set; }
        [Required]
        public string store_and_fwd_flag { get; set; }
        [Required]
        public int PULocationID { get; set; }
        [Required]
        public int DOLocationID { get; set; }
        [Required]
        public float fare_amount { get; set; }
        [Required]
        public float tip_amount { get; set; }

    }
}
