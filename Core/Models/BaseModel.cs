using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    var changed = PropertyChanged;

        //    if (changed == null)
        //        return;

        //    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
