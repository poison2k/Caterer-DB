using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
namespace Caterer_DB.Models
{
    public class ListViewModel<T> : IPagedList<T>
    {
        public List<T> Entitäten;

        public ListViewModel()
        {
            Entitäten = new List<T>();
            PageNumber = 1;
            PageSize = 10;
        }

        public ListViewModel(int gesamtZahl, int aktuelleSeite, int seitenGroesse)
        {
            Entitäten = new List<T>();
            TotalItemCount = gesamtZahl;
            PageNumber = aktuelleSeite;
            PageSize = seitenGroesse;
        }

        public ListViewModel(int gesamtZahl, int aktuelleSeite, int seitenGroesse, int kaplBwVersionId)
        {
            Entitäten = new List<T>();
            TotalItemCount = gesamtZahl;
            PageNumber = aktuelleSeite;
            PageSize = seitenGroesse;
            KaplBwVersionId = kaplBwVersionId;
        }

        public ListViewModel(
            int gesamtZahl
            , int aktuelleSeite
            , int seitenGroesse
            , string actionName
            , DateTime gültigAm)
        {
            Entitäten = new List<T>();
            TotalItemCount = gesamtZahl;
            PageNumber = aktuelleSeite;
            PageSize = seitenGroesse;
            ActionName = actionName;
            GültigAm = gültigAm;
        }

        public ListViewModel(
            int gesamtZahl
            , int aktuelleSeite
            , int seitenGroesse
            , DateTime gültigAm)
        {
            Entitäten = new List<T>();
            TotalItemCount = gesamtZahl;
            PageNumber = aktuelleSeite;
            PageSize = seitenGroesse;
            GültigAm = gültigAm;
        }

        public string ActionName { get; set; }
        public string SeitenTitel { get; set; }

        public string SortierSpalte { get; set; }

        public string SortierRichtung { get; set; }

        [DisplayName(@"Gültig am")]
        public DateTime GültigAm { get; set; }

        [DisplayName(@"KAPlBw-Version")]
        public int KaplBwVersionId { get; set; }

        [DisplayName(@"KAPlBw-Version wählen")]
        public SelectList KaplBwVersionen { get; set; }

        public List<string> FehlerListe { get; set; }

        [DisplayName(@"Ansicht wählen")]
        public Dictionary<int, string> Ansicht { get; set; }

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
