using EFGetStarted;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new BloggingContext()) { 


            db.Database.EnsureCreated();

        CreateNewBlog(db);

        Console.WriteLine("All Blogs:");

        var blogs = db.Blogs.ToList();

        foreach (var blog in blogs)
        {
            Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");
        }

        //Console.WriteLine("\nBlogs that contain 'dev' in URL:");
        //var filteredBlogs = db.Blogs
        //    .Where(b => b.Url.Contains("dev"))
        //    .ToList();

        //foreach (var blog in filteredBlogs)
        //{
        //    Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");
        //}

        
        //Console.WriteLine("\nBlogs with Posts:");
        //var blogsWithPosts = db.Blogs
        //    .Include(b => b.Posts)
        //    .ToList();

        //foreach (var blog in blogsWithPosts)
        //{
        //    Console.WriteLine($"Blog: {blog.Url}");
        //    foreach (var post in blog.Posts)
        //    {
        //        Console.WriteLine($"   Post Title: {post.Title}");
        //    }
        //}

        
        //var blogToUpdate = db.Blogs.FirstOrDefault(b => b.Url.Contains("dev"));
        //if (blogToUpdate != null)
        //{
        //    blogToUpdate.Url = "https://updated-dev-blog-url.com";
        //    db.SaveChanges();
        //    Console.WriteLine($"\nUpdated Blog URL: {blogToUpdate.Url}");
        //}

        
        //var blogToDelete = db.Blogs.FirstOrDefault(b => b.Url.Contains("updated-dev-blog-url"));
        //if (blogToDelete != null)
        //{
        //    db.Blogs.Remove(blogToDelete);
        //    db.SaveChanges();
        //    Console.WriteLine($"\nDeleted Blog: {blogToDelete.Url}");
        //}

        }
    }

    
    static void CreateNewBlog(BloggingContext db)
    {
        var blog = new Blog
        {
            Url = "https://devblogs.microsoft.com/dotnet"
        };
        db.Blogs.Add(blog);
        db.SaveChanges();

        var post = new Post
        {
            Title = "Hello World with EF Core",
            Content = "This is an introductory post on using EF Core.",
            BlogId = blog.BlogId
        };
        db.Posts.Add(post);
        db.SaveChanges();
        Console.WriteLine("\nAdded a new blog and a post.");

}
}
