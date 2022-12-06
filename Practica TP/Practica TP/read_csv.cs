using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica_TP
{
    public class _csv
    {
        public List<Pedido> read_csv()
        {
            using (var reader = new StreamReader(Resources.archivo))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                List<Pedido> records = new List<Pedido>();

                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {

                    Pedido record = new Pedido
                    {
                        producto = csv.GetField<string>("producto"),
                        precio = csv.GetField<float>("precio"),
                        ancho = csv.GetField<float>("ancho"),
                        largo = csv.GetField<float>("largo"),
                        alto = csv.GetField<float>("alto"),
                        prioridad = csv.GetField<string>("prioridad"),
                        barrio = csv.GetField<string>("barrio"),
                        fecha = new DateTime(csv.GetField<int>("fecha"))
                    };
                    records.Add(record);
                }

                return records;
            }
        }
    }
};

// Esta clase es base para la lectura del archivo
// Puede ser editada en base a su TP
public class Pedido
{
    public string? producto { get; set; }
    public int precio { get; set; }
    public int largo { get; set; }
    public int ancho { get; set; }
    public int alto { get; set; }

    public int peso { get; set; }
    public string? prioridad { get; set; }

    public int volumen { get; set; }
    //public string? barrio { get; set; }

    //public DateTime fecha { get; set; }
}