namespace com.kpl.jurnal.modul5
{
    using System.Diagnostics.Contracts;
    public class SayaTubeVideo
    {
        private int id { get; }
        private string title { get; }
        private int playCount { get; set; }

        
        public int getPlayCount()
        {
            return playCount;
        }
        public string getTitle()
        {
            return title;
        }

        public SayaTubeVideo(string title)
        {
            Contract.Requires(title != null, "input null!");
            Contract.Requires(title.Length <= 100, "input terlalu panjang!");

            Random random = new();
            this.id = random.Next(99999);
            this.title = title;
            this.playCount = 0;
        }

        public void increasePlayCount(int number)
        {
            Contract.Requires(number <= 10000000, "input terlalu besar!");
            try
            {
                checked
                {
                    this.playCount += number;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void printVideoDetails()
        {
            Console.WriteLine("ID\t\t:" + this.id.ToString());
            Console.WriteLine("Title\t\t:" + this.title);
            Console.WriteLine("Play Count\t:" + this.playCount.ToString());
        }
    }


    public class SayaTubeUser
    {
        private int id { get; }
        private List<SayaTubeVideo> uploadedVideos { get; }
        public string username;

        public SayaTubeUser(string name)
        {
            Random random = new();
            this.id = random.Next(99999);
            this.username = name;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (SayaTubeVideo video in this.uploadedVideos)
            {
                total += video.getPlayCount();

            }
            return total;
        }

        public void addVideo(SayaTubeVideo newVideo)
        {
            
            this.uploadedVideos.Add(newVideo);
        }

        public void printAllVideoPlaycount()
        {
            Console.WriteLine("User\t:" + username);
            int n = 1;
            foreach (SayaTubeVideo video in this.uploadedVideos)
            {
                string tempS = video.getTitle();
                Console.WriteLine("Video "+n+" judul\t:" + tempS);
                n++;
            }
        }
    }

    class main
    {
        public static void Main()
        {
            SayaTubeUser saya = new SayaTubeUser("Aditya Mardi P");
            
            List<string> alist = new List<string> { "Episode IV – A New Hope", "Episode V – The Empire Strikes Back","Episode VI – Return of the Jedi",
                    "Episode I – The Phantom Menace", "Episode II – Attack of the Clones", "Episode III – Revenge of the Sith",
                    "Episode VII – The Force Awakens", "Episode VIII – The Last Jedi", "Episode IX – The Rise of Skywalker",
                    "Rogue One"};

            foreach (string s in alist)
            {
                SayaTubeVideo x = new SayaTubeVideo("Review Film " + s + " oleh Aditya Mardi Pratama");
                saya.addVideo(x);
            }

            saya.printAllVideoPlaycount();
        }
    }
}