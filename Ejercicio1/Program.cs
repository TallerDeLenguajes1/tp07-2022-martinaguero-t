using System;

namespace Ejercicio1
{
    class Program {

        static int Main(string[] args){

            int cantTareas = 0;

            do
            {
                Console.WriteLine("Ingrese la cantidad de tareas a cargar: ");

                int.TryParse(Console.ReadLine(),out cantTareas);

            } while (cantTareas < 1);

            List<Tarea> listaTareasPendientes = new List<Tarea>();
            List<Tarea> listaTareasRealizadas = new List<Tarea>();
            // Listas para tareas

            string? descripcion;
            Random rand = new Random();

            for (int i = 1; i <= cantTareas; i++)
            {
                do
                {
                    Console.WriteLine($"Ingrese la descripcion de la tarea {i}:");
                    descripcion = Console.ReadLine();
                } while (string.IsNullOrEmpty(descripcion));

               listaTareasPendientes.Add(new Tarea(i, descripcion, rand.Next(10,101)));
            }
            // Se pide al usuario que cargue la descripcion de cada tarea y se añade cada nueva tarea a la lista.

            Console.WriteLine("Lista de tareas pendientes por ahora: ");
            MostrarTareas(listaTareasPendientes);

            Console.WriteLine("======> CONSULTA ESTADO TAREAS: ");
            MoverATareasRealizadas(listaTareasPendientes,listaTareasRealizadas);
            
            Console.WriteLine("======> ESTADO TAREAS: ");

            Console.WriteLine("-> Lista de tareas pendientes: ");
            MostrarTareas(listaTareasPendientes);

            Console.WriteLine("-> Lista de tareas realizadas: ");
            MostrarTareas(listaTareasRealizadas);

            Console.WriteLine($"======> CANTIDAD HORAS TRABAJADAS POR EL EMPLEADO: {CantidadHorasTrabajadas(listaTareasRealizadas)}");

            Console.WriteLine("======> Ingrese las tareas  PENDIENTES que quiere buscar por descripcion: ");

            string? buscar;

            do
            {
                buscar = Console.ReadLine();
            } while (string.IsNullOrEmpty(buscar));

            MostrarTareas(BuscarEnTareasPendientes(listaTareasPendientes,buscar));

            Console.ReadLine();

            return 0;

        }

        public static void MostrarTareas(List<Tarea> listaTareas){
            
            foreach (var tarea in listaTareas)
            {
                Console.WriteLine($"TAREA {tarea.TareaID}");
                Console.WriteLine($"-> Descripcion: {tarea.Descripcion}");
                Console.WriteLine($"-> Duracion: {tarea.Duracion}");
            }

        }

        public static void MoverATareasRealizadas(List<Tarea> listaTareasPendientes, List<Tarea> listaTareasRealizadas){

            int realizada = 0;
            int i = 0;

            while(i < listaTareasPendientes.Count){

                do
                {
                    Console.WriteLine($"TAREA {listaTareasPendientes[i].TareaID}");
                    Console.WriteLine($"-> Descripcion: {listaTareasPendientes[i].Descripcion}");
                    Console.WriteLine($"-> Duracion en horas: {listaTareasPendientes[i].Duracion}");

                    Console.WriteLine("¿La siguiente tarea fue realizada? (1: sí, 0: no)");
                    int.TryParse(Console.ReadLine(), out realizada);

                } while (realizada < 0 || realizada > 1);

                if(realizada == 1){
                    listaTareasRealizadas.Add(listaTareasPendientes[i]);
                    listaTareasPendientes.RemoveAt(i);
                    // En caso de borrar un nodo de la lista, el proximo nodo pasa a la posicion 0 y no debe modificarse el indice.
                } else {
                    i++;
                    // En caso de no borrar un nodo de la lista, se incrementa el indice.
                }

            }

        }

        public static int CantidadHorasTrabajadas(List<Tarea> listaTareasRealizadas){
            
            int CantidadHorasTrabajadas = 0;

            foreach (var tarea in listaTareasRealizadas)
            {   
                CantidadHorasTrabajadas += tarea.Duracion;
                
            }

            return CantidadHorasTrabajadas;

        }

        public static List<Tarea> BuscarEnTareasPendientes(List<Tarea> listaTareasPendientes, string buscar){

            List<Tarea> listaTareasBuscadas = new List<Tarea>();

            foreach (var tarea in listaTareasPendientes)
            {
                if(tarea.Descripcion.Contains(buscar)){
                    listaTareasBuscadas.Add(tarea);
                }
            }

            return listaTareasBuscadas;

        }


    }
}

