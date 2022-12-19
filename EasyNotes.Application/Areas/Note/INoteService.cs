using EasyNotes.Application.Areas.Note.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Application.Areas.Note
{
    public interface INoteService
    {
        int Create(NoteCreateRequest request);
    }
}
