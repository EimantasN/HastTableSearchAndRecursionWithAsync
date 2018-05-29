using System;


namespace HastTableSearchAndRecursionWithAsync
{
    public class HashTableQ
    {
        private int currentSize, maxSize;
        private string[] keys;
        private string[] vals;

        public int size = 0;

        public int rehash = 0;

        public HashTableQ(int capacity)
        {
            currentSize = 0;
            maxSize = (capacity * 2) - 1;
            keys = new string[maxSize];
            vals = new string[maxSize];
        }

        public void makeEmpty()
        {
            currentSize = 0;
            keys = new string[maxSize];
            vals = new string[maxSize];
        }

        public int getSize()
        {
            return currentSize;
        }

        public bool isFull()
        {
            return currentSize == maxSize;
        }

        public bool isEmpty()
        {
            return getSize() == 0;
        }

        public bool contains(string key)
        {
            return get(key) != null;
        }

        private int hash(string key)
        {
            return Math.Abs(key.GetHashCode() % maxSize);
        }

        public void insert(string key, string val)
        {
            int tmp = hash(key);
            int i = tmp, h = 1;
            do
            {
                if (keys[i] == null)
                {
                    keys[i] = key;
                    vals[i] = val;
                    currentSize++;
                    size++;
                    return;
                }
                if (keys[i].Equals(key))
                {
                    vals[i] = val;
                    return;
                }
                i = (i + h * h++) % maxSize;
                rehash = h;
            } while (i != tmp);

        }

        public string get(string key)
        {
            int i = hash(key), h = 1;
            while (keys[i] != null)
            {
                if (keys[i].Equals(key))
                    return vals[i];
                i = (i + h * h++) % maxSize;
            }
            return null;
        }

        public void remove(string key)
        {
            if (!contains(key))
                return;

            int i = hash(key), h = 1;
            while (!key.Equals(keys[i]))
                i = (i + h * h++) % maxSize;
            keys[i] = vals[i] = null;

            for (i = (i + h * h++) % maxSize; keys[i] != null; i = (i + h * h++) % maxSize)
            {
                string tmp1 = keys[i], tmp2 = vals[i];
                keys[i] = vals[i] = null;
                currentSize--;
                insert(tmp1, tmp2);
            }
            currentSize--;
        }

        public bool Find(string name, string surname)
        {
            Data data = new Data();
            string key = data.getKey(name, surname);
            int i = hash(key);
            for (int h = 1; h < maxSize; h++)
            {
                if (vals[i] == (name + " " + surname))
                    return true;
                i = (i + h * h) % maxSize;
            }
            return false;
        }

        public int FindCount(string name, string surname)
        {
            int getkey = 7;

            int count = 4 + getkey + 3;

            Data data = new Data();                     //1
            string key = data.getKey(name, surname);    //1 + getKey
            int i = hash(key);                          //1 + hash
            for (int h = 1; h < maxSize; h++)           //2 --> 1
            {
                if (vals[i] == (name + " " + surname))  //3
                {
                    count = count + 4;
                    return count;                        //1
                }
                i = (i + h * h) % maxSize;              //4
                count += 4 + 2;
            }
            return count;
        }

        public void printHashTable()
        {
            Console.WriteLine("\nHash Table Operatyvineje: ");
            for (int i = 0; i < maxSize; i++)
                if (keys[i] != null)
                    Console.WriteLine(keys[i] + " " + vals[i]);
            Console.WriteLine();
        }
    }
}
