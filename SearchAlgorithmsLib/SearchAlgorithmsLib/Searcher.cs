﻿using System;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {   public SimplePriorityQueue<State<T>> openList;
        private int evaluatedNodes;
        public abstract void addToOpenList(State<T> state);
        public Searcher()
        {
            openList = new SimplePriorityQueue<State<T>>();
            evaluatedNodes = 0;
        }
        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }
        // the search method
        public abstract Solution<T> search(ISearchable<T> searchable);
        // get how many nodes were evaluated by the algorithm
        public abstract int getNumberOfNodesEvaluated();
        public abstract Solution<T> backTrace(State<T> goal);
        public abstract bool openContaines(State<T> state);
    }
}
