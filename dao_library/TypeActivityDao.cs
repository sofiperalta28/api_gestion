using System;
using System.Collections.Generic;
using System.Linq;
using entity_library; 
namespace dao_library
{    
    public class TypeActivityDao
    {
        //obtiene la lista de todos los valores definidos en el enum
        public List<string> GetTypeActivities()
        {
            return Enum.GetNames(typeof(TypeActivity)).ToList();
        }
    }
}