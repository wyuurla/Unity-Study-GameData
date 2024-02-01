using System.Collections.Generic;

/**
 * @brief Subject
 * @detail 상태 변화가 있을 때마다 옵저버에게 통지하도록 하는 행동패턴.
 * @date 2024-01-30
 * @version 1.0.0
 * @author kij
 */
public class Subject
{
    protected bool m_isNotify = false;
    protected List<IObserver> m_observerList = new List<IObserver>();
      
    public virtual void Clear()
    {
        m_observerList.Clear();
    }

    public virtual void Attach(IObserver _observer)
    {
        if (null == _observer)
            return;

        if (m_observerList.Contains(_observer) == true)
            return;

        m_observerList.Add(_observer);
    }
    
    public virtual void Detach(IObserver _observer)
    {
        if (null == _observer)
            return;

        m_observerList.Remove(_observer);
    }
   
    public void Notify()
    {
        m_isNotify = true;
    }
    
    public virtual void UpdateNotify()
    {
        if (m_isNotify == false)
            return;

        for ( int i=0;i<m_observerList.Count; ++i )
        {
            IObserver _observer = m_observerList[i];
            if (null == _observer)
                continue;
            _observer.Notify(this);
        }

        m_isNotify = false;
    }
}
