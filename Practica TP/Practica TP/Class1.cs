using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica_TP
{
    public class practica
    {
        public class Item
        {
            public int Weight { get; set; }
            public int Value { get; set; }
        }
        public static List<Pedido> KnapSack(Pedido[] items, int capacity)
        {
            int[,] matrix = new int[items.Length + 1, capacity + 1];
            List<Pedido>[,] matrix2 = new List<Pedido>[items.Length + 1, capacity + 1];
            for (int i = 0; i < items.Length + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                    matrix2[i, j] = new List<Pedido>();
            }

            for (int itemIndex = 0; itemIndex <= items.Length; itemIndex++)
            {
                // This adjusts the itemIndex to be 1 based instead of 0 based
                // and in this case 0 is the initial state before an item is
                // considered for the knapsack.
                var currentItem = itemIndex == 0 ? null : items[itemIndex - 1];
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    // Set the first row and column of the matrix to all zeros
                    // This is the state before any items are added and when the
                    // potential capacity is zero the value would also be zero.
                    if (currentItem == null || currentCapacity == 0)
                    {
                        matrix[itemIndex, currentCapacity] = 0;
                    }
                    // If the current items weight is less than the current capacity
                    // then we should see if adding this item to the knapsack 
                    // results in a greater value than what was determined for
                    // the previous item at this potential capacity.
                    else if (currentItem.peso <= currentCapacity)
                    {
                        int a = currentItem.volumen
                                + matrix[itemIndex - 1, currentCapacity - currentItem.peso];
                        int b = matrix[itemIndex - 1, currentCapacity];
                        if (a > b)
                        {
                            matrix2[itemIndex, currentCapacity] = matrix2[itemIndex - 1, currentCapacity - currentItem.peso].ToList();
                            matrix2[itemIndex, currentCapacity].Add(currentItem);



                        }
                        else
                            matrix2[itemIndex, currentCapacity] = matrix2[itemIndex - 1, currentCapacity];

                        matrix[itemIndex, currentCapacity] = Math.Max(
                            currentItem.volumen
                                + matrix[itemIndex - 1, currentCapacity - currentItem.peso],
                            matrix[itemIndex - 1, currentCapacity]);

                    }
                    // current item will not fit so just set the value to the 
                    // what it was after handling the previous item.
                    else
                    {
                        matrix[itemIndex, currentCapacity] =
                            matrix[itemIndex - 1, currentCapacity];
                        matrix2[itemIndex, currentCapacity] = matrix2[itemIndex - 1, currentCapacity];
                    }
                }
            }

            // The solution should be the value determined after considering all
            // items at all the intermediate potential capacities.
            Console.WriteLine(matrix[items.Length, capacity]);
            Console.WriteLine(matrix2[items.Length, capacity].Count);

            return matrix2[items.Length, capacity];
        }

        public static void Main()
        {/*
            var items = new[]
            {
                new Item {Value = 60, Weight = 10},
                new Item {Value = 100, Weight = 20},
                new Item {Value = 120, Weight = 30},
             };


            List<Item> aux = KnapSack(items, 60);
            for (int i = 0; i < aux.Count; i++)
            {
                Console.WriteLine(aux[i].Value);
            }


            Console.WriteLine(aux);*/
            
            var csv_ = new csvfiles._csv();
            List<Pedido> Pedidos_ = csv_.read_csv();

            foreach (Pedido pedido in Pedidos_)
            {
                pedido.volumen = pedido.largo * pedido.alto * pedido.ancho;
            }

            KnapSack(Pedidos_.ToArray(), 5000);
        }
    }
}

/*
namespace Practica_TP
{
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

    public class practica
    {
        public class Item
        {
            public int Weight { get; set; }
            public int Value { get; set; }
        }

        public static List<Pedido> KnapSack(Pedido[] items, int capacity)
        {
            int[,] matrix = new int[items.Length + 1, capacity + 1];
            List<Pedido>[,] matrix2 = new List<Pedido>[items.Length + 1, capacity + 1];
            for (int i = 0; i < items.Length + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                    matrix2[i, j] = new List<Pedido>();
            }

            for (int itemIndex = 0; itemIndex <= items.Length; itemIndex++)
            {
                // This adjusts the itemIndex to be 1 based instead of 0 based
                // and in this case 0 is the initial state before an item is
                // considered for the knapsack.
                var currentItem = itemIndex == 0 ? null : items[itemIndex - 1];
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    // Set the first row and column of the matrix to all zeros
                    // This is the state before any items are added and when the
                    // potential capacity is zero the value would also be zero.
                    if (currentItem == null || currentCapacity == 0)
                    {
                        matrix[itemIndex, currentCapacity] = 0;
                    }
                    // If the current items weight is less than the current capacity
                    // then we should see if adding this item to the knapsack 
                    // results in a greater value than what was determined for
                    // the previous item at this potential capacity.
                    else if (currentItem.peso <= currentCapacity)
                    {
                        int a = currentItem.volumen
                                + matrix[itemIndex - 1, currentCapacity - currentItem.peso];
                        int b = matrix[itemIndex - 1, currentCapacity];
                        matrix2[itemIndex, currentCapacity] = matrix2[itemIndex - 1, currentCapacity].ToList();
                        if (a > b)
                            matrix2[itemIndex, currentCapacity].Add(currentItem);

                        matrix[itemIndex, currentCapacity] = Math.Max(
                            currentItem.volumen
                                + matrix[itemIndex - 1, currentCapacity - currentItem.peso],
                            matrix[itemIndex - 1, currentCapacity]);

                    }
                    // current item will not fit so just set the value to the 
                    // what it was after handling the previous item.
                    else
                    {
                        matrix[itemIndex, currentCapacity] =
                            matrix[itemIndex - 1, currentCapacity];
                    }
                }
            }

            // The solution should be the value determined after considering all
            // items at all the intermediate potential capacities.
            Console.WriteLine(matrix2[items.Length, capacity].Count);
            return matrix2[items.Length, capacity];
        }

        public static void Main()
        {
            var items = new[]
            {
                new Item {Value = 60, Weight = 10},
                new Item {Value = 100, Weight = 20},
                new Item {Value = 120, Weight = 30},
         };
            //public class Pedido
            //{
            //  public string? producto { get; set; }
            //public float precio { get; set; }
            //public float largo { get; set; }
            //public float ancho { get; set; }
            //public float alto { get; set; }
            //public string? prioridad { get; set; }
            //public string? barrio { get; set; }
            //public DateTime fecha { get; set; }
            //}
            var pedidos_ = new[]
            {
                new Pedido { producto="monitor", precio=18349, largo=81, ancho=99, alto=58, peso=174, prioridad="diferido"},
                new Pedido { producto="monitor2", precio=1839, largo=70, ancho=109, alto=68, peso=118, prioridad="diferido"},
                new Pedido { producto="monitor3", precio=134, largo=7, ancho=9, alto=78, peso=128, prioridad="diferido"},
                new Pedido { producto="monitor4", precio=834, largo=11, ancho=29, alto=38, peso=278, prioridad="express"},
            };

            foreach (Pedido pedido in pedidos_)
            {
                pedido.volumen = pedido.largo * pedido.alto * pedido.ancho;
            }

            int aux2 = 0;
            List<Pedido> aux = KnapSack(pedidos_, 280);
            for (int i = 0; i < aux.Count; i++)
            {
                aux2 = aux2 + aux[i].peso;
                Console.WriteLine(aux[i].peso);
            }
            Console.WriteLine("El peso total es: " + aux2);

            ///castear
            int[] Volumenes = new int[aux.Count + 1];
            int[] Pesos = new int[aux.Count + 1];

            Volumenes[0] = 0;
            Pesos[0] = 0;

            for (int i = 1; i < aux.Count + 1; i++)//Guardamos en el array los datos de los pedidos
            {
                Volumenes[i] = (int)aux[i - 1].volumen;
                Pesos[i] = (int)aux[i - 1].peso;
            }
            for (int i = 0; i < aux.Count; i++)
            {
                Console.WriteLine(Volumenes[i]);
                Console.WriteLine(Pesos[i]);


            }
            //Console.WriteLine("hola");


        }
    }

    
}
*/
/*
namespace Practica_TP
{
    public class practica
    {
        public class Item
        {
            public int Weight { get; set; }
            public int Value { get; set; }
        }
        public static List<Item> KnapSack(Item[] items, int capacity)
        {
            int[,] matrix = new int[items.Length + 1, capacity + 1];
            List<Item>[,] matrix2 = new List<Item>[items.Length + 1, capacity + 1];
           
            for(int i = 0; i < items.Length + 1; i++)
            {
                for (int j = 0; j < capacity + 1; j++)
                    matrix2[i, j] = new List<Item>();
            }

            for (int itemIndex = 0; itemIndex <= items.Length; itemIndex++)
            {
                // This adjusts the itemIndex to be 1 based instead of 0 based
                // and in this case 0 is the initial state before an item is
                // considered for the knapsack.
                var currentItem = itemIndex == 0 ? null : items[itemIndex - 1];
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    // Set the first row and column of the matrix to all zeros
                    // This is the state before any items are added and when the
                    // potential capacity is zero the value would also be zero.
                    if (currentItem == null || currentCapacity == 0)
                    {
                        matrix[itemIndex, currentCapacity] = 0;
                    }
                    // If the current items weight is less than the current capacity
                    // then we should see if adding this item to the knapsack 
                    // results in a greater value than what was determined for
                    // the previous item at this potential capacity.
                    else if (currentItem.Weight <= currentCapacity)
                    {
                        int a = currentItem.Value + matrix[itemIndex - 1, currentCapacity - currentItem.Weight];
                        int b = matrix[itemIndex - 1, currentCapacity];
                        if (a >= b)
                        {
                            matrix2[itemIndex, currentCapacity].Add(currentItem);
                        }
                      
                        matrix[itemIndex, currentCapacity] = Math.Max(a, b);
                        
                    }
                    // current item will not fit so just set the value to the 
                    // what it was after handling the previous item.
                    else
                    {
                        matrix[itemIndex, currentCapacity] = matrix[itemIndex - 1, currentCapacity];
                        matrix2[itemIndex, currentCapacity] = matrix2[itemIndex - 1, currentCapacity].ToList();
                    }
                }
            }

            // The solution should be the value determined after considering all
            // items at all the intermediate potential capacities.
            return matrix2[items.Length, capacity];
        }
        public static void Main()
        {
            var items = new[]
            {
                new Item {Value = 60, Weight = 10},
                new Item {Value = 100, Weight = 20},
                new Item {Value = 120, Weight = 30},
             };
    

            List<Item> lista = KnapSack(items, 70);

            for (int i = 0; i < lista.Count; i++)
                
                Console.WriteLine(lista[i].Value);
        }
    }
}*/
