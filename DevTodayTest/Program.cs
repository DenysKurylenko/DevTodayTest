using DevTodayTest;
using DevTodayTest.DB;
using System;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var context = new AppDbContext();
        var csvManager = new CsvManager();
        var cabRecords = csvManager.ParseFile(@"D:\sample-cab-data.csv");
        foreach (var cabRecord in cabRecords)
        {
            switch(cabRecord.store_and_fwd_flag.ToUpper()) {
                case "Y":
                    cabRecord.store_and_fwd_flag = "Yes";
                    break;
                    case "N":
                    cabRecord.store_and_fwd_flag = "No";
                    break;
                default:
                    //Log 
                    cabRecord.store_and_fwd_flag = "No";
                    break;
            }
        }
        var cabDataComparer = new CabDataEqualityComparer();
        var groupdedrecords = cabRecords.GroupBy(x => x, cabDataComparer);
        var distinctRecords = groupdedrecords.Select(x => x.First());
        var duplicatedRecords = groupdedrecords.Where(x => x.Count() > 1)
            .SelectMany(x => x.Skip(1));
        csvManager.WriteFile(@"D:\duplicates.csv", duplicatedRecords);
        var rowCount = distinctRecords.Count();
        context.CabData.AddRange(distinctRecords);
        context.SaveChanges();
    }
}