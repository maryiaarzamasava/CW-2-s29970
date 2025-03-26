namespace Cwiczenia2.Classes;

public class ContainerShip(int maxSpeed, int maxContainerNum, int maxWeight)
{
    private static int _shipNextId = 0;

    public int Id { get; } = _shipNextId++;
    public List<Container> Containers { get; } = new();
    public int MaxSpeed { get; } = maxSpeed;
    public int MaxContainerNum { get; } = maxContainerNum;
    public int MaxWeight { get; } = maxWeight;

    public bool LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerNum)
        {
            Console.WriteLine($"Statek {Id} jest juz pelny\n");
            return false;
        }

        double totalWeight = 0;
        foreach (var c in Containers)
        {
            totalWeight += (c.OwnWeight + c.LoadWeight) / 1000;
        }

        double totalWeightWithNewContainer = totalWeight + (container.OwnWeight + container.LoadWeight) / 1000;

        if (totalWeight > MaxWeight || totalWeightWithNewContainer > MaxWeight)
        {
            Console.WriteLine($"Statek {Id} przekroczyl limit wagowy\n");
            return false;
        }

        Containers.Add(container);
        Console.WriteLine($"Statek {Id}: zaladowano nowy kontener {container.SerialNumber}\n");
        return true;
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var c in containers)
        {
            LoadContainer(c);
        }
    }

    public void RemoveContainer(Container container)
    {
        if (!Containers.Contains(container))
        {
            Console.WriteLine($"Nie znaleziono kontenera {container.SerialNumber} na Statku {Id}\n");
            return;
        }

        Containers.Remove(container);
        Console.WriteLine($"Statek {Id}: usunieto kontener {container.SerialNumber}\n");
    }

    public void ReplaceContainer(String serialNumber, Container newContainer)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].SerialNumber == serialNumber)
            {
                Containers[i] = newContainer;
                Console.WriteLine(
                    $"Statek {Id}: zastapiono kontener {serialNumber} nowym kontenerem {newContainer.SerialNumber}\n");
                return;
            }
        }

        Console.WriteLine($"Nie znaleziono kontenera {serialNumber} na Statku {Id}\n");
    }

    public void TransferContaier(Container container, ContainerShip transferContainerShip)
    {
        if (!Containers.Contains(container))
        {
            Console.WriteLine($"Nie znaleziono kontenera {container.SerialNumber} na Statku {Id}\n");
            return;
        }

        if (transferContainerShip.LoadContainer(container))
        {
            RemoveContainer(container);
            Console.WriteLine(
                $"Przeniesiono kontener {container.SerialNumber} ze Statku {Id} na Statek {transferContainerShip.Id}\n");
            return;
        }

        Console.WriteLine(
            $"Nie przeniesiono kontener {container.SerialNumber} ze Statku {Id} na Statek {transferContainerShip.Id}\n");
    }

    public void PrintShipLoadInfo()
    {
        if (Containers.Count == 0)
        {
            Console.WriteLine($"Statek {Id}: Lista kontenerow:\nBrak\n");
            return;
        }

        Console.WriteLine($"Statek {Id}: Lista kontenerow:\n");
        foreach (var c in Containers)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine();
    }

    public override string ToString()
    {
        return
            $"Statek {Id} (maksymalna predkosc={MaxSpeed}(w wezlach), Maksymalna liczba kontenerow, ktore moga byc przewozone={MaxContainerNum}," +
            $"Maksymalna waga wszystkich kontenerow jakie moga byc transportowane poprzez statek {MaxWeight}(w tonach))\n";
    }
}