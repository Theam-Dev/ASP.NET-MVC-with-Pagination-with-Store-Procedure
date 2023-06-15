using ProcPagination.Data;
using ProcPagination.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcPagination.Controllers
{
    public class PostController : Controller
    {
        readonly PostServie db = new PostServie();
        [HttpPost]
        public ActionResult Index()
        {
            string next = Request.Form["btnSumitNext"];
            string back = Request.Form["btnSumitBack"];
            string nextNumber = Request.Form["nextPage"];
            string backNumber = Request.Form["backBack"];
            int pageIndex = 1;
            int nextNum = 1;
            int backNum = 0;
            if(next == "Next")
            {
                pageIndex = Int16.Parse(nextNumber);
                backNum = pageIndex;
                nextNum = pageIndex += 1;
                
            }
            if(back == "Back")
            {
                var current_page = Int16.Parse(backNumber);
                pageIndex = current_page;
                backNum = current_page - 1;
                nextNum = current_page;
            }
            var data = db.Gets(pageIndex);

            List<Post> posts = new List<Post>();
            foreach (DataRow dr in data.Rows)
            {
                posts.Add(
                    new Post
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Title = Convert.ToString(dr["Title"]),
                        Body = Convert.ToString(dr["Body"])
                    });
            }
            PostViewModal viewModal = new PostViewModal
            {
                posts = posts,
                nextPage = nextNum,
                backBack = backNum
            };

            return View(viewModal);
        }
    }
}