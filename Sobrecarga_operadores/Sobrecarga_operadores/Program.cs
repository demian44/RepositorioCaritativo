using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecarga_operadores
{
	class Program
	{
		static void Main(string[] args)
		{
			Person persona = new Person();
			persona.Id = 8;
			if (persona == 8)
				Console.WriteLine("Son iguales.");
			if (persona != 6)
				Console.WriteLine("Son distintos");

			Console.ReadKey();
		}
		
	}

	public class Person
	{
		private int id;

		public int Id
		{
			get { return this.id; }
			set { this.id = value; }
		}

		// 1. En la firma del metodo "bool" es el tipo de dato que vas a retornar, puede ser booleano o puede
		// ser cualquier otro tipo o clase que vos quieras.
		// 2. Por lo menos uno de los dos parámetros que recibe tiene que ser la clase en la cual estás 
		// sibrecargando el parámetro. (en este caso la clase es Person, una clase que  definí yo)
		public static bool operator ==(Person person, int pepe)
		{
			bool result = false;
			if (person.Id == pepe)
				result = true;

			return result;

		}

		// SIempre que sobrecargas un "==" tenes que sobrecargar un "!="
		public static bool operator !=(Person person, int pepe)
		{
			return !(person == pepe);
		}

		// 3. Podes volver a sobrecargar el operador cambiando los parámetros que recibe  y si querés también
		// el valor de retorno.
		public static bool operator ==(Person person, Person pepe)
		{
			bool result = false;
			if (person.Id == pepe.Id)
				result = true;

			return result;

		}

		// SIempre que sobrecargas un "==" tenes que sobrecargar un "!="
		public static bool operator !=(Person person, Person pepe)
		{
			return !(person == pepe);
		}
	}
}
