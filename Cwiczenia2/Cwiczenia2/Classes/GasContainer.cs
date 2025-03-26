using Cwiczenia2.Interfaces;

namespace Cwiczenia2.Classes;

public class GasContainer(double loadWeight, int height, double ownWeight, int depth, int maxLoadCapacity, int pressure)
    : Container(loadWeight, height, ownWeight, depth, maxLoadCapacity), IHazardNotifier
{
    private static int _containerGNextId = 0;
    protected override string ContainerType { get; } = "G";
    protected override int Id { get; } = _containerGNextId++;
    public int Pressure { get; private set; }

    public override void EmptyLoad()
    {
        LoadWeight *= 0.05;
    }

    public override void LoadContainer(double masa)
    {
        if (LoadWeight > MaxLoadCapacity)
        {
            Notify("Niebezpiecznego zdarzenia");
        }

        base.LoadContainer(masa);
    }

    public virtual void Notify(string message)
    {
        Console.WriteLine($"Kontener {SerialNumber}: " + message);
    }

    public override string ToString()
    {
        return $"{base.ToString()}, cisninie={Pressure}(w atmosferach))";
    }
}