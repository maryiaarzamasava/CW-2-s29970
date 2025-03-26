using Cwiczenia2.Exception;
using Cwiczenia2.Interfaces;

namespace Cwiczenia2.Classes;

public class LiquidContainer(
    double loadWeight,
    int height,
    double ownWeight,
    int depth,
    int maxLoadCapacity,
    bool isHazardous)
    : Container(loadWeight, height, ownWeight, depth, maxLoadCapacity), IHazardNotifier
{
    private static int _containerLNextId = 0;
    protected override string ContainerType { get; } = "L";
    protected override int Id { get; } = _containerLNextId++;
    public bool IsHazardous { get; set; } = isHazardous;

    public override void LoadContainer(double masa)
    {
        double allowedCapacity = IsHazardous ? maxLoadCapacity * 0.5 : maxLoadCapacity * 0.9;
        if (LoadWeight + masa > allowedCapacity)
        {
            Notify("Próba wykonania niebezpiecznej operacji");
            throw new OverfillException(
                "Masa ładunku jest większa niż maksymalana dozwolona ładowność danego kontenera");
        }

        base.LoadContainer(masa);
    }


    public virtual void Notify(string message)
    {
        Console.WriteLine($"Kontener {SerialNumber}: " + message);
    }

    public override string ToString()
    {
        if (IsHazardous)
        {
            return $"{base.ToString()}, przewozi ładunek niebezpieczny)";
        }

        return $"{base.ToString()}, przewozi ładunek zwykly)";
    }
}