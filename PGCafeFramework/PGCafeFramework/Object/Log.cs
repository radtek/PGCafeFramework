#pragma warning disable CS1591
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGCafe.Object {

    public class Log {
        class Cell {            
            DateTime Time;
            string Message;

            public static implicit operator Cell( string message ) {
                return new Cell { Time = DateTime.Now, Message = message };
            } // public static implicit operator Cell( string message )

            public override string ToString() {
                return string.Format( "[{0:HH:mm:ss.fff}] - {1}", Time, Message );
            } // public override string ToString()
        } // class Cell


        public enum Type {
            User,
            Inner,
            Debug,
        } // public enum Type


        public event Action<string> LogAppended;
        public event Action<string> DebugLogAppended;

        private List<Cell> mLogs = new List<Cell>();
        private List<Cell> mUnRaiseLog = new List<Cell>();        
        private System.Threading.Timer mSaveLogsTimer;

        /// <summary> File path to save the log, format it by date. EX: log-{0:yyyy-MM-dd}.log </summary>
        public string SavePath { get; private set; } = null; //@".\Logs\{0:yyyy-MM-dd}.log";

        /// <summary> Create without save path's log. </summary>
        public Log() {}

        /// <summary> Create by Save Path. </summary>
        /// <param name="Path"> File path to save the log, format it by date. EX: log-{0:yyyy-MM-dd}.log </param>
        /// <param name="AutoSavePeriod"> Period of auto save log to file. Unit: millisecond. </param>
        public Log( string Path, int AutoSavePeriod = 60000 ) {
            this.SavePath = Path;
            mSaveLogsTimer = new System.Threading.Timer( SaveLogsTimer_TimesUp, null, AutoSavePeriod, AutoSavePeriod );
        } // public Log( string Path, int AutoSavePeriod = 60000 )

        #region Add Logs

        /// <summary>
        /// If error code == 0, add success message to log, else add error message by error code.
        /// Return error code == 0.
        /// </summary>
        public void Add( Type logType, string log ) {
            Cell newLog = log;
            lock ( mLogs ) {
                mLogs.Add( newLog );
            } // lock

            switch ( logType ) {
                case Type.User:
                    LogAppended?.Invoke( newLog.ToString() );
                    break;
                case Type.Debug:
                    DebugLogAppended?.Invoke( newLog.ToString() );
                    break;
            } // switch

        } // public void Add( Type logType, string log )

        /// <summary>
        /// If error code == 0, add success message to log, else add error message by error code.
        /// Return error code == 0.
        /// </summary>
        public void AddAndShow( Type logType, string log, MsgType MsgBoxType, MessageBoxDefaultButton MsgBoxDefaultButton = MessageBoxDefaultButton.Button1 ) {
            Cell newLog = log;
            lock ( mLogs ) {
                mLogs.Add( newLog );
            } // lock

            PGMessageBox.Show( log, MsgBoxType, MsgBoxDefaultButton );

            if ( logType == Type.User )
                LogAppended?.Invoke( newLog.ToString() );

        } // public void AddAndShow( Type logType, string log, MessageBoxEXType MsgBoxType, MessageBoxDefaultButton MsgBoxDefaultButton = MessageBoxDefaultButton.Button1 )

        
        /// <summary> Save log to file now. </summary>
        public void SaveLog() {
            SaveLogsTimer_TimesUp();
        } // public void SaveLog()

        #endregion
        

        #region Auto Save Logs

        private int mLastSaveLogsCount = 0;
        private void SaveLogsTimer_TimesUp( object state = null ) {

            // if no logs or no new log after last save, do nothing.
            if ( mLogs.Count == 0 || mLogs.Count == mLastSaveLogsCount ) return ;

            // else save logs to file.
            IEnumerable<string> newLogs;
            lock ( mLogs ) {
                newLogs = mLogs.Skip( mLastSaveLogsCount ).Select( item => item.ToString() );

                string fileName = string.Format( this.SavePath, DateTime.Now );
                try { // try write to file.
                    Directory.CreateDirectory( Path.GetDirectoryName( this.SavePath ) );
                    File.AppendAllLines( fileName, newLogs );

                    // after add log, clear logs to avoid next save will save same log.
                    mLogs.Clear();
                } catch ( Exception ex ) {
                    this.Add( Type.Inner, $"Save Log failed [File:{fileName}] [Error:{ex.Message}]" );
                } // try-catch

            } // lock
        } // private static void SaveLogsTimer_TimesUp( object state )

        #endregion


    } // public class Log
}
