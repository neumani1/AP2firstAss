﻿using System.Collections.Generic;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// represent the state of the player
    /// </summary>
    /// <typeparam name="T">the generic type</typeparam>
    public class State<T>
    {
        /// <summary>
        /// The state of the player
        /// the state represented by a string
        /// </summary>
        private T state;

        /// <summary>
        /// cost to reach this state (set by a setter)
        /// </summary>
        private double cost;

        /// <summary>
        /// the state we came from to this state (setter)
        /// </summary>
        private State<T> cameFrom;

        /// <summary>
        /// Initializes a new instance of the <see cref="State{T}"/> class.
        /// </summary>
        /// <param name="state">The state.</param>
        public State(T state)
        {
            this.state = state;
        }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public double Cost
        {
            get
            {
                return this.cost;
            }

            set
            {
                this.cost = value;
            }
        }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public State<T> Parent
        {
            get
            {
                return this.cameFrom;
            }

            set
            {
                this.cameFrom = value;
            }
        }

        /// <summary>
        /// Gets or sets my state.
        /// </summary>
        /// <value>
        /// My state.
        /// </value>
        public T myState
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// check if the states are equals
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>true if the states are equal</returns>
        public bool Equals(State<T> s)
        {
            // we overload Object's Equals method
            return this.state.Equals(s.state);
        }

        /// <summary>
        /// return the solution
        /// </summary>
        /// <returns>the solution</returns>
        public Solution<T> BackTrace()
        {
            Solution<T> s = new Solution<T>();
            State<T> thisState = this;
            while (thisState.Parent != null)
            {
                s.Trace.Enqueue(thisState);
                thisState = thisState.Parent;
            }
            s.Trace.Enqueue(thisState);
            return s;
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns></returns>
        public static State<T> getState(T state)
        {
            return StatePool<T>.Instance.GetState(state);
        }

        /// <summary>
        /// control the pool of the existing states 
        /// </summary>
        /// <typeparam name="T">the generic type</typeparam>
        public sealed class StatePool<T>
        {

            /// <summary>
            /// state pool instance 
            /// </summary>
            private static volatile StatePool<T> instance;

            /// <summary>
            /// The synchronize root
            /// </summary>
            private static object syncRoot = new object();

            /// <summary>
            /// pool of states
            /// </summary>
            private Dictionary<T, State<T>> pool;

            /// <summary>
            /// Initializes a new instance of the <see cref="StatePool"/> class.
            /// </summary>
            private StatePool()
            {
                this.pool = new Dictionary<T, State<T>>();
            }

            /// <summary>
            /// Gets the instance.
            /// handel the singleton
            /// </summary>
            /// <value>
            /// The instance.
            /// </value>
            public static StatePool<T> Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (syncRoot)
                        {
                            if (instance == null)
                            {
                                instance = new StatePool<T>();
                            }
                        }
                    }

                    return instance;
                }
            }

            /// <summary>
            /// Gets the state.
            /// </summary>
            /// <param name="state">The state.</param>
            /// <returns>the state</returns>
            public State<T> GetState(T state)
            {
                if (!this.pool.ContainsKey(state))
                {
                    State<T> newState = new State<T>(state);
                    this.pool.Add(state, newState);
                }

                return this.pool[state];
            }
        }
    }
}