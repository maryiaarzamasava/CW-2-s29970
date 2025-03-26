using Cwiczenia2.Exception;

namespace Cwiczenia2.Classes;

public class RefrigeratedContainer(
    double loadWeight,
    int height,
    double ownWeight,
    int depth,
    int maxLoadCapacity,
    string productType,
    int temperature) : Container(loadWeight, height, ownWeight, depth, maxLoadCapacity)
{
    private static int _containerCNextId = 0;
    protected override string ContainerType { get; } = "C";
    protected override int Id { get; } = _containerCNextId++;
    public string ProductType { get; private set; } = productType;
    public int Temperature { get; private set; } = temperature;

    public void LoadContainer(double masa, string productType, int productTemperature)
    {
        if (ProductType != productType)
        {
            throw new InvalidOperationException($"Kontener {SerialNumber} moze przechowywac wylacznie {ProductType}");
        }

        if (Temperature < productTemperature)
        {
            throw new InvalidOperationException(
                $"Kontener {SerialNumber}: temperatura kontenera nie może być niższa niż wymagana przez dany rodzaj produktu");
        }

        if (LoadWeight + masa > MaxLoadCapacity)
        {
            throw new OverfillException("Masa ładunku jest większa niż pojemność danego kontenera");
        }

        LoadWeight += masa;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, rodzaj produktu, ktory moze byc przechowywany w danym kontenerze: {ProductType}, " +
               $"temperatura utrzymywana w kontenerze: {Temperature})";
    }
}