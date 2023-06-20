using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Clases
{
    public static class Archivos<T>
    {
        /// <summary>
        /// Este metodo serializa cualquier objeto dado gracias al uso de Generics.
        /// </summary>
        /// <param name="Dato">
        /// Objeto/Dato que se quiera serializar
        /// </param>
        /// <param name="ruta">
        /// Ruta donde se guarda el archivo, no olvidar agregar nombre y extension tambien.
        /// </param>
        /// <returns>
        /// Verdadero si la serializacion fue correcta, caso contrario retornara false.
        /// </returns>
        public static bool Serializar(T Dato, string ruta)
        {
            bool ret = false;
            string jSon;
            jSon = JsonSerializer.Serialize(Dato);
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                sw.WriteLine(jSon);
                ret = true;
            }
            return ret;
        }
    }
}
