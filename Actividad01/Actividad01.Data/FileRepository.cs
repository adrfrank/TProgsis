﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Actividad01.Data
{
    public class FileRepository<T> : IRepository<T>
        where T : RepositoryEntity
    {
        public const string FileExtensions = ".txt,.repo";
        public IQueryable<T> Query
        {
            get { return LocalObjects.AsQueryable(); }
        }

        public string FilePath { get; set; }
        public List<T> LocalObjects { get; private set; }

        public FileRepository()
        {
            string filePath = null;
            if (filePath == null)
            {//Construct a new name
                FilePath = Directory.GetCurrentDirectory() + "\\" + typeof(T).Name + ".repo";
            }
            else
                FilePath = filePath;
            verifyExtension();
            FetchAll();

        }

        StreamReader getNewReader()
        {
            //Check for path
            var path = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Check for file
            if (!File.Exists(FilePath))
            {
                var fs = File.Create(FilePath);
                TextWriter tr = new StreamWriter(fs);
                tr.WriteLine("[]");
                tr.Close();

            }
            return new StreamReader(FilePath); ;
        }

        StreamWriter getNewWriter()
        {
            //Check for path
            var path = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Check for file
            if (!File.Exists(FilePath))
            {
                var fs = File.Create(FilePath);
                TextWriter tr = new StreamWriter(fs);
                tr.WriteLine("[]");
                tr.Close();

            }
            return new StreamWriter(FilePath); ;
        }

        void verifyExtension()
        {
            var extension = Path.GetExtension(FilePath).ToLower();
            if (!FileExtensions.Contains(extension))
                throw new ArgumentException("La extension no es valida para este repositorio");
        }


        public List<T> FetchAll()
        {
            using (StreamReader sr = getNewReader())
            {
                DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(List<T>));
                LocalObjects = (List<T>)jsonSer.ReadObject(sr.BaseStream);
            }
            return LocalObjects;
        }



        public void Add(T entity)
        {
            if (LocalObjects.Count > 0)
            {
                var ids = LocalObjects.Select(x => x.Id);
                if (ids.Contains(entity.Id))
                    entity.Id = getNewId();
            }
            LocalObjects.Add(entity);
        }

        int getNewId() {
            if (LocalObjects.Count == 0) return 1;
            var ids = LocalObjects.Select(x => x.Id);
            return ids.OrderByDescending(x => x).First() + 1; 
        }

        void setNewIds() {
            int newid = getNewId();
            var ids = LocalObjects.Where(x=> x.Id!=0).Select(x => x.Id).Distinct();
            foreach (var item in LocalObjects)
            {
                if (!ids.Contains(item.Id))
                    item.Id = newid++;
            }
        }

        public void Delete(T entity)
        {
            LocalObjects.Remove(
                LocalObjects.Where(x => x.Id == entity.Id).FirstOrDefault()
            );
        }

        public void Save()
        {
            setNewIds();
            using (var writer = getNewWriter())
            {
                DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(List<T>));
                jsonSer.WriteObject(writer.BaseStream, LocalObjects);
            }
        }



        public void CleanRepository()
        {
            LocalObjects = new List<T>();
            Save();
        }


        public void Merge(IEnumerable<T> toMerge)
        {
            foreach (var item in toMerge)
            {

                T obj=null;
                if(item.Id > 0)
                    obj = LocalObjects.FirstOrDefault(x => x.Id == item.Id);
                if (obj != null)
                {
                    obj = item;
                }
                else
                {
                    LocalObjects.Add(item);
                }

            }
        }
    }
}
