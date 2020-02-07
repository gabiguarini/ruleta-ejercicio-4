using System;
using System.Collections.Generic;
using System.Linq;

namespace ruleta_ejercicio_4
{
    class Program
    {

          static void Main(string[] args)
        {
            
            Console.WriteLine("Ingrese nros entre 0 y 36, seguidos por comas, para jugar a la ruleta :)");
            string apuestas = Console.ReadLine();

            //le decimos que haga "split" a partir de cada coma y cargamos esos valores en la lista ward 
           List<string> ward = apuestas.Split(',').ToList();

            //nueva lista para pasar a int los inputs
            List<int> nums = new List<int>();


            int unNum;

            int n = nums.Count;

            //rango
            int A = 0;
            int B = 36;
            
            //recorrido para llenar la lista con nros
            foreach(string a in ward)
            {
                if (Int32.TryParse(a, out unNum))
                {
                    nums.Add(unNum);
                }
            } 
            
               Rango(nums, n, A, B);
            
                int ganador;
                ganador = Tirada(nums);

                if (Rango(nums, n, A, B) == true)
                {
                    Console.WriteLine("el número {0} es el ganador", ganador);
                }

                else
                {
                    Console.WriteLine("Revisa si los números ingresados están dentro del rango :(");
                }

                //usamos el Dictionary para buscar los elementos que se repiten
                var dict = new Dictionary<int, int>();
                
                foreach(var val in nums)
                {
                    
                    if (dict.ContainsKey(val))
                        dict[val]++;
                    else
                        dict[val] = 1;
                }

                foreach(var pair in dict)
                {
                    //le decimos que de los elementos repetidos, solo los que coinciden con "ganador" nos interesa
                    if(pair.Key == ganador){
                    Console.WriteLine("Hay {1} ganadores con el nro {0}.", pair.Key, pair.Value);
                     Console.ReadKey(); 
                    }
                }
            
            

        }
          public static bool Rango(List<int> nums, int n, int A, int B) 
        { 
            
            int range = B - A;
         
            //recorre cada elemento de la lista y verifica si esta dentro del rango
            for (int i = 0; i <= n; i++) 
            { 
               if (Math.Abs(nums[i]) >= A &&  
                Math.Abs(nums[i]) <= B)  
                { 
                    int z = Math.Abs(nums[i]) - A; 
                    if (nums[z] > 0) 
                    { 
                      nums[z] = nums[z] * - 1; 
                    } 
                } 
                
            } 

            return true;            

        }

        public static int Tirada(List<int> nums)  
        {  
            //obtenemos el nro random dandole como parametro solo los nros de la lista
            Random random = new Random();
            int win = random.Next(0, nums.Count);
            return win;
        }  

    }   

     
}
