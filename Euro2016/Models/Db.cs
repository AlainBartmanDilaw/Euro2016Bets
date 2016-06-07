using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;
using WebMatrix.Data;


namespace Euro2016.Models
{
    public class Db
    {

        public static IList<MatchResult> MatchResults = new List<MatchResult>();

        public static object Set<T>()
        {
            if (typeof(T) == typeof(MatchResult)) return MatchResults;

            return null;
        }

        public static T Insert<T>(T o) where T : Entity
        {
            ((IList<T>)Set<T>()).Add(o);
            return o;
        }

        public static T Get<T>(int? id) where T : Entity
        {
            var entity = ((IList<T>)Set<T>()).SingleOrDefault(o => o.Idt == id);
            if (entity == null) throw new AwesomeDemoException("this item doesn't exist anymore");
            return entity;
        }

        public static void Update<T>(T o) where T : Entity
        {
            var t = Get<T>(o.Idt);
            t.InjectFrom(o);
        }

        static Db()
        {
            var db = Database.Open("DefaultConnection");
            var selectQueryString = "SELECT * FROM MatchsList ORDER BY Number";

            foreach (var row in db.Query(selectQueryString))
            {
                Insert(new MatchResult { Idt=row.Idt } );
            }

        }

    }
}