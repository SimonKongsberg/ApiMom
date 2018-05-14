using ApiMom.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ApiMom.Controllers
{
    public class ClubsController : UmbracoApiController
    {
        // GET: api/Clubs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clubs/5
        public string Get(int id)
        {
            return "value";
        }



        // POST: api/Clubs
        public void Post([FromBody]string value)
        {
            

        }


        private string urlToPost = "";

        public string JsonPost([FromBody]string urlToPost)
        {
            return this.urlToPost = urlToPost;
        }

        /* public void PostNew([FromBody]string value)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:64311/umbraco/api/clubs/GetAllClubs?id=1071");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"user\":\"test\"," +
                              "\"password\":\"bla\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        } */

        // PUT: api/Clubs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clubs/5
        public void Delete(int id)
        {
        }

        // eg. /umbraco/Api/Clubs/GetClub?id=1071
        /* [System.Web.Http.HttpGet]
        public List<Club> GetClub(int id)
        {
            var cs = Services.ContentService;
            List<Club> res = new List<Club>();
            var clubs = cs.GetChildren(id);

            List<Team> teams = tc.GetTeams(club.Id);
            new Club( var club in clubs);
            {
                Id = club.Id,
                Name = club.Properties["clubTitle"].Value.ToString(),
                Description = club.Properties["clubDescription"].Value.ToString(),
                Teams = teams
            };

        }*/
        // eg. /umbraco/Api/Clubs/GetAllClubs?id=1063
        [System.Web.Http.HttpGet]
        public List<Club> GetAllClubs(int id)
        {

            var cs = Services.ContentService;
            List<Club> allClubs = new List<Club>();
            var clubs = cs.GetChildren(id);
            //var tc = new TeamController();

            foreach (var club in clubs)
            {
               // List<Team> teams = tc.GetTeams(club.Id);

                var c = new Club
                {
                    Id = club.Id,
                    Name = club.Properties["clubTitle"].Value.ToString(),
                    Description = club.Properties["clubDescription"].Value.ToString(),
                    //Teams = teams
                };
                allClubs.Add(c);
            }

            return allClubs;
        }
    }
}

/*
Experimental code down here

    using ApiMom.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace ApiMom.Controllers
{
    public class ClubController : UmbracoApiController
    {
        private readonly IContentService cs;
        //private readonly TeamController tc;

        public ClubController()
        {
            cs = Services.ContentService;
            //tc = new TeamController();
        }

        // eg. /umbraco/Api/Clubs/GetClubs?rootId=1071
        [HttpGet]
        public List<Club> GetClubs(int rootId)
        {
            List<Club> res = new List<Club>();
            var clubs = cs.GetChildren(rootId);


            foreach (var club in clubs)
            {
                //List<Team> teams = tc.GetTeams(club.Id);

                var c = new Club
                {
                    Id = club.Id,
                    Name = club.Properties["clubTitle"].Value.ToString(),
                    Description = club.Properties["clubDescription"].Value.ToString(),
                   // Teams = teams
                };

               /* try
                {
                    string guid = club.Properties["clubLogo"].Value.ToString();
                    var udi = Udi.Parse(guid);
                    var media = Umbraco.GetIdForUdi(udi);
                    var content = Umbraco.Media(media);
                    var imgPath = content.Url;
                    c.ClubLogo = imgPath;
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                >>>>>>>>}*/
                /*<<<<<<<<
res.Add(c);
            }

            return res;
        }

        [HttpGet]
public Club GetClub(int clubId)
{
    var club = cs.GetById(clubId);

    // List<Team> teams = tc.GetTeams(club.Id);

    Club res = new Club
    {
        Id = club.Id,
        Name = club.Properties["clubTitle"].Value.ToString(),
        Description = club.Properties["clubDescription"].Value.ToString(),
        //Teams = teams
    };

    if (club.ContentType.Alias == "club")
    {
        try
        {
            string guid = club.Properties["clubLogo"].Value.ToString();
            var udi = Udi.Parse(guid);
            var media = Umbraco.GetIdForUdi(udi);
            var content = Umbraco.Media(media);
            var imgPath = content.Url;
            // res.ClubLogo = imgPath;
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }

        return res;
    }

    return new Club();

}
    }
}
    */