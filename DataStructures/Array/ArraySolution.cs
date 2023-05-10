using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class ArraySolution
    {
        // Object
        // Type : Array
        private Object[] _InnerArray; // null
        private int index = 0;

        public int Count => index;  // Dizi kaç eleman var?
        public int Capacity => _InnerArray.Length;


        public ArraySolution()
        {
            _InnerArray = new Object[4]; // Block allocation
        }

        public void Add(Object item)
        {
            if (index == _InnerArray.Length)
            {
                DoubleArray(_InnerArray);
            }

            _InnerArray[index] = item;
            index++;
        }

        private void DoubleArray(object[] array)
        {
            var newArray = new Object[array.Length * 2];
            System.Array.Copy(array, newArray, array.Length);
            _InnerArray = newArray;
        }


        /// <summary>
        /// Week 1
        /// </summary>
        /// <param name="position"></param>
        /// <returns>
        ///     Verilen pozisyonda bulunan elemanı geri döndürür.
        ///     Eğer pozisyon sınırlar dışındaysa IndexOutOfRangeException hata fırlatır.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public Object GetItem(int position)
        {
            // throw new NotImplementedException();
            if (position < 0 || position >= _InnerArray.Length)
                throw new IndexOutOfRangeException();
            return _InnerArray[position];
        }

        /// <summary>
        /// Week 1
        /// </summary>
        /// <param name="position"></param>
        /// <returns>
        ///     Verilen pozisyonda bulunan elemanı siler ve elemanı geri döndürür.
        ///     Eğer eleman yoksa veya sınırlar dışındaysa IndexOutOfRangeException hatası fırlatır.
        ///     Eğer pozisyonda eleman yoksa -1 döndür. 
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public Object RemoveItem(int position)
        {
            // throw new NotImplementedException();
            if (position < 0 || position >= _InnerArray.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var item = _InnerArray.ElementAt(position);
            if (item != null)
            {
                _InnerArray[position] = null;
                return item;
            }

            return -1;
        }

        /// <summary>
        /// Week 1 - Verilen pozisyondaki elemanları yer değiştirir.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void Swap(int p1, int p2)
        {
            // throw new NotImplementedException();
            var temp = GetItem(p1);
            _InnerArray[p1] = GetItem(p2);
            _InnerArray[p2] = temp;
        }

        /// <summary>
        /// Week 1
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        ///     Verilen elemana ait pozisyon bilgisini geri döndürür.
        ///     Eğer eleman yoksa -1 geri döndürür.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public Object Find(Object item)
        {
            // throw new NotImplementedException();
            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (_InnerArray[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}