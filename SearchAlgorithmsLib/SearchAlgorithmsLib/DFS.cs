﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class DFS<T> : Searcher<T>
    {
        public Stack<State<T>> stack = new Stack<State<T>>();
        public override void addToOpenList(State<T> state)
        {
            stack.Push(state);
        }

        public override int getNumberOfNodesEvaluated()
        {
            return stack.Count;//////
        }

        public override Solution<T> search(ISearchable<T> searchable)
        {
            stack.Push(searchable.getInitialState());
            while (stack.Count != 0)
            {
                State<T> thisState = stack.Pop();

            }
        }
    }
}
