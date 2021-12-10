using System;

/*
 * Division de la estructura del proyecto CRUD Personas y Departamentos:
	Capa DAL: 
		-CRUD_PersonasDef_DAL: 
			Tiene una clase de clsMyConnection que abre y cierra la conexion,
			Gestora, dos clases para hacer CRUD, gestoraPersonas, gestoraDepartamentos y
			Listados, dos clases para hacer la consulta de las listas de personas y departamentos
		-CRUD_PersonasDef_BL: Hace de intermediario entre la capa dal y el viewmodel
		-CRUD_PersonasDef_ASP
			Controllers: 
				HomeController: Contiene todas las llamadas a las vistas con sus actions. Todas las acciones crud si dan error, llaman al Index
				Con TempData["resultado"] = -1, si no dan error, TempData["resultado"] = el resultado de la consulta, el resultado se pasará mediante Viebag a la 
				Vista principal
					-Index(): Muestra la lista si da excepcion, no la muestra y muestra el ViewBag
					-Delete(id): Muetra la vista del borrado, si se pulsa el boton manda a deleteBoton los datos de la persona
					-DeleteBoton(id): borra la persona del id
					-Update: vista del update con los datos de la persona
					-Update(id, persona): accion que actualiza la persona
					Los demas action siguen el mismo esquema. create, create(persona), y details;
			Models: modelos que le hacen falta a mis vistas
				-clsPersonaConDepartamento: hereda de clsPersona e incluye el nombre del departamento
				-clsPersonaTodosDepartamentos: hereda de clsPersonaConDepartamento e incluye el listado completo de departamentos, se utiliza para el action de Update()
			Views: las vistas que quiero mostrar
				-Home: ya que el proyecto solo era de personas, lo he colocado todo en el home
				-Las vistas son Create: Todos los textBoxes necesario para rellenar la persona
						Delete: todos los atributos de la persona con el boton que manda al action de borrar o volver a la vista 
						Detail: todos los atributos de la persona y volver a la vista 
						Index: muestra el listado completo de las personas con su foto
						Update:Todos los textBoxes rellenos con los datos de la persona 
 
			ViewModel:  Esta clase funciona como el intermediario entre el controller y las  bases de datos, es decir le da todos los listados y/o 
					personas necesitados al controller, para que asi el codigo del controller sea lo mas simple
 					 posible. Ademas de ello hace el control de excepciones, porque algunos metodos salen repetidos en el controller, como
					 el getListado o getPersona, y para evitar redundancia de try-catchs, he decidido ponerlos aqui.
  					 Funcionan de manera que si todo ha ido bien devuelven el objeto de manera correcta, pero si ha habido algun problema,
 					devuelven un null. Posteriormente, si el controller ve un null, devuelve el mensaje del error.
		
		-CRUD_PersonasDef_Entidads:
								 clsPersona con atributos, String: nombre, apellido, direccion, . Int: id, idDepartamento, y telefono
								 clsDepartamento: string nombre, int id;

		
		-CRUD_PersonasDef_UWP: 
							Proyecto que lista las personas de una base de datos con todos sus datos de la base de datos, mediante las clases de persistencia, clsDepartamento y clsPersona.
							Utiliza la misma capa dal y capa bl que el proyecto de asp. Las diferencias se encuentran en la capa presente. Diferencias como, clase clsModelsPersona, que podria ser sustituida
							con la funcionalidad de viewModel, pero me ha parecido mucho mas rapido e intuitivo unir la persona con el nombre de su departamento.
							La gran diferencia se encuentra en el viewModel que tiene:
								Utilidades: con la clase converter de dateTime a dateTimeOfset
								DelegateComand: para poder utilizar los comands de todos los botones
								PersonasVM: la clase viewModel. Tiene todas las conexiones con al BL, la lista de personas, lista departamentos y los commands. Hace la consulta de los nombres del departamento
								para cada persona






 * 
 * 
 */


namespace AnalisisDelTrabajo
{
    internal class ElTexto
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
