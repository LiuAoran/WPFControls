using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationReplyListBox
{
    public enum ReplyTypes
    { 

    }

    public interface IBaseElement
    {
        public string Name { get; set; }
        public string Date { get; set; }

    }

    public interface IReply: IBaseElement
    {
        public ReplyTypes ReplyType { get; set; }
    }

    public interface IMainElement<TReply>: IBaseElement where TReply: class, IReply
    {
        public string Content { get; set; } 

        public ObservableCollection<TReply> Replies { get; set; }
    }

    public class ReplyListManager: NotifyObject 
    {
        
    }
}
