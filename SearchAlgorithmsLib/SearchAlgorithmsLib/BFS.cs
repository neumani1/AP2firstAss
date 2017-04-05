﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class BFS<T> : Searcher<T>
    {
        public override Solution search(ISearchable<T> searchable)
        { // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State> closed = new HashSet<State>();
            while (OpenListSize> 0) {
                State n = popOpenList(); // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getIGoallState()))
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State> succerssors= searchable.getAllPossibleStates(n);
                for each (State s in succerssors){
                    if (!closed.Contains(s) && !openContaines(s)){
                        // s.setCameFrom(n);
                        // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else
                    {
                        //...
        }
}
