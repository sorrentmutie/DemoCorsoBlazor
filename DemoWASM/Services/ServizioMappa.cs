using DemoCorsoBlazor.Core.MyMap;

namespace DemoWASM.Services;

public class ServizioMappa : IMyMap
{
    public ParametriMappa EstraiParametriMappa()
    {
        return new ParametriMappa
        {
            Latitudine = 45.464664,
            Longitudine = 9.188540,
            Zoom = 10
        };
    }
}

