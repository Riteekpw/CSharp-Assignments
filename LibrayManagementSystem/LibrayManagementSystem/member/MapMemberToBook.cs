using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.book;

namespace LibrayManagementSystem.member
{
    class MapMemberToBook : IMapMember
    {
        private Dictionary<int, List<int>> map;
        private List<int> list;

        public MapMemberToBook()
        {
            map = new Dictionary<int, List<int>>();
            list = new List<int>();
        }

        public void MapMember(int memberId, int bookId)
        {
                list.Add(bookId);
                map.Add(memberId, list);

        }
        public void RemoveMapping(int memberId,int bookId)
        {
            if(map.ContainsKey(memberId))
            {
                foreach(var id in map[memberId])
                {
                    if (id == bookId)
                    {
                        map[memberId].Remove(bookId);
                        break;
                    }
                }
                Console.WriteLine("Book Returned successfully");
            }
            else
            {
                Console.WriteLine("you are not valid member to return book");
            }

        }

    }
}
