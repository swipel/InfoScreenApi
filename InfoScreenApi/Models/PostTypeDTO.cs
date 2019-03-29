using System;
using System.Collections;
using InfoScreenApi.ModelsDal;
using Microsoft.AspNetCore.Mvc;

namespace InfoScreenApi.Models
{
    public class PostTypeDTO
    {
        
        public string Name { get; set; }
        public DateTime Created { get; set; }
          
        public PostTypeDTO(){}
        
        public PostTypeDTO(string name, DateTime created)
        {
            Name = name;
            Created = created;
        }
    }
}