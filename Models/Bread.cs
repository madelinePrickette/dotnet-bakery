using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // all imports
namespace DotnetBakery.Models //namespace is like the export or what you will export. like a component
{
    // making an enumeration a list
    public enum BreadType
    {
        // These cannot have spaces because it becomes a value
        Sourdough, //0
        Rye, //1
        Pumpernickel, //2
        French, //3
        Tortilla, //4
        HoneyWheat, //5
        Boule, //6
        Pretzel //7
    }


    public class Bread  // new model for bread
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}


        //need a bread type
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type {get; set;}


        public int count {get; set;}

        //relation to the baker
        [ForeignKey ("bakedBy")]
        public int bakedById {get; set;}

        // the actual baker object from the database (using join)
        public Baker bakedBy {get; set;}
    }
}
