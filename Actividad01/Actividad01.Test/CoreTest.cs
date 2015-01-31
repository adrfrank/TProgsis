using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Actividad01.Data;
using Actividad01.Data.Entities;

namespace Actividad01.Test
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void FirstTest()
        {
            IRepositoryFactory<Vuelo> factory = new FileRepositoryFactory<Vuelo>();
            IRepository<Vuelo> rep = factory.CreateRepository();
            var vals = rep.FetchAll();
            for (int i = 0; i < 10; ++i)
            {
                rep.Add(new Vuelo() { Id = i, AsientosDisponibles = i });
            }
                rep.Save();
            var vals2 = rep.FetchAll();

            IRepository<Pasajero> pasajerosRepo = new FileRepositoryFactory<Pasajero>().CreateRepository();
            var pasajers = pasajerosRepo.FetchAll();
            for (int i = 0; i < 10; ++i)
            {
                pasajerosRepo.Add(new Pasajero() { Id = i, Nombre="Pasajero "+i });
            }
            pasajerosRepo.Save();

        }

        [TestMethod]
        public void CleanRepository()
        {
            IRepository<Pasajero> repo = new FileRepositoryFactory<Pasajero>().CreateRepository();
            repo.Add(new Pasajero());
            repo.Save();
            var vals = repo.FetchAll();
            Assert.IsTrue(vals.Count > 0);
            repo.CleanRepository();
            vals = repo.FetchAll();
            Assert.IsTrue(vals.Count == 0);          
        }
    }
}
