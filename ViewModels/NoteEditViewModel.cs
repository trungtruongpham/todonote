namespace todonote.ViewModels
{
    public class NoteEditViewModel : NoteCreateViewModel
    {
        public int ID { get; set; }
        public string NewPhotoPath { get; set; }
    }
}