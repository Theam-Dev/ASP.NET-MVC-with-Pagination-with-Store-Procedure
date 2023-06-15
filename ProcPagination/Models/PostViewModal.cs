using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcPagination.Models
{
    public class PostViewModal
    {
        public List<Post> posts { get; set; }
        public int nextPage { get; set; }
        public int backBack { get; set; }

    }
}