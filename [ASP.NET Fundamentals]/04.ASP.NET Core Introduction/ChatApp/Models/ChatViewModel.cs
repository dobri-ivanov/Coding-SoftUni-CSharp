namespace ChatApp.Models
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            this.Messages = new List<MessageViewModel>();
        }
        public MessageViewModel CurrentMessage { get; set; } = null!;
        public List<MessageViewModel> Messages { get; set; } = null!;
    }
}
