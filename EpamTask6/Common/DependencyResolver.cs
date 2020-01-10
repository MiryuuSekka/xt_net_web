using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.BLL.Interface;
using Task6.BLL;

namespace Common
{
    public static class DependencyResolver
    {
        static IMainLogic Logic;

        private static AbstractLogic<User> UserLogic;
        private static AbstractLogic<Award> AwardLogic;
        private static AbstractLogic<AwardWeilders> WeildersLogic;
        

        static public IMainLogic GetLogic()
        {
            return new MainLogic();
        }


        /*
        private static readonly INoteLogic _notesLogic;
        private static readonly INotesDao _notesDao;

        public static INoteLogic NoteLogic => _notesLogic;


        public static INotesDao NotesDao => _notesDao;

        static DependencyResolver()
        {
            _notesDao = new NoteDao();
            _notesLogic = new NotesLogic(_notesDao);
        }*/
    }
}
