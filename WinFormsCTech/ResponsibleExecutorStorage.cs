using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCTech
{
    public class ResponsibleExecutorStorage
    {
        private List<ResponsibleExecutor> _responsibleExecutorSortedList { get; set; }

        public ResponsibleExecutorStorage()
        {
            _responsibleExecutorSortedList = new List<ResponsibleExecutor>();
        }

        public void Add(ResponsibleExecutor ResponsibleExecutor)
        {
            bool wasInsert = false;
            for(int i = 0; i < _responsibleExecutorSortedList.Count; i++)
            {
                if (wasInsert)
                {
                    break;
                }

                string listName = _responsibleExecutorSortedList[i].Name.ToLower();

                string newName = ResponsibleExecutor.Name.ToLower();

                //Сравнение обращений и РКК при равентсве имён
                if (listName == newName)
                {
                    if(_responsibleExecutorSortedList[i].RKKCount == ResponsibleExecutor.RKKCount)
                    {
                        if(_responsibleExecutorSortedList[i].AppealCount > ResponsibleExecutor.AppealCount)
                        {
                            _responsibleExecutorSortedList.Insert(i, ResponsibleExecutor);
                            wasInsert = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (_responsibleExecutorSortedList[i].RKKCount > ResponsibleExecutor.RKKCount)
                        {
                            _responsibleExecutorSortedList.Insert(i, ResponsibleExecutor);
                            wasInsert = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                //Сравнение имён
                for(int j = 0; j < ResponsibleExecutor.Name.Length; j++)
                {

                    if (listName.Length < j + 1 || listName[j] < newName[j])
                    {
                        break;
                    }
                    if (listName[j] == newName[j])
                    {
                        continue;
                    }
                    if (listName[j] > newName[j])
                    {
                        _responsibleExecutorSortedList.Insert(i, ResponsibleExecutor);
                        wasInsert = true;
                        break;
                    }
                }
            }
            if (!wasInsert)
                _responsibleExecutorSortedList.Add(ResponsibleExecutor);
        }

        public List<ResponsibleExecutor> GetAll()
        {
            List<ResponsibleExecutor> newList = new List<ResponsibleExecutor>(_responsibleExecutorSortedList.Count);
            _responsibleExecutorSortedList.ForEach((item) =>
            {
                newList.Add(new ResponsibleExecutor(item));
            });
            return newList;
        }

        public void IncrementRKK(string name)
        {
            foreach(var executor in _responsibleExecutorSortedList)
            {
                if (executor.Name == name)
                    executor.RKKCountIncrement();
            }
        }

        public void IncrementAppeal(string name)
        {
            foreach (var executor in _responsibleExecutorSortedList)
            {
                if (executor.Name == name)
                    executor.AppealCountIncrement();
            }
        }

        public bool ContainsEmployee(string name)
        {
            foreach (var executor in _responsibleExecutorSortedList)
            {
                if (executor.Name == name)
                    return true;
            }
            return false;
        }

        public long SumRKK()
        {
            return _responsibleExecutorSortedList.Sum(item => item.RKKCount);
        }

        public long SumAppeal()
        {
            return _responsibleExecutorSortedList.Sum(item => item.AppealCount);
        }
    }
}
