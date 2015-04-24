using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Actividad01.Data;
using Actividad01.Data.Entities;
using System.Diagnostics;
using Actividad01.Data.Util;

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
            vals.MergeSort(x=>x.Id);
            Assert.IsTrue(vals.Count == 0);          
        }

        [TestMethod]
        public void TestHashcode() {
            IRepository<Pasajero> repo = new FileRepositoryFactory<Pasajero>().CreateRepository();
            repo.Add(new Pasajero(){ Nombre="segundo"});
            repo.Add(new Pasajero(){ Nombre="Primero"});
            repo.Save();
            var desordenados = repo.FetchAll();
            var ordenados = desordenados.MergeSort(x => x.Asiento);
            Console.WriteLine("asdf");
            
        }

        [TestMethod]
        public void TestBinaryTree() {
            int[] desordenados = { 5, 4,2,8,7,1 };
            var arbol = new Actividad01.Data.Util.BinaryTreeList<int>(desordenados[0], x => x);
            for (int i = 1; i < desordenados.Length; i++) {
                arbol.Insert(desordenados[i]);
            }
            arbol.InOrdenAction(entero => {
                Console.WriteLine(entero);
                Debug.WriteLine(entero);
            });
            var found = arbol.Find(7);
            Assert.AreEqual(7, found);
            found  = arbol.Find(15);
            Assert.AreEqual(default(int), found);
        }

        [TestMethod]
        public void GraphTest()
        {
            
            Graph<string> graph = new Graph<string>();
            graph.AddArist("San Antonio", "Merida", 1200);
            graph.AddArist("San Antonio", "Leon", 900);
            graph.AddArist("Merida", "DF", 450);
            graph.AddArist("Leon", "DF", 350);
            graph.AddArist("Leon", "MTY", 700);
            graph.AddArist("Leon", "GDL", 250);
            graph.AddArist("Cancun", "GDL", 600);
            graph.AddArist("Cancun", "DF", 650);
            graph.AddArist("Leon", "Mazatlan", 300);
            graph.AddArist("DF", "GDL", 500);

            graph.AddArist("GDL", "Mazatlan", 500);
            graph.AddArist("GDL", "MTY", 900);

            graph.AddArist("MTY", "Tijuana", 900);
            graph.AddArist("MTY", "Mazatlan", 900);

            graph.AddArist("Mazatlan", "Tijuana", 900);


            var found = graph.FindFromRoot("Cancun");

            

            if (found == null)
                Debug.WriteLine("No Encontrado");
            else
                Debug.WriteLine("Encontrado: " + found);


            found = graph.FindFromRoot("Tijuana");

            if (found == null)
                Debug.WriteLine("No Encontrado");
            else
                Debug.WriteLine("Encontrado: " + found);

            found = graph.FindFromRoot("No aparezcas");

            if (found == default(string))
                Debug.WriteLine("No Encontrado");
            else
                Debug.WriteLine("Encontrado: " + found);


            var mst = graph.GetMSTByPrim();
            mst.PrintEdges();
            Trace.WriteLine("----");
            graph.PrintEdges();
        }
    }
}
