using Registro_Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Agregar un cliente
        AgregarCliente();

        // Consultar clientes
        ConsultarClientes();

        // Modificar un cliente
        ModificarCliente();

        Console.ReadLine();
    }

    public static void AgregarCliente()
    {
        Console.WriteLine("Agregar cliente");
        using (var context = new RegistroClienteContext())
        {
            Cliente cliente = new Cliente()
            {
                Nombre = "Maria",
                Apellido = "Lopez",
                Direcci�n = "Sauces",
                Telefono = "444-555",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Estado = "Activo"
            };

            context.Clientes.Add(cliente);
            context.SaveChanges();

            Console.WriteLine("Cliente agregado con �xito. ID: " + cliente.Id);
        }
    }

    public static void ConsultarClientes()
    {
        Console.WriteLine("Consultar clientes");
        using (var context = new RegistroClienteContext())
        {
            List<Cliente> clientes = context.Clientes.ToList();

            foreach (var cliente in clientes)
            {
                Console.WriteLine("ID: " + cliente.Id);
                Console.WriteLine("Nombre: " + cliente.Nombre);
                Console.WriteLine("Apellido: " + cliente.Apellido);
                Console.WriteLine("Direcci�n: " + cliente.Direcci�n);
                Console.WriteLine("Tel�fono: " + cliente.Telefono);
                Console.WriteLine("Fecha de Nacimiento: " + cliente.FechaNacimiento);
                Console.WriteLine("Estado: " + cliente.Estado);
                Console.WriteLine();
            }
        }
    }

    public static void ModificarCliente()
    {
        Console.WriteLine("Modificar cliente");
        using (var context = new RegistroClienteContext())
        {
            Console.WriteLine("Ingrese el ID del cliente para modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente cliente = context.Clientes.Find(id);
            if (cliente != null)
            {
                Console.WriteLine("Nuevo nombre del cliente: ");
                cliente.Nombre = Console.ReadLine();

                Console.WriteLine("Nuevo apellido del cliente: ");
                cliente.Apellido = Console.ReadLine();

                Console.WriteLine("Nueva direcci�n del cliente: ");
                cliente.Direcci�n = Console.ReadLine();

                Console.WriteLine("Nuevo tel�fono del cliente: ");
                cliente.Telefono = Console.ReadLine();

                Console.WriteLine("Nueva fecha de nacimiento del cliente (yyyy-MM-dd): ");
                cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine("Cliente modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}