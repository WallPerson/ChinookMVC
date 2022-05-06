using System;
using System.Collections.Generic;
using project;
using Microsoft.EntityFrameworkCore;

namespace DbMVC.Models
{
    public class HomeIndexViewModel
    {
        public string Heading {get; set;}

      //  public IList<Actor> Actors {get; set;}

        public IList<Album> Albums {get;set;}
        public IList<Track> Tracks {get;set;}
        public IList<Artist> Artists {get;set;}
        public int count {get;set;}

        public int? id {get;set;}

        
    }
}