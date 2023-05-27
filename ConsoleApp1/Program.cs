using System;

  GestorEmpleados empleados = new GestorEmpleados("c:\\tmp\\Empleados.db");
//empleados.CrearTabla();

Empleado empleado1 = new Empleado(1, "John", "Doe", 30, "Gerente", 2400);
Empleado empleado2 = new Empleado(2, "John", "Doe", 30, "Gerente", 2400);
Empleado empleado3 = new Empleado(3, "John", "Doe", 30, "Gerente", 2400);
Empleado empleado4 = new Empleado(4, "John", "Doe", 30, "Gerente", 2400);

empleados.AgregarEmpleado(empleado1);
empleados.AgregarEmpleado(empleado2);
empleados.AgregarEmpleado(empleado3);
empleados.AgregarEmpleado(empleado4);

empleados.ObtenerEmpleados();
//sueldo camposA<<<



empleados.ObtenerEmpleados().ForEach(e => Console.WriteLine($"{ e.Nombre} - {e.Apellido} - {e.Edad} - {e.Cargo} - {e.Sueldo}"));


