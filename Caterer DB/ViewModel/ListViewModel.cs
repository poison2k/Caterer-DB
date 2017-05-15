using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caterer_DB.Models
{
    public class ListViewModel<T> : IPagedList<T>
    {
        public ListViewModel()
        {
            ListViewId = 1;
            Entitäten = new List<T>();
            PageNumber = 1;
            PageSize = 10;
        }

        public ListViewModel(int gesamtZahl, int aktuelleSeite, int seitenGroesse)
        {
            ListViewId = 1;
            Entitäten = new List<T>();
            TotalItemCount = gesamtZahl;
            PageNumber = aktuelleSeite;
            PageSize = seitenGroesse;
            int seitenAnzehl = TotalItemCount / seitenGroesse;
            if (TotalItemCount % seitenGroesse > 0)
            {
                seitenAnzehl++;
            }
            if (seitenAnzehl != aktuelleSeite)
            {
                HasNextPage = true;
            }
            else
            {
                IsLastPage = true;
                HasNextPage = false;
            }
            HasPreviousPage = true;
        }

        [Key]
        public int ListViewId { get; set; }

        public List<T> Entitäten { get; set; }
        public string ActionName { get; set; }
        public string SeitenTitel { get; set; }

        public List<string> FehlerListe { get; set; }

        public int PageCount
        {
            get { return (TotalItemCount + PageSize - 1) / PageSize; }
            private set { }
        }

        public int TotalItemCount { get; private set; }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public bool HasPreviousPage { get; private set; }

        public bool HasNextPage { get; private set; }

        public bool IsFirstPage => PageNumber == 1;

        public bool IsLastPage { get; private set; }

        public int FirstItemOnPage { get; private set; }

        public int LastItemOnPage { get; private set; }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Entitäten.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IPagedList GetMetaData()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { return Entitäten.ToArray()[index]; }
        }
    }
}