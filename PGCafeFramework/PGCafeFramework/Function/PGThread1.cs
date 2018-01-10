using System;
using System.Threading;

namespace PGCafe {

    /// <summary> Thread static extension method. </summary>
    public static class PGThread {    

        /// <summary>
        /// Start a thread with no argument action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread( Action RunAction ) {
            Thread newThread = new Thread( new ThreadStart( RunAction ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread( Action RunAction )

        /// <summary>
        /// Start a thread with 1 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1>( Action<T1> RunAction, T1 argument1 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1>( Action<T1> RunAction, T1 argument1 )

        /// <summary>
        /// Start a thread with 2 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2>( Action<T1,T2> RunAction, T1 argument1, T2 argument2 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2>( Action<T1,T2> RunAction, T1 argument1, T2 argument2 )

        /// <summary>
        /// Start a thread with 3 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3>( Action<T1,T2,T3> RunAction, T1 argument1, T2 argument2, T3 argument3 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3>( Action<T1,T2,T3> RunAction, T1 argument1, T2 argument2, T3 argument3 )

        /// <summary>
        /// Start a thread with 4 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4>( Action<T1,T2,T3,T4> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4>( Action<T1,T2,T3,T4> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4 )

        /// <summary>
        /// Start a thread with 5 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5>( Action<T1,T2,T3,T4,T5> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5>( Action<T1,T2,T3,T4,T5> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5 )

        /// <summary>
        /// Start a thread with 6 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6>( Action<T1,T2,T3,T4,T5,T6> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6>( Action<T1,T2,T3,T4,T5,T6> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6 )

        /// <summary>
        /// Start a thread with 7 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7>( Action<T1,T2,T3,T4,T5,T6,T7> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7>( Action<T1,T2,T3,T4,T5,T6,T7> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7 )

        /// <summary>
        /// Start a thread with 8 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8>( Action<T1,T2,T3,T4,T5,T6,T7,T8> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8>( Action<T1,T2,T3,T4,T5,T6,T7,T8> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8 )

        /// <summary>
        /// Start a thread with 9 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9 )

        /// <summary>
        /// Start a thread with 10 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10 )

        /// <summary>
        /// Start a thread with 11 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11 )

        /// <summary>
        /// Start a thread with 12 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <typeparam name="T12"> type of Twelfth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <param name="argument12"> Twelfth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12 )

        /// <summary>
        /// Start a thread with 13 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <typeparam name="T12"> type of Twelfth argument. </typeparam>
        /// <typeparam name="T13"> type of Thirteenth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <param name="argument12"> Twelfth argument </param>
        /// <param name="argument13"> Thirteenth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12, argument13 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13 )

        /// <summary>
        /// Start a thread with 14 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <typeparam name="T12"> type of Twelfth argument. </typeparam>
        /// <typeparam name="T13"> type of Thirteenth argument. </typeparam>
        /// <typeparam name="T14"> type of Fourteenth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <param name="argument12"> Twelfth argument </param>
        /// <param name="argument13"> Thirteenth argument </param>
        /// <param name="argument14"> Fourteenth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12, argument13, argument14 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14 )

        /// <summary>
        /// Start a thread with 15 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <typeparam name="T12"> type of Twelfth argument. </typeparam>
        /// <typeparam name="T13"> type of Thirteenth argument. </typeparam>
        /// <typeparam name="T14"> type of Fourteenth argument. </typeparam>
        /// <typeparam name="T15"> type of Fifteenth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <param name="argument12"> Twelfth argument </param>
        /// <param name="argument13"> Thirteenth argument </param>
        /// <param name="argument14"> Fourteenth argument </param>
        /// <param name="argument15"> Fifteenth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14, T15 argument15 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12, argument13, argument14, argument15 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14, T15 argument15 )

        /// <summary>
        /// Start a thread with 16 arguments action.
        /// return a thread that has been start to run.
        /// </summary>
        /// <typeparam name="T1"> type of First argument. </typeparam>
        /// <typeparam name="T2"> type of Second argument. </typeparam>
        /// <typeparam name="T3"> type of Third argument. </typeparam>
        /// <typeparam name="T4"> type of Fourth argument. </typeparam>
        /// <typeparam name="T5"> type of Fifth argument. </typeparam>
        /// <typeparam name="T6"> type of Sixth argument. </typeparam>
        /// <typeparam name="T7"> type of Seventh argument. </typeparam>
        /// <typeparam name="T8"> type of Eighth argument. </typeparam>
        /// <typeparam name="T9"> type of Ninth argument. </typeparam>
        /// <typeparam name="T10"> type of Tenth argument. </typeparam>
        /// <typeparam name="T11"> type of Eleventh argument. </typeparam>
        /// <typeparam name="T12"> type of Twelfth argument. </typeparam>
        /// <typeparam name="T13"> type of Thirteenth argument. </typeparam>
        /// <typeparam name="T14"> type of Fourteenth argument. </typeparam>
        /// <typeparam name="T15"> type of Fifteenth argument. </typeparam>
        /// <typeparam name="T16"> type of Sixteenth argument. </typeparam>
        /// <param name="RunAction"> the action to run with thread. </param>
        /// <param name="argument1"> First argument </param>
        /// <param name="argument2"> Second argument </param>
        /// <param name="argument3"> Third argument </param>
        /// <param name="argument4"> Fourth argument </param>
        /// <param name="argument5"> Fifth argument </param>
        /// <param name="argument6"> Sixth argument </param>
        /// <param name="argument7"> Seventh argument </param>
        /// <param name="argument8"> Eighth argument </param>
        /// <param name="argument9"> Ninth argument </param>
        /// <param name="argument10"> Tenth argument </param>
        /// <param name="argument11"> Eleventh argument </param>
        /// <param name="argument12"> Twelfth argument </param>
        /// <param name="argument13"> Thirteenth argument </param>
        /// <param name="argument14"> Fourteenth argument </param>
        /// <param name="argument15"> Fifteenth argument </param>
        /// <param name="argument16"> Sixteenth argument </param>
        /// <returns> running thread </returns>
        public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14, T15 argument15, T16 argument16 ) {
            Thread newThread = new Thread( new ThreadStart( () => RunAction( argument1, argument2, argument3, argument4, argument5, argument6, argument7, argument8, argument9, argument10, argument11, argument12, argument13, argument14, argument15, argument16 ) ) );
            newThread.Start();
            return newThread;
        } // public static Thread StartNewThread<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16>( Action<T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16> RunAction, T1 argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5, T6 argument6, T7 argument7, T8 argument8, T9 argument9, T10 argument10, T11 argument11, T12 argument12, T13 argument13, T14 argument14, T15 argument15, T16 argument16 )

     } // public static class PGThread


} // namespace PGCafe
