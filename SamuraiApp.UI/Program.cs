// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiAppDomain;

//SamuraiContext _context = new SamuraiContext();
////_context.Database.EnsureCreated();

//AddSamurai("Obanai","Mitsuri");
//GetSamurais();
Console.WriteLine("Press any key");
Console.ReadLine();

//void AddSamurai(params string[] names)
//{
//    foreach(string name in names)
//    {
//        _context.Samurais.Add(new Samurai { Name = name });
//    }
//    _context.SaveChanges();
//}

//void GetSamurais()
//{
//    var samurais = _context.Samurais.TagWith("Get Samurai Method").ToList();
//    Console.WriteLine($"Jumlah samurai adalah {samurais.Count}");
//    foreach (var samurai in samurais)
//    {
//        Console.WriteLine(samurai.Name);
//    }
//}
