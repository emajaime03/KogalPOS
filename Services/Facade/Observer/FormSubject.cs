using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Services.Facade.Observer
{
    public class FormSubject : ISubject
    {
        #region "Singleton"				
        private readonly static FormSubject _instance = new FormSubject();

	    public static FormSubject Current
		{
		    get
		    {
			    return _instance;
		    }
        }

        private FormSubject()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify<T>(T value, object data = null)
        {
            foreach (var observer in observers)
            {
                observer.Update(value, data);
            }
        }
    }
}
