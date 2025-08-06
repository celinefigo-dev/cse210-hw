using System;
using System.Collections.Generic;

namespace YouTubeVideoProgram.Models
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public int Views { get; private set; }
        public int Likes { get; private set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length, int views, int likes)
        {
            Title = title;
            Author = author;
            Length = length;
            Views = views;
            Likes = likes;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void LikeVideo()
        {
            Likes++;
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds");
            Console.WriteLine($"Views: {Views} | Likes: {Likes} | Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                comment.DisplayComment();
            }
            Console.WriteLine("========================================\n");
        }
    }
}