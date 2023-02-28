namespace Boss.az
{
    enum status { new1 = 1, read }

    internal class Notification
    {
        #region properties

        private static int ID = 0;

        public int ObjectId;

        public string Content { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Worker Worker { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Vacancy Vacancy { get; set; }

        public DateTime Datetime;

        public status Status = status.new1;

        public bool AcceptedOrNot { get; set; }
        #endregion

        public Notification() { 
        ObjectId= ID++;
        }

        public Notification( string content, Worker worker, Vacancy vacancy)
        {
            ObjectId = ID++;
          
            Content = content;
            Worker = worker;
            Vacancy = vacancy;
            Datetime = DateTime.Now;
        }       

        public override string ToString() => $"Notification Id:{ObjectId} From {Worker} worker\nContent:{Content}\nStatus:{Status}";
    }
}