using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        //properties -> columns
        // EF knows this is a primary key and serial
        public int id {get; set;}
        
        [Required] //Attribute that is required for the db like NOT NULL in SQL
        public string name {get; set;}

        // ApplicationContext file is like pool, we need to tell it our models exist.


    }
}
