using System.Collections.Generic;
using System.Linq;
using entity_library; 

namespace dao_library
{
    public class PersonDao
    {
        //busca una persona específica según su Id
        public Person? GetStudent(Person person)
        {
            return MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id); 
        }

        //agrega una nueva persona a la lista y le asigna un nuevo id
        public Person? PostPerson(Person person)
        {
            if (person != null)
            {
                //genera el id automáticamente
                person.Id = MockDatabase.Persons.Count + 1;
                MockDatabase.Persons.Add(person);
                return person; 
            }
            return null;
        }

        //modifica los datos de una persona existente por su id
        public Person? PutPerson(Person person)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {   
                //actualiza los valores
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                existingPerson.Dni = person.Dni;
                return existingPerson; //retorna null si la persona no existia
            }
            return null; 
        }

        public List<Person> GetPerson()
        {
            return MockDatabase.Persons; 
        }

        //elimina una persona de la lista si existe
        public bool DeletePerson(Person person)
        {
            var existingPerson = MockDatabase.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                MockDatabase.Persons.Remove(existingPerson);
                return true; //retorna verdadero si se elimino con éxito
            }
            return false; //retorna falso si no existia
        }
    }
}