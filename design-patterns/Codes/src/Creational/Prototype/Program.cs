using Prototype;
using static System.Console;

Soldier soldier = new();
soldier.Name = "Original Soldier";
soldier.Weapon = "Machine Gun";
soldier.Accessories = new Accessory { Name = "Helmet" };

var soldierClone1 = (Soldier)soldier.DeepClone();
soldierClone1.Name = "Clone Soldier One";
soldierClone1.Weapon = "Gun";
soldierClone1.Accessories.Name = "Night ViewFinder";

WriteLine("Soldiers:");
WriteLine(soldier.ToString());
WriteLine(soldierClone1.ToString());