using Cwiczenia2.Exception;
using Cwiczenia2.Interfaces;

namespace Cwiczenia2.Classes;

public abstract class Container : IContainer
{
    protected abstract string ContainerType { get; }

    protected abstract int Id { get; }
    public double LoadWeight { get; protected set; }
    public int Height { get; protected set; }
    public double OwnWeight { get; protected set; }
    public int Depth { get; protected set; }
    public string SerialNumber { get; protected set; }
    public int MaxLoadCapacity { get; protected set; }

    public Container(double loadWeight, int height, double ownWeight, int depth, int maxLoadCapacity)
    {
        LoadWeight = loadWeight;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        SerialNumber = $"KON-{ContainerType}-{Id}";
        MaxLoadCapacity = maxLoadCapacity;
    }

    public virtual void EmptyLoad()
    {
        LoadWeight = 0;
    }

    public virtual void LoadContainer(double masa)
    {
        if (LoadWeight + masa > MaxLoadCapacity)
        {
            throw new OverfillException("Masa ładunku jest większa niż pojemność danego kontenera");
        }

        LoadWeight += masa;
    }

    public override string ToString()
    {
        return $"Kontener {SerialNumber} (masa ladunku={LoadWeight}(kg), wysokosc={Height}(cm)," +
               $"wlasna waga={OwnWeight}(kg), glebokosc={Depth}(cm), Maksymalna ladownosc={MaxLoadCapacity}(kg)";
    }
}