using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Actividad01.Data.Util
{
   public  class BinaryTree<T>
    {
        Func<T, IComparable> compareFunc;

        public Func<T, IComparable> CompareFunc
        {
            get { return compareFunc; }
            set { compareFunc = value; }
        }

        T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        BinaryTree<T> left;

        public BinaryTree<T> Left
        {
            get { return left; }
            set { left = value; }
        }
        BinaryTree<T> right;

        public BinaryTree<T> Right
        {
            get { return right; }
            set { right = value; }
        }


        public BinaryTree(T data, Func<T, IComparable> compareFunc)
        {
            Data = data;
            CompareFunc = compareFunc;
        }

        public void Insert(T data)
        {
            var actualValue = CompareFunc(Data);
            var newValue = CompareFunc(data);
            if (actualValue.CompareTo(newValue) == 0)
            {
                throw new InvalidOperationException("El valor clave ya existe en el arbol");
            }

            if (newValue.CompareTo(actualValue) > 0)
            {
                if (Right == null)
                    Right = new BinaryTree<T>(data, CompareFunc);
                else
                    Right.Insert(data);
            }
            else {
                if (Left == null)
                    Left = new BinaryTree<T>(data, CompareFunc);
                else
                    Left.Insert(data);
            }
        }

        public void InOrdenAction(Action<T> proccess) {
            if (Left != null)
                Left.InOrdenAction(proccess);
            proccess(Data);
            if (Right != null)
                Right.InOrdenAction(proccess);
        }

        public override string ToString()
        {
            return CompareFunc(data).ToString();
        }

        public T Find(IComparable KValue) {
            if (KValue.CompareTo(CompareFunc(Data)) == 0)
                return Data;

            if(KValue.CompareTo(CompareFunc(Data)) >  0){
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

        public static BinaryTree<T> FromArray(T[] array, Func<T,IComparable> compareFunc) {
            BinaryTree<T> root = null;
            foreach (var item in array)
            {
                if (root == null)
                    root = new BinaryTree<T>(item, compareFunc);
                else
                    root.Insert(item);
            }
            return root;
        }
    }
}
