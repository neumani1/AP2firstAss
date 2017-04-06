﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public interface ISearcher<T>
    {
        // the search method
        Solution<T> search(ISearchable<T> searchable);
        void addToOpenList(State<T> state);
        // get how many nodes were evaluated by the algorithm
        int getNumberOfNodesEvaluated();
        Solution<T> backTrace(State<T> goal);
        bool openContaines(State<T> state);
    }
}
