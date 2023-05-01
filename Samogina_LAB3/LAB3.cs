using System;
using System.Reflection;
using System.Security.Claims;

namespace Samogina_LAB3
{
    class LAB3
    {
        static void Main()
        {
            Nodelist<string> list = new Nodelist<string>();
            Nodelist<string> list2 = new Nodelist<string>();
            var a= Console.ReadLine();
            list.Push_back(a);
            Console.WriteLine(list[0]);
        }
    }

    class NODE<T>
    {
        public T? Data;
        public NODE<T>? Next;
        public NODE<T>? Prev;
        public NODE(T? data, NODE<T>? next, NODE<T>? prev) { Data = data; Next = next; Prev = prev; }
        public NODE() { Data = default(T); Next = null; Prev = null; }
        public NODE(T data) { Data = data; Prev = null; Next = null; }
        public void Print() { Console.WriteLine(this.Data); }

    }

    class Nodelist<T>
    {

        protected NODE<T>? Head;
        protected NODE<T>? Tail;
        //public Nodelist() { Head = new NODE<T>(); }
        // private static bool Compare<T>(T a, T b) where T : NODE<T> {return a.Data.ToString() != b.Data.ToString();}
        public NODE<T> Push_front(T data) // добавление в начало
        {
            NODE<T> ptr = new NODE<T>(data);
            ptr.Next = Head;
            if (Head != null) { Head.Prev = ptr; }
            if (Tail == null) { Tail = ptr; }
            Head = ptr;
            return ptr;
        }
        public NODE<T> Push_back(T data) //добавление в конец
        {
            NODE<T> ptr = new NODE<T>(data);
            ptr.Prev = Tail;
            if (Tail != null) { Tail.Next = ptr; }
            if (Head == null) { Head = ptr; }
            Tail = ptr;
            return ptr;
        }
        public void Pop_front()
        { //удаление с головы
            if (Head == null) return;
            NODE<T>? ptr = Head.Next;
            if (ptr != null) { ptr.Prev = null; }
            else Tail = ptr;

            Head = ptr;
        }
        public void Pop_back() //удаление с конца
        {
            if (Tail == null) return;
            NODE<T>? ptr = Tail.Prev;
            if (ptr != null) { ptr.Next = null; }
            else Head = ptr;

            Tail = ptr;
        }
        public NODE<T> getAt(int index) //поиск по позиции
        {
            NODE<T>? ptr = Head;
            int n = 0;
            while (n != index)
            {
                if (ptr == null) return ptr;
                ptr = ptr.Next;
                n++;
            }
            return ptr;
        }
        public NODE<T> insert(int index, T data)
        { //добавить на позицию
            NODE<T> right = getAt(index);
            if (right == null) return Push_back(data);

            NODE<T>? left = right.Prev;
            if (left == null) return Push_front(data);

            NODE<T> ptr = new NODE<T>(data);
            ptr.Prev = left;
            ptr.Next = right;
            left.Next = ptr;
            right.Prev = ptr;
            return ptr;
        }
        public void earse(int index) // удаление по позиции
        {
            NODE<T> ptr = getAt(index);
            if (ptr == null) return;
            if (ptr.Prev == null) { Pop_front(); return; }
            if (ptr.Next == null) { Pop_back(); return; }
            NODE<T> left = ptr.Prev;
            NODE<T> righ = ptr.Next;
            left.Next = righ;
            righ.Prev = left;
        }
        public NODE<T> find(T data)
        { // найти по ключу
            NODE<T>? ptr = Head;
            if (ptr == null) return ptr;
            while (ptr.Data.ToString() != data.ToString())
            {
                ptr = ptr.Next;
                if (ptr.Data == null) { return ptr; }
            }
            return ptr;
        }
        public NODE<T> insert_key(T key, T data) //добавление после ключа
        {
            NODE<T> right = find(key);
            right = right.Next;
            if (right == null) return Push_back(data);

            NODE<T>? left = right.Prev;
            if (left == null) return Push_front(data);

            NODE<T> ptr = new NODE<T>(data);
            ptr.Prev = left;
            ptr.Next = right;
            left.Next = ptr;
            right.Prev = ptr;
            return ptr;
        }
        public void earse_key(T data) // удаление по ключу
        {
            NODE<T> ptr = find(data);
            if (ptr == null) return;
            if (ptr.Prev == null) { Pop_front(); return; }
            if (ptr.Next == null) { Pop_back(); return; }
            NODE<T> left = ptr.Prev;
            NODE<T> righ = ptr.Next;
            left.Next = righ;
            righ.Prev = left;
        }
        public NODE<T> Max() //максимум
        {
            NODE<T>? ptr = Head;
            NODE<T>? data = ptr;
            while (ptr != null)
            {
                if (System.Convert.ToChar(data.Data) < System.Convert.ToChar(ptr.Data)) { data = ptr; }
                ptr = ptr.Next;
            }
            return data;
        }
        public NODE<T> Min()
        {
            NODE<T>? ptr = Head;
            NODE<T>? data = ptr;
            while (ptr != null)
            {
                if (System.Convert.ToInt32(data.Data) > System.Convert.ToInt32(ptr.Data)) { data = ptr; }
                ptr = ptr.Next;
            }
            return data;
        }//минимум
        public bool is_empy() { if (Head == null) return true; return false; }
        public void clear() { while (Head != null) { Pop_back(); } }
        public static Nodelist<T> operator +(Nodelist<T> l1, Nodelist<T> l2)
        {
            Nodelist<T> list = new Nodelist<T>();
            NODE<T>? ptr1 = l1.Head;
            NODE<T>? ptr2 = l2.Head;
            while (ptr1 != null) { list.Push_back(ptr1.Data); ptr1 = ptr1.Next; }
            while (ptr2 != null) { list.Push_back(ptr2.Data); ptr2 = ptr2.Next; }
            return list;
        }
        public static bool operator ==(Nodelist<T> l1, Nodelist<T> l2)
        {
            NODE<T>? ptr = l1.Head;
            NODE<T>? ptr2 = l2.Head;
            if (ptr != null && ptr2 != null) return false;
            while (ptr.Data.ToString() == ptr2.Data.ToString()) { ptr = ptr.Next; ptr2 = ptr2.Next; }
            if (ptr == null && ptr2 == null) return true;
            return false;
        }
        public static bool operator !=(Nodelist<T> l1, Nodelist<T> l2)
        {
            return !(l1 == l2);
        }
        public T this[int index]
        {
            get
            {
                return getAt(index).Data;
            }
        }
    }
}