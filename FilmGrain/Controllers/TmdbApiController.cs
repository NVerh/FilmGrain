using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FilmGrain.Models;
using FilmGrain.Models.Film;
using FilmGrain.Models.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FilmGrain.Controllers
{
    public class TmdbApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(string MovieName, int? page)
        {
            if(page != null)
            {
                CallAPIToGetFilm(MovieName, Convert.ToInt32(page));

            }
            FilmViewModel filmViewModel = new FilmViewModel();
            filmViewModel.SearchText = MovieName;
            return View(filmViewModel);
        }
        [HttpPost]
        public IActionResult Index(Models.FilmViewModel FilmViewModel, string searchText)
        {
            if(ModelState.IsValid)
            {
                CallAPIToGetFilm(searchText, 0);
            }
            return View(FilmViewModel);
        }
        public void CallAPIToGetFilm(string searchText, int page)
        {
            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);
            //Calling API https://api.themoviedb.org/3/search/movie?api_key=7fbd33a0ba717ecb076c4c4f2e21f824&language=en-US&page=1&include_adult=false
            string APIkey = "7fbd33a0ba717ecb076c4c4f2e21f824";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/search/movie?api_key=" + APIkey + " &language=en-US&" + "query=" + searchText + "page=" + page + "&include_adult=false") as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.Append("<div class=\"resultDiv\"><p>Names</p>");
                ResponseSearchFilm rootObject = JsonConvert.DeserializeObject<ResponseSearchFilm>(apiResponse);
                foreach(ResultViewModel result in rootObject.Results)
                {
                    string image = result.PosterPath == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.PosterPath;
                    string link = Url.Action("GetFilm", "Film", new {  result.Id });

                    sb.Append("<div class=\"result\" resourceId=\" " + result.Id + "\">" + "<a href=\"" + link + "\"><img src=\"" + image + "\" />" + "<p>" + result.Title + "</a></p></div>");
                }
                ViewBag.Result = sb.ToString();
                int pageSize = 20;
                PagingInfo paginginfo = new PagingInfo();
                paginginfo.CurrentPage = pageNo;
                paginginfo.TotalItems = rootObject.TotalResults;
                paginginfo.ItemsPerPage = pageSize;
                ViewBag.Paging = paginginfo;
            }
        }
    }
}