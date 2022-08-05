// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


byte[] chars = new byte[32];
var time = NASMB.GO.Egg1.EnEgg1Code(chars, 32);
Console.WriteLine(Convert.ToHexString(chars));
Console.WriteLine(time);
byte[] dcode = new byte[20];
var ret = NASMB.GO.Egg1.DeEgg1Code(chars, 32, time, dcode, 20);

Console.WriteLine(Convert.ToHexString(dcode));

Console.ReadKey();