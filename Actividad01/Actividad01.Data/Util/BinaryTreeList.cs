using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Actividad01.Data.Util
{
   public  class BinaryTreeList<T>
    {
        Func<T, IComparable> compareFunc;

        public Func<T, IComparable> CompareFunc
        {
            get { return compareFunc; }
            set { compareFunc = value; }
        }

        List<T> data;
        public  List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        BinaryTreeList<T> left;

        public BinaryTreeList<T> Left
        {
            get { return left; }
            set { left = value; }
        }
        BinaryTreeList<T> right;

        public BinaryTreeList<T> Right
        {
            get { return right; }
            set { right = value; }
        }


        public BinaryTreeList(T data, Func<T, IComparable> compareFunc)
        {
            Data = new List<T>();
            Data.Add(data);
            CompareFunc = compareFunc;
        }

        public void Insert(T data)
        {
            var actualValue = CompareFunc(Data.First());
            var newValue = CompareFunc(data);
            if (actualValue.CompareTo(newValue) == 0)
            {
                Data.Add(data);
            }

            if (newValue.CompareTo(actualValue) > 0)
            {
                if (Right == null)
                    Right = new BinaryTreeList<T>(data, CompareFunc);
                else
                    Right.Insert(data);
            }
            else {
                if (Left == null)
                    Left = new BinaryTreeList<T>(data, CompareFunc);
                else
                    Left.Insert(data);
            }
        }

        public void InOrdenAction(Action<T> proccess) {
            if (Left != null)
                Left.InOrdenAction(proccess);
            proccess(data.First());            
            if (Right != null)
                Right.InOrdenAction(proccess);
        }
        public void InOrdenActionList(Action<T> proccess)
        {
            if (Left != null)
                Left.InOrdenAction(proccess);
            foreach (var item in Data)
            {
                proccess(item);

            }
            if (Right != null)
                Right.InOrdenAction(proccess);
        }

        public override string ToString()
        {
            return CompareFunc(data.First()).ToString();
        }

        public T Find(IComparable KValue) {
            if (KValue.CompareTo(CompareFunc(Data.First())) == 0)
                return Data.First();

            if(KValue.CompareTo(CompareFunc(Data.First())) >  0){
                if (Right == null)
                    return default(T);
                return Right.Find(KValue);
            }
            else
            {
                if (Left == null)
                    return default(T);
                return Left.Find(KValue);
            }

        }

        public List<T> FindList(IComparable KValue)
        {
            if (KValue.CompareTo(CompareFunc(Data.First())) == 0)
                return Data;

            if (KValue.CompareTo(CompareFunc(Data.First())) > 0)
            {
                if (Right == null)
                    return null;
                return Right.FindList(KValue);
            }
            else
            {
                if (Left == null)
                    return null;
                return Left.FindList(KValue);
            }

        }

        public static BinaryTreeList<T> FromArray(T[] array, Func<T, IComparable> compareFunc)
        {
            BinaryTreeList<T> root = null;
            foreach (var item in array)
            {
                if (root == null)
                    root = new BinaryTreeList<T>(item, compareFunc);
                else
                    root.Insert(item);
            }
            return root;
        }
    }
}
