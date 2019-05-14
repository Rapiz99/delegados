using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegados
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<double, double, double> raiz = CalcularRaiz;
            //Func<double, double, double> potencia = (x, y) => { return Math.Pow(x, y); };
           
            //Console.WriteLine($"la raiz es: { potencia(6, 3)}");
            //Console.WriteLine($"la raiz es: {raiz(6, 3)}");
            Proyecto pro = new Proyecto();
            //pro.AgregarProyecto();
            //pro.AgregarProyecto2();
            //pro.Listar();
            var proy = pro.AgregarProyecto2();
            var listar = pro.proyectos;
            Console.WriteLine($"Los proyectos cuya duracion es mayor a 6 y menor a 12 son:  ");
            var proyMayor = pro.proyectos.Where(x => x.Duracion > 6 && x.Duracion < 12).ToList();
            pro.Listar(proyMayor);
            Console.ReadLine();
            Console.WriteLine("Proyectos que empiezan con la letra B");
            var proyectosB = from p in pro.proyectos
                             where (p.Nombre.StartsWith("B"))
                             select p;
            pro.Listar(proyectosB.ToList());
            Console.ReadLine();
            //obtener los proyectos cuyo codigo sea multiplo de 7
            Console.WriteLine("proyectos con multiplo de 7");
            var proyMul = pro.proyectos.Where(x => x.Codigo % 7 == 0).ToList();
            pro.Listar(proyMul);
            Console.ReadLine();
            //Agrupar los proyectos que tengan duracion inferior a 6 ,superior a 6 superior a 10
            var gruposProys = pro.proyectos.GroupBy(x =>
            {
                if (x.Duracion < 6)
                {
                    return "son menores a 6";
                }
                else if (x.Duracion > 6 && x.Duracion < 10)
                {
                    return "Entre 6 y 10";
                }
                else
                {
                    return "Mayores a 10";
                }
            });
            foreach(var grupoProy in gruposProys)
            {
                Console.WriteLine("Grupo de proyectos " + grupoProy.Key +"------Cantidad----"+ grupoProy.Count());
                foreach(var item in grupoProy)
                {
                    Console.WriteLine("El nombre proyecto: " + item.Nombre + "\r\n" + "Codigo proyecto: " + item.Codigo);
                }
            }

            Console.WriteLine();
            //obtener el promedio de la duracion de todos los proyectos
            var avgSumT = pro.proyectos.Average(x => x.Duracion);
            Console.WriteLine("El promedio de los proyectos es: " + avgSumT);
            Console.WriteLine();

            //obtener el nombre del proyecto con mas duracion
            var dato = pro.proyectos.Max(y => y.Duracion);
            var maxSumT = pro.proyectos.Where(x=> x.Duracion==dato).Select(x=> x.Nombre).FirstOrDefault();
            Console.WriteLine($"El maximo de todos es: {maxSumT} ");
            Console.ReadLine();

            //Seleccionar el nombre y el area del proyecto con duracion mayor a 6
            var da = pro.proyectos.Max(a => a.Area);
            var dat = pro.proyectos.Max(y => y.Duracion);
            var maxAreT = pro.proyectos.Where(x => x.Duracion >6).Select(x => x.Nombre).FirstOrDefault();
            Console.WriteLine($"El maximo de todos es: {maxAreT} cuyo area es: {da}");
            Console.ReadLine();
        }


        //static double CalcularRaiz(double num1, double num2)
        //{
        //    var operacion = Math.Pow(num1, num2);
        //    return operacion;
        //}
    }
}
