using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCorsoBlazor.Core.MyMap;

public class ParametriMappa
{
     public double Latitudine { get; set; }
     public double Longitudine { get; set; }
     public int Zoom { get; set; }
     public string Description { get; set; } = string.Empty;

}
