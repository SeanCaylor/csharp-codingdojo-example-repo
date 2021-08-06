using System.Collections.Generic;

namespace ASPIntro.Models
{
    public class VideosView
    {
        public List<string> YoutubeVideoIds { get; set; } = new List<string>();
        public int RandomNumber { get; set; }
    }
}