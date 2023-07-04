using ArrayPoo2023.Entidades;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ArrayPoo2022.Test
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayCreateFailTest()
        {
            int cantidad = -1;
            MiArray array=new MiArray(cantidad);
        }
        [TestMethod]
        public void ArrayCreateOkTest()
        {
            MiArray array = new MiArray();
            Assert.AreEqual(10,array.GetCantidad());
        }
        [TestMethod]
        public void ArrayIsEmptyTest()
        {
            int cantidad = 10;
            MiArray array = new MiArray(cantidad);
            Assert.IsTrue(array.IsEmpty());
        }
        [TestMethod]
        public void ArrayPopulatedTest()
        {
            int cantidad = 10;
            MiArray array = new MiArray(cantidad);
            array.PopulateArray();
            Assert.IsTrue(array.IsFull());
            
        }
        [TestMethod]
        public void ArrayAddElementoOk()
        {
            MiArray array=new MiArray();
            int nro = 10;
            bool agregado=array + nro;
            Assert.IsTrue(agregado);
            
        }
        [TestMethod]
        public void ArrayAddElementoFail()
        {
            MiArray array = new MiArray();
            array.PopulateArray();
            int nro = 10;
            bool agregado = array + nro;
            Assert.IsFalse(agregado);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayGetElementoFail()
        {
            MiArray array = new MiArray();
            array.PopulateArray();
            int posicion = 10;
            array.GetElemento(posicion);

        }
        [TestMethod]
        public void ArrayGetPosicionOK()
        {
            MiArray array = new MiArray();
            int nro = 10;
            bool agregado = array + nro;
            int nroBuscado = 10;
            var mensaje = $"El nro {nroBuscado} se encuentra  en el array";
            var tupla = Tuple.Create(mensaje, 0);
            Assert.AreEqual(tupla, array.GetPosicion(nroBuscado));
        }
        [TestMethod]
        public void ArrayGetPosicionFailK()
        {
            MiArray array = new MiArray();
            int nro = 10;
            bool agregado = array + nro;
            int nroBuscado = 1;
            var mensaje = $"No se encuentra el nro {nroBuscado} en el array";
            var posicion = -1;

            var tupla = Tuple.Create(mensaje, posicion);
            Assert.AreEqual(tupla, array.GetPosicion(nroBuscado));
        }
        [TestMethod]
        public void ArraySortAscending()
        {
            MiArray array = new MiArray();
            array.Sort(false);
            Assert.IsTrue(CheckIfSorted(array.GetArray(),false));
        }

        private bool CheckIfSorted(int[] array, bool descending)
        {
            bool isSorted = true;
            for (int i = 1; i<array.Length; i++)
            {
                if (descending)
                {
                    if (array[i - 1] > array[i])
                    {
                        isSorted = false;
                        break;
                    }
                    
                }
                else {

                    if (array[i - 1] <array[i])
                    {
                        isSorted = false;
                        break;
                    }
                }
            }
            return isSorted;
        }
    }
}