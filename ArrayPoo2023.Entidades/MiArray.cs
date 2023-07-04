using System.Text;

namespace ArrayPoo2023.Entidades
{
    public class MiArray
    {
        private int _cantidad;
        private int[] _array;
        private int _tope;

        public int GetCantidad() => _cantidad;
        public int[] GetArray() => _array;

        public MiArray(int cantidad)
        {
            if (cantidad>0)
            {
                _cantidad = cantidad;
                _array = new int[_cantidad];
                _tope = 0;

            }
            else
            {
                throw new ArgumentException(nameof(cantidad));
            }
        }
        public MiArray():this(5)
        {
            
        }
        
        public bool IsEmpty()=>_tope == 0;
        public bool IsFull() => _tope == _cantidad;
        public void PopulateArray(int minimun=1, int maximun = 20)
        {
            Random r=new Random();
            for (int i=0; i < _array.Length; i++)
            {
                _array[i] = r.Next(minimun, maximun);
            }
            _tope = _cantidad;
        }

        public string MostrarArray()
        {
            StringBuilder sb= new StringBuilder();
            foreach (var itemArray in _array)
            {
                sb.Append($"{itemArray} ");
            }
            return sb.ToString();
        }
        public static bool operator +(MiArray array, int nro)
        {
            if (array.IsFull())
            {
                return false;
            }
            array._array[array._tope] = nro;
            array._tope++;
            return true;
        }
        public int GetTope() => _tope;
        public static bool operator ==(MiArray array, int nro)
        {
            if (array.IsEmpty())
            {
                return false;
            }
            foreach (var item in array._array)
            {
                if (item==nro)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(MiArray array, int nro)
        {
            return !(array == nro);
        }

        public int GetElemento(int posicion)
        {
            if (posicion>_cantidad-1)
            {
                throw new ArgumentException(nameof(posicion));
            }
            return _array[posicion];
        }
        public Tuple<string,int> GetPosicion(int nro)
        {
            string mensaje=string.Empty;
            int posicion = -1;
            if(this!=nro) {
                mensaje = $"No se encuentra el nro {nro} en el array";
                posicion = -1;
                return Tuple.Create(mensaje, posicion);
            }
            mensaje = $"El nro {nro} se encuentra  en el array";
            for (int i = 0; i < _cantidad; i++)
            {
                if (_array[i]==nro)
                {
                    posicion = i;
                    break;
                }
            }
            return Tuple.Create(mensaje, posicion);
        }
        public void Sort(bool descending)
        {
            
            for (int i = 0; i <=GetCantidad()-1; i++)
            {
                for (int j =i+1; j < GetCantidad(); j++)
                {
                    if (descending)
                    {
                        if (_array[i] < _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }
                    }
                    else
                    {
                        if (_array[i] > _array[j])
                        {
                            Change(ref _array[i], ref _array[j]);
                        }

                    }
                }
            }
        }

        private void Change(ref int x, ref int y)
        {
            int aux = x;
            x = y;
            y=aux;
        }

        public static explicit operator int(MiArray array)
        {
            return array._array.Sum();
        }
    }
}