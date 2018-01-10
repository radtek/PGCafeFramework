using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PGCafe.Object {
    

    /// <summary>
    /// Handle Clipboard changed event.
    /// Call static method "StartWatch" to add Action
    /// and Call static method "StopWatch" to remove Action when do not use.
    /// </summary>
    [DefaultEvent("ClipboardChangedEvent")]
    public class ClipboardWatcher : Control {
        
        #region static field
        
        [DllImport( "User32.dll", CharSet = CharSet.Auto, SetLastError=true )]
        private static extern IntPtr SetClipboardViewer( IntPtr hWnd );

        [DllImport( "User32.dll", CharSet = CharSet.Auto, SetLastError=true )]
        private static extern bool ChangeClipboardChain( IntPtr hWndRemove, IntPtr hWndNewNext );
        
        /// <summary>
        /// Handle Clipboard Changed Event from user.
        /// when clipboar changed, call this event.
        /// </summary>
        private static event Action mClipboardChangedEvent_static;

        /// <summary>
        /// create one static control to handle windows message.
        /// </summary>
        private static ClipboardWatcher mClipboardWatcherInstance = null;

        /// <summary>
        /// when stop clipboard watcher from windows, set handle to next handle, so save pre handle's ptr.
        /// </summary>
        private static IntPtr ClipboardViewerNext = IntPtr.Zero;
        

        /// <summary>
        /// Start watch clipboard with Action.
        /// return true success.
        /// </summary>
        /// <param name="ClipboardChangedMethod">The method to call when clipboard changed.</param>
        public static void StartWatch( Action ClipboardChangedMethod ) {
            if ( mClipboardWatcherInstance == null ){ // if no regist before, regist it.
                mClipboardWatcherInstance = new ClipboardWatcher( true );
                ClipboardViewerNext = SetClipboardViewer( mClipboardWatcherInstance.Handle );
            } // if
            
            // else add method to Event.
            mClipboardChangedEvent_static += ClipboardChangedMethod;
        } // private static extern IntPtr SetClipboardViewer( IntPtr hWnd ); [DllImport( "User32.dll", CharSet = CharSet.Auto, SetLastError=true )] private static extern bool ChangeClipboardChain( IntPtr hWndRemove, IntPtr hWndNewNext ); /// <summary> /// Handle Clipboard Changed Event from user. /// when clipboar changed, call this event. /// </summary> private static event Action mClipboardChangedEvent_static; /// <summary> /// create one static control to handle windows message. /// </summary> private static ClipboardWatcher mClipboardWatcherInstance = null; /// <summary> /// when stop clipboard watcher from windows, set handle to next handle, so save pre handle's ptr. /// </summary> private static IntPtr ClipboardViewerNext = IntPtr.Zero; /// <summary> /// Start watch clipboard with Action. /// return true success. /// </summary> /// <param name="ClipboardChangedMethod">The method to call when clipboard changed.</param> public static void StartWatch( Action ClipboardChangedMethod )

        


        /// <summary>
        /// Stop watch clipboard with Action.
        /// </summary>
        /// <param name="ClipboardChangedMethod">The method to remove.</param>
        public static void StopWatch( Action ClipboardChangedMethod ) {
            // remove method.
            mClipboardChangedEvent_static -= ClipboardChangedMethod;

            // if no more method in event and has regist, unregist clipboard handle.
            if ( mClipboardChangedEvent_static == null && mClipboardWatcherInstance != null ) {
                ChangeClipboardChain( mClipboardWatcherInstance.Handle, ClipboardViewerNext );
                mClipboardWatcherInstance = null;
            } // if
        } // public static void StopWatch( Action ClipboardChangedMethod )

        /// <summary>
        /// When clipboard changed, call method in event.
        /// </summary>
        private static void OnClipboardChanged_static() {
            if ( mClipboardChangedEvent_static != null ) mClipboardChangedEvent_static();
        } // private static void OnClipboardChanged_static()

        #endregion


        #region non static field
        

        /// <summary>
        /// Save method with instance to remove.
        /// </summary>
        public event Action ClipboardChangedEvent;
        
        /// <summary>
        /// Call this method to avoid register Clipboard Changed Event, to avoid no limit loop
        /// </summary>
        /// <param name="innerUseDoNothing"></param>
        private ClipboardWatcher( bool innerUseDoNothing ) {            
        } // private ClipboardWatcher( bool innerUseDoNothing )

        /// <summary>
        /// Creat a Watcher Control, to handle clipboard changed, use control's event.
        /// </summary>
        public ClipboardWatcher() {
            StartWatch( this.OnClipboardChanged );
        } // public ClipboardWatcher()

        /// <summary>
        /// When instance has be destroy, remove event.
        /// </summary>
        ~ClipboardWatcher() {
            ClipboardWatcher.StopWatch( OnClipboardChanged );
        } // ~ClipboardWatcher()


        private void OnClipboardChanged() {
            if ( ClipboardChangedEvent != null ) ClipboardChangedEvent();
        } //  private void OnClipboardChanged()

        
        /// <summary>
        /// Handle clipboard changed message.
        /// </summary>
        /// <param name="m">Message info.</param>
        protected override void WndProc( ref Message m ) {
            switch ( (int)m.Msg ) {
                case 0x308: // if message is WM_DRAWCLIPBOARD, call changed method.
                    if ( ClipboardWatcher.mClipboardChangedEvent_static != null )
                        ClipboardWatcher.mClipboardChangedEvent_static();
                    break;
                default:
                    base.WndProc( ref m );
                    break;
            } // switch
        } // protected override void WndProc( ref Message m )

        #endregion

    } // public class ClipboardWatcher : Control



} //  namespace PGCafe.Object
