using System;
using System.IO;
Dictionary<int,Prestamo> prestamos = new Dictionary<int,Prestamo>();

string ruta = Path.Combine
              (
                 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                 "prestamos.txt"
              );

string opcion;
do
{
    Console.WriteLine("1. Realizar un Prestamo");
    Console.WriteLine("2. ver los Prestamos realizados");
    Console.WriteLine("3. Salir");
    Console.WriteLine();
    Console.Write("ingrese una opcion: ");
    opcion = Console.ReadLine();
    Console.Clear();
    switch (opcion)
    {
        case "1":
            bool error;

            do
            {

            } while (!error);
            break;
    }
    Console.Clear();
} while (opcion!="3");
class Prestamo
{
    private int codigo;
    private string nombre;
    private int carnet;
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
    public int Carnet
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

    public Prestamo(int codigo, string nombre, int carnet, string carrera, string equipoprestado, int cantidad, string estado)
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
}