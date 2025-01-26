using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spr.Core;
internal class TestingContext
{
    public string DBName { get; set; }
    public int SampleCount { get; set; }
    public List<float> InsertDurations { get; set; } = new List<float>();
    public List<float> ReadDurations { get; set; } = new List<float>();
    public List<float> FilterReadDurations { get; set; } = new List<float>();
    public List<float> IndexedReadDurations { get; set; } = new List<float>();
    public List<float> IndexedFilterReadDurations { get; set; } = new List<float>();
    public List<float> UpdateDurations { get; set; } = new List<float>();
    public List<float> DeleteDurations { get; set; } = new List<float>();

    public override string ToString()
    {
        string result = $"{DBName} - {SampleCount} samples.\n";
        result += $"Avarage insert duration: {InsertDurations.Average()} ms.\n";
        result += $"Avarage read all duration: {ReadDurations.Average()} ms.\n";
        result += $"Avarage read filtered duration: {FilterReadDurations.Average()} ms.\n";
        result += $"Avarage indexed read all duration: {IndexedReadDurations.Average()} ms.\n";
        result += $"Avarage indexed read filtered duration: {IndexedFilterReadDurations.Average()} ms.\n";
        result += $"Avarage update duration: {UpdateDurations.Average()} ms.\n";
        result += $"Avarage delete duration: {DeleteDurations.Average()} ms.\n";
        return result;
    }
}
