using System;
using System.Collections.Generic;

namespace RegistrosSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mantenimiento mant = new Mantenimiento();

            Console.WriteLine("¿Desea operar sobre algún registro? S/N");
            string respuesta = Console.ReadLine();
            string respuesta1 = respuesta.ToUpper();
            while (respuesta1 == "S")
            {
                Console.WriteLine("¿Qué desea hacer?\n 1) Ingresar registro.\n 2) Leer registro.\n 3) Modificar registro.\n 4) Borrar registro.\n 5) Leer todos los registros.\n Marque el número de la opción deseada:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("¿Desea ingresar un registro? S/N");
                        string resp = Console.ReadLine();
                        string resp1 = resp.ToUpper();
                        while (resp1 == "S")
                        {
                            Console.WriteLine("Ingrese DNI");
                            string dni = Console.ReadLine();
                            Evaluacion ev7 = new Evaluacion("0", "0", "0", dni);
                            int cert = ev7.MandarDNI();
                            while (cert < 1 || cert > 100000000)
                            {
                                Console.WriteLine("Reingrese DNI");
                                dni = Console.ReadLine();
                                Evaluacion ev8 = new Evaluacion("0", "0", "0", dni);
                                cert = ev8.MandarDNI();
                            }
                            Persona persona = new Persona();
                            persona = mant.Leer(dni);
                            string confirm = persona.dni;
                            if (confirm != null)
                            {
                                Console.WriteLine("Registro ya existente");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese nombre y apellido");
                                string name = Console.ReadLine();
                                string name1 = name.ToUpper();

                                Console.WriteLine("Ingrese domicilio");
                                string address = Console.ReadLine();
                                string address1 = address.ToUpper();

                                Console.WriteLine("Ingrese día de nacimiento");
                                string dia = Console.ReadLine();
                                Evaluacion ev5 = new Evaluacion("0", "0", dia, "0");
                                int day = ev5.MandarDia();

                                while (day < 1 || day > 31)
                                {
                                    Console.WriteLine("Reingrese día de nacimiento (entre 1 y 31)");
                                    dia = Console.ReadLine();
                                    Evaluacion ev6 = new Evaluacion("0", "0", dia, "0");
                                    day = ev6.MandarDia();
                                }

                                Console.WriteLine("Ingrese mes de nacimiento");
                                string mes = Console.ReadLine();
                                Evaluacion ev3 = new Evaluacion("0", mes, "0", "0");
                                int month = ev3.MandarMes();

                                while (month < 1 || month > 12)
                                {
                                    Console.WriteLine("Reingrese mes de nacimiento (entre 1 y 12)");
                                    mes = Console.ReadLine();
                                    Evaluacion ev4 = new Evaluacion("0", mes, "0", "0");
                                    month = ev4.MandarMes();
                                }

                                Console.WriteLine("Ingrese año de nacimiento");
                                string agno = Console.ReadLine();
                                Evaluacion ev1 = new Evaluacion(agno, "0", "0", "0");
                                int year = ev1.MandarAgno();

                                if (year < 1900 || year > 2022)
                                {
                                    while (year < 1900 || year > 2022)
                                    {
                                        Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                        agno = Console.ReadLine();
                                        Evaluacion ev2 = new Evaluacion(agno, "0", "0", "0");
                                        year = ev2.MandarAgno();
                                    }
                                }

                                DateTime date1 = new DateTime(year, month, day);

                                Persona pers = new Persona();
                                pers.nombre = name1;
                                pers.domicilio = address1;
                                pers.fecha = date1;
                                pers.dni = dni;

                                mant.Alta(pers);
                            }

                            Console.WriteLine("¿Desea ingresar otro registro? S/N");
                            resp = Console.ReadLine();
                            resp1 = resp.ToUpper();
                        }
                        break;
                    case 2:
                        Console.WriteLine("¿Busca algún registro en particular? S/N");
                        resp = Console.ReadLine();
                        resp1 = resp.ToUpper();
                        if (resp1 == "S")
                        {
                            Console.WriteLine("Ingrese DNI:");
                            string dni = Console.ReadLine();
                            Persona per = new Persona();
                            per = mant.Leer(dni);
                            Console.WriteLine($"Nombre: {per.nombre}. Domicilio: {per.domicilio}. Fecha: {per.fecha}.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("¿Desea modificar algún registro? S/N");
                        resp = Console.ReadLine();
                        resp1 = resp.ToUpper();
                        if (resp1 == "S")
                        {
                            Console.WriteLine("Ingrese DNI:");
                            string dni = Console.ReadLine();
                            Persona pers = new Persona();
                            pers = mant.Leer(dni);
                            Console.WriteLine($"Nombre: {pers.nombre}. Domicilio: {pers.domicilio}. Fecha: {pers.fecha}.");

                            Console.WriteLine("¿Qué campo desea modificar?\n 1) Nombre.\n 2) Domicilio.\n 3) Fecha de nacimiento.\n Marque el número de la opción deseada:");
                            int opcion = int.Parse(Console.ReadLine());

                            switch (opcion)
                            {
                                case 1:
                                    Console.WriteLine("Ingrese nombre y apellido:");
                                    string name = Console.ReadLine();
                                    string name1 = name.ToUpper();
                                    mant.ModificarNombre(dni, name1);
                                    break;

                                case 2:
                                    Console.WriteLine("Ingrese domicilio:");
                                    string address = Console.ReadLine();
                                    string address1 = address.ToUpper();
                                    mant.ModificarDomicilio(dni, address1);
                                    break;

                                case 3:
                                    Console.WriteLine("Ingrese día de nacimiento");
                                    string dia = Console.ReadLine();
                                    Evaluacion ev5 = new Evaluacion("0", "0", dia, "0");
                                    int day = ev5.MandarDia();

                                    if (day < 1 || day > 31)
                                    {
                                        while (day < 1 || day > 31)
                                        {
                                            Console.WriteLine("Reingrese día de nacimiento (entre 1 y 31)");
                                            dia = Console.ReadLine();
                                            Evaluacion ev6 = new Evaluacion("0", "0", dia, "0");
                                            day = ev6.MandarDia();
                                        }
                                    }

                                    Console.WriteLine("Ingrese mes de nacimiento");
                                    string mes = Console.ReadLine();
                                    Evaluacion ev3 = new Evaluacion("0", mes, "0", "0");
                                    int month = ev3.MandarMes();

                                    if (month < 1 || month > 12)
                                    {
                                        while (month < 1 || month > 12)
                                        {
                                            Console.WriteLine("Reingrese mes de nacimiento (entre 1 y 12)");
                                            mes = Console.ReadLine();
                                            Evaluacion ev4 = new Evaluacion("0", mes, "0", "0");
                                            month = ev4.MandarMes();
                                        }
                                    }

                                    Console.WriteLine("Ingrese año de nacimiento");
                                    string agno = Console.ReadLine();
                                    Evaluacion ev1 = new Evaluacion(agno, "0", "0", "0");
                                    int year = ev1.MandarAgno();

                                    if (year < 1900 || year > 2022)
                                    {
                                        while (year < 1900 || year > 2022)
                                        {
                                            Console.WriteLine("Reingrese año de nacimiento (entre 1900 y 2022)");
                                            agno = Console.ReadLine();
                                            Evaluacion ev2 = new Evaluacion(agno, "0", "0", "0");
                                            year = ev2.MandarAgno();
                                        }
                                    }

                                    DateTime date1 = new DateTime(year, month, day);
                                    mant.ModificarFecha(dni, date1);
                                    break;

                                default:
                                    Console.WriteLine("Opción incorrecta");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("¿Desea borrar un registro? S/N");
                        resp = Console.ReadLine();
                        resp1 = resp.ToUpper();
                        while (resp1 == "S")
                        {
                            Console.WriteLine("Ingrese el DNI del registro que desea borrar:");
                            string dni = Console.ReadLine();
                            mant.Borrar(dni);
                            Console.WriteLine("¿Desea borrar otro registro? S/N");
                            resp = Console.ReadLine();
                            resp1 = resp.ToUpper();
                        }
                        break;
                    case 5:
                        Console.WriteLine("¿Desea leer los registros almacenados? S/N");
                        resp = Console.ReadLine();
                        resp1 = resp.ToUpper();
                        if (resp1 == "S")
                        {
                            List<Persona> list = new List<Persona>();
                            list = mant.LeerTodo();
                            foreach (Persona pers in list)
                            {
                                Console.WriteLine($"DNI: {pers.dni}. Nombre: {pers.nombre}. Domicilio: {pers.domicilio}. Fecha: {pers.fecha}.");
                            }
                            if (list.Count == 0)
                            {
                                Console.WriteLine("No hay registros almacenados.");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;

                }
                Console.WriteLine("¿Desea operar sobre algún registro? S/N");
                respuesta = Console.ReadLine();
                respuesta1 = respuesta.ToUpper();
            }
            Console.WriteLine("Programa finalizado.");
        }
    }
}
