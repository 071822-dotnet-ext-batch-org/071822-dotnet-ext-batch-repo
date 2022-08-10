// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using AsyncAwaitDemo;

Task<int> t1 = AsyncMethods.Method1Async();
Task<int> t2 = AsyncMethods.Method2Async();
Task<int> t3 = AsyncMethods.Method3Async();
Task<int> t4 = AsyncMethods.Method4Async();

int myt1 = await t1;
Console.WriteLine($"This is Method1 {myt1}");

int myt2 = await t2;
Console.WriteLine($"This is Method2 {myt2}");
int myt3 = await t3;
Console.WriteLine($"This is Method3 {myt3}");
int myt4 = await t4;
Console.WriteLine($"This is Method4 {myt4}");


