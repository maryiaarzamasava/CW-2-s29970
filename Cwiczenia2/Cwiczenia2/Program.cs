using Cwiczenia2.Classes;

GasContainer gContainer = new GasContainer(100, 10, 50, 5, 200, 10);
LiquidContainer lContainer = new LiquidContainer(80, 8, 40, 4, 150, true);
RefrigeratedContainer rContainer = new RefrigeratedContainer(70, 9, 45, 5, 180, "Meat", -10);

Console.WriteLine(gContainer);
Console.WriteLine(lContainer);
Console.WriteLine(rContainer);

gContainer.LoadContainer(50);
// lContainer.LoadContainer(60);
rContainer.LoadContainer(70, "Meat", -15);
// rContainer.LoadContainer(20, "Fish", 2);
// rContainer.LoadContainer(20, "Meat", -9);


ContainerShip ship1 = new ContainerShip(30, 3, 500);
ContainerShip ship2 = new ContainerShip(25, 6, 500);

ship1.PrintShipLoadInfo();

ship1.LoadContainer(gContainer);
ship1.LoadContainer(lContainer);
ship1.LoadContainer(rContainer);

ship1.PrintShipLoadInfo();

GasContainer gContainer1 = new GasContainer(120, 12, 60, 6, 220, 15);
ship1.ReplaceContainer(gContainer.SerialNumber, gContainer1);

ship1.PrintShipLoadInfo();

ship1.TransferContaier(lContainer, ship2);
ship1.PrintShipLoadInfo();
ship2.PrintShipLoadInfo();

ship1.TransferContaier(lContainer, ship2);

LiquidContainer lContainer1 = new LiquidContainer(50, 8, 40, 4, 200, true);
LiquidContainer lContainer2 = new LiquidContainer(20, 8, 40, 4, 100, false);
List<Container> containers = new List<Container>();
containers.Add(lContainer1);
containers.Add(lContainer2);
ship2.LoadContainers(containers);
ship2.PrintShipLoadInfo();