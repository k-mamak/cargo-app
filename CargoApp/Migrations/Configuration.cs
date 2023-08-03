namespace CargoApp.Migrations
{
    using CargoApp.DAL;
    using CargoApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CargoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CargoContext context)
        {
            // Check if database is already seeded
            if (!context.Customers.Any())
            {   
                var user = new User {UserName="admin", Password="admin"};
                context.Users.Add(user);
                context.SaveChanges();
                var customers = new List<Customer>
                {
                    new Customer{Name="Emre", Email="emre@test.com"},
                    new Customer{Name="Kadir", Email="kadir@test.com"},
                    new Customer{Name="Ahmet", Email="ahmet@test.com"},

                };
                customers.ForEach(customer => context.Customers.Add(customer));
                context.SaveChanges();
                var cargos = new List<Cargo>
                {
                    new Cargo{CustomerId=1, SourceAddress="Istanbul", DestinationAddress="Ankara", Description="Test", Weight=15, Status=Status.Delivered, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=1, SourceAddress="Trabzon", DestinationAddress="Bursa", Description="Test", Weight=22, Status=Status.InTransit, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=1, SourceAddress="Istanbul", DestinationAddress="Trabzon", Description="Test", Weight=10, Status=Status.Cancelled, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=2, SourceAddress="Erzurum", DestinationAddress="Izmir", Description="Test", Weight=3, Status=Status.InTransit, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=2, SourceAddress="Istanbul", DestinationAddress="Erzurum", Description="Test", Weight=1, Status=Status.Delivered, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=2, SourceAddress="Samsun", DestinationAddress="Konya", Description="Test", Weight=6, Status=Status.Cancelled, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=3, SourceAddress="Istanbul", DestinationAddress="Antalya", Description="Test", Weight=7, Status=Status.Delivered, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=3, SourceAddress="Kars", DestinationAddress="Samsun", Description="Test", Weight=55, Status=Status.InTransit, LastUpdate=DateTime.Now},
                    new Cargo{CustomerId=3, SourceAddress="Istanbul", DestinationAddress="Kars", Description="Test", Weight=2, Status=Status.Cancelled, LastUpdate=DateTime.Now},
                };
                cargos.ForEach(cargo => context.Cargos.Add(cargo));
                context.SaveChanges();
            }
        }
    }
}
