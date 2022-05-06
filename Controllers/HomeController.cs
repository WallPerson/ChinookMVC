using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DbMVC.Models;
using project;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;




namespace DbMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        Chinook db = new Chinook();

        public HomeController(ILogger<HomeController> logger )
        {
            _logger = logger;
           
            
        }

        public IActionResult Index()
        {
            
                
                
                

            HomeIndexViewModel model = new HomeIndexViewModel() {
                Albums = db.Albums.ToList(),
                Tracks = db.Tracks.ToList(),
                count =0,
            };
            
            return View(model);
        }


public IActionResult GetAlbums()
        {
                  
                /*
                var data = JsonConvert.SerializeObject(db.Albums.ToList());
                return Json(new{data = db.Albums});
*/          return null;
        }





/*static bool AddAlbum(string name)
{
 using (var db = new Chinook())
 {
 var newAlbum = new Album
 {
Title = name
 };
 // mark product as added in change tracking
 db.Albums.Add(newAlbum);
 // save tracked change to database
 int affected = db.SaveChanges();
 return (affected == 1);
 }



}*/

public IActionResult Edit(int id)
        {

using (var db = new Chinook()){
Album albumSelect = db.Albums.FirstOrDefault(a => a.AlbumID == id);
        Album model = new Album {
            AlbumID = id,
            Title = albumSelect.Title,
            ArtistID = albumSelect.ArtistID,
        };
            return View(model);
        
        }
        }
[HttpPost]
    public IActionResult Edit(Album album)
    {
        
       
     var exist = db.Albums.Where(x => x.AlbumID == album.AlbumID).FirstOrDefault();

            
            if(exist != null)
            {
                exist.AlbumID = album.AlbumID;
                exist.ArtistID = album.ArtistID;
                exist.Title = album.Title;
                
            }


        db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
        
    }


 public IActionResult Details(int id)
        {
            IList<Track> t = db.Tracks.ToList();
            Album albumSelect = db.Albums.FirstOrDefault(a => a.AlbumID == id);
        Detail model = new Detail {
            AlbumID = id,
            Title = albumSelect.Title,
            ArtistID = albumSelect.ArtistID,
            Name =  db.Artists.FirstOrDefault(a => a.ArtistID == albumSelect.ArtistID).Name,
            AlbumTracks = db.Tracks.ToList(),
        };
        
       


            return View(model);
            
        }


public IActionResult TrackDetails(int id)
        {
            IList<Track> t = db.Tracks.ToList();
            Track trackSelect = db.Tracks.FirstOrDefault(a => a.TrackID == id);
        Track model = new Track {
                   TrackID = id,
            Name = trackSelect.Name,
            AlbumID = trackSelect.AlbumID,
            MediaTypeID = trackSelect.MediaTypeID,
            GenreID = trackSelect.GenreID,
            Composer = trackSelect.Composer,
            Milliseconds = trackSelect.Milliseconds,
            Bytes = trackSelect.Bytes,
            UnitPrice = trackSelect.UnitPrice,
        };
        
       


            return View(model);
            
        }





public IActionResult Create(int id)
        {

        Album model = new Album {

        };
            return View(model);
        
        
        }
[HttpPost]
    public IActionResult Create(Album album)
    {
        
       
        
       db.Albums.Add(album);
        db.SaveChanges();
        
    
        
        return RedirectToAction(nameof(Index));
        
    
    }


public IActionResult CreateArtist(int id)
        {

        Artist model = new Artist {

        };
            return View(model);
        
        
        }
[HttpPost]
    public IActionResult CreateArtist(Artist artist)
    {
        
       
        
       db.Artists.Add(artist);
        db.SaveChanges();
        
    
        
        return RedirectToAction(nameof(Index));
        
    
    }




public IActionResult CreateTrack(int id)
        {

        Track model = new Track {
            AlbumID = id,
        };
            return View(model);
        
        
        }
[HttpPost]
    public IActionResult CreateTrack(Track track)
    {
        
       
        
       db.Tracks.Add(track);
        db.SaveChanges();
        
    
        
        return RedirectToAction(nameof(Index));
        
    
    }






public IActionResult Delete(int id)
        {
            Album model = db.Albums.FirstOrDefault(a => a.AlbumID == id);

            return View(model);
        
        
        }
[HttpPost]
    public IActionResult Delete(Album model)
    {
        
       
        
       db.Albums.Remove(model);
        db.SaveChanges();
        
    
        
        return RedirectToAction(nameof(Index));
        
    
    }


public IActionResult DeleteTrack(int id)
        {
            Track model = db.Tracks.FirstOrDefault(a => a.TrackID == id);

            return View(model);
        
        
        }
[HttpPost]
    public IActionResult DeleteTrack(Track model)
    {
        
       
        
       db.Tracks.Remove(model);
        db.SaveChanges();
        
    
        
        return RedirectToAction(nameof(Index));
        
    
    }

public IActionResult EditArtist(int id)
        {

using (var db = new Chinook()){
Artist artistSelect = db.Artists.FirstOrDefault(a => a.ArtistID == id);
        Artist model = new Artist {
            ArtistID = id,
            Name = artistSelect.Name,
        };
            return View(model);
        
        }
        }
[HttpPost]
    public IActionResult EditArtist(Artist artist)
    {
        
       
     var exist = db.Artists.Where(x => x.ArtistID == artist.ArtistID).FirstOrDefault();

            
            if(exist != null)
            {
                
                exist.ArtistID = artist.ArtistID;
                exist.Name = artist.Name;
                
            }


        db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
        
    }



public IActionResult EditTrack(int id)
        {

using (var db = new Chinook()){
Track trackSelect = db.Tracks.FirstOrDefault(a => a.TrackID == id);
        Track model = new Track {
            TrackID = id,
            Name = trackSelect.Name,
            AlbumID = trackSelect.AlbumID,
            MediaTypeID = trackSelect.MediaTypeID,
            GenreID = trackSelect.GenreID,
            Composer = trackSelect.Composer,
            Milliseconds = trackSelect.Milliseconds,
            Bytes = trackSelect.Bytes,
            UnitPrice = trackSelect.UnitPrice,
        };
            return View(model);
        
        }
        }
[HttpPost]
    public IActionResult EditTrack(Track track)
    {
        
       
     var exist = db.Tracks.Where(x => x.TrackID == track.TrackID).FirstOrDefault();

            
            if(exist != null)
            {


            exist.TrackID = track.TrackID;
            exist.Name = track.Name;
            exist.AlbumID = track.AlbumID;
            exist.MediaTypeID = track.MediaTypeID;
            exist.GenreID = track.GenreID;
            exist.Composer = track.Composer;
            exist.Milliseconds = track.Milliseconds;
            exist.Bytes = track.Bytes;
            exist.UnitPrice = track.UnitPrice;
                
            }


        db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
        
    }








        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
