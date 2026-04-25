using System;
using System.IO;
Dictionary<int,Prestamo> prestamos = new Dictionary<int,Prestamo>();

string ruta = Path.Combine
              (
                 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                 "prestamos.txt"
              );
int codigo = 0;
string opcion;
do
{
    Console.WriteLine("1. Realizar un Prestamo");
    Console.WriteLine("2. ver los Prestamos realizados");
    Console.WriteLine("3. Buscar prestamo");
    Console.WriteLine("4. eliminar registros");
    Console.WriteLine("5. Salir");
    Console.WriteLine();
    Console.Write("ingrese una opcion: ");
    opcion = Console.ReadLine();
    Console.Clear();
    switch (opcion)
    {
        case "1":
            bool error;
            int cantidad = 0 ;
            string nombre, carrera,equipoPrestado, estado; 
            long carnet;
            do
            {
                Console.WriteLine("ingrese los datos del prestamista: ");
                Console.WriteLine();
                codigo++;
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                do
                {
                    Console.Write("Carnet: ");
                    error = long.TryParse(Console.ReadLine(), out carnet);
                } while (!error);

                do
                {
                    Console.WriteLine("seleccione su carrera:  ");
                    Console.WriteLine();
                    Console.WriteLine("1. sistemas");
                    Console.WriteLine("2. telecomunicaciones");
                    Console.WriteLine("3. industrial");
                    Console.WriteLine();
                    Console.Write("ingrese una opcion: ");
                    carrera = Console.ReadLine();

                    switch (carrera)
                    {
                        case "1":
                            carrera = "Sistemas";
                            error = true;
                            break;
                        case "2":
                            carrera = "telecomunicaciones";
                            error = true;
                            break;
                        case "3":
                            carrera = "industrial";
                            error = true;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("esto es un campo obligatorio");
                            Console.WriteLine();
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadLine();
                            error = false;
                            Console.Clear();
                            break;
                    }
                } while (!error);

                Console.WriteLine();

                Console.Write("producto Prestado: ");
                equipoPrestado = Console.ReadLine();

                do
                {
                    Console.Write("cantidad prestada: ");
                    error = int.TryParse(Console.ReadLine(), out cantidad);
                } while (!error);

                estado = "activo";
                Console.WriteLine();
                try
                {
                    Prestamo p1 = new Prestamo(codigo,nombre,carnet,carrera,equipoPrestado,cantidad,estado);
                    p1.GuardarEnArchivo(ruta);
                    prestamos.Add(codigo, p1);
                    error = true;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("presione enter para continuar");
                    Console.ReadLine();
                    error = false;
                    Console.Clear();
                }
            } while (!error);
            
            Console.WriteLine("datos guardados con exito");
            Thread.Sleep(2000);
            break;
        case "2":
            Console.WriteLine("registros de prestamos: ");
            Console.WriteLine();
            foreach (KeyValuePair<int, Prestamo> p in prestamos)
            {
                p.Value.mostrarDatos();
            }
            Console.WriteLine("Presione enter para continuar");
            Console.ReadLine();
            break;
    }
    Console.Clear();
} while (opcion!="5");
class Prestamo
{
    private int codigo;
    private string nombre;
    private long carnet;
    private string carrera;
    private string equipoPrestado;
    private int cantidad;
    private string estado;

    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }
    public string Nombre
    {
        get {  return nombre; }
        set 
        {
            if (value.Length > 2) nombre = value;
            else throw new Exception("el nombre debe contener al menos 3 caracteres");
        }
    }
    public long Carnet
    {
        get { return carnet; }
        set 
        {
            if (value.ToString().Length == 8) carnet = value;
            else throw new Exception("el carnet debe contener 8 digitos");
        }
    }
    public string Carrera
    {
        get { return carrera; }
        set { carrera= value; }
    }

    public string Equipoprestado
    {
        get { return equipoPrestado; }
        set { equipoPrestado = value; }
    }
    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }
    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public Prestamo(int codigo, string nombre, long carnet, string carrera, string equipoprestado, int cantidad, string estado)
    {
        Codigo = codigo;
        Nombre = nombre;
        Carnet = carnet;
        Carrera = carrera;
        Equipoprestado = equipoprestado;
        Cantidad = cantidad;
        Estado = estado;
    }

    public string ObtenerDatos()
    {
        return "codigo: " + Codigo + Environment.NewLine +
               "Nombre: " + Nombre + Environment.NewLine +
               "carnet: " + Carnet + Environment.NewLine +
               "carrera: " + Carrera + Environment.NewLine +
               "equipo Prestado: " + Equipoprestado + Environment.NewLine +
               "cantidad: " + Cantidad + Environment.NewLine +
               "estado: " + Estado + Environment.NewLine+
               "------------------------------------------"+ Environment.NewLine;
    }

    public void GuardarEnArchivo(string ruta)
    {
        File.AppendAllText(ruta, ObtenerDatos());
    }

    public void mostrarDatos()
    {
        Console.WriteLine("codigo: "+Codigo);
        Console.WriteLine("nombre: "+Nombre);
        Console.WriteLine("carnet: "+Carnet);
        Console.WriteLine("carrera: "+Carrera);
        Console.WriteLine("equipo Prestado: "+Equipoprestado);
        Console.WriteLine("cantidad: "+Cantidad);
        Console.WriteLine("Estado: "+Estado);
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine();
    }
}