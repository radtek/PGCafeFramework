using System;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PGCafe {
    /// <summary>
    /// Quick display type.
    /// </summary>
    [Flags]
    public enum MsgType {
        /// <summary> Button - OK </summary>
        O = 1,
        /// <summary> Button - OKCancel </summary>
        OC = 2,
        /// <summary> Button - AbortRetryIgnore </summary>
        ARI = 4,
        /// <summary> Button - YesNoCancel </summary>
        YNC = 8,
        /// <summary> Button - YesNo </summary>
        YN = 16,
        /// <summary> Button - RetryCancel </summary>
        RC = 32,
        /// <summary> Icon - Error </summary>
        Err = 64,
        /// <summary> Icon - Question </summary>
        Ques = 128,
        /// <summary> Icon - Warning </summary>
        Warn = 256,
        /// <summary> Icon - Infomation </summary>
        Info = 512,
        /// <summary> None </summary>
        None = 1024,
        /// <summary> Default </summary>
        Default = 1024,
        
        /// <summary> Icon-Button = Error-OK </summary>
        Err_O       = O | Err,
        /// <summary> Icon-Button = Question-OK </summary>
        Ques_O      = O | Ques,
        /// <summary> Icon-Button = Warning-OK </summary>
        Warn_O      = O | Warn,
        /// <summary> Icon-Button = Infomation-OK </summary>
        Info_O      = O | Info,
        /// <summary> Icon-Button = None-OK </summary>
        None_O      = O | Default,
        
        /// <summary> Icon-Button = Error-OKCancel </summary>
        Err_OC     = OC | Err,
        /// <summary> Icon-Button = Question-OKCancel </summary>
        Ques_OC     = OC | Ques,
        /// <summary> Icon-Button = Warning-OKCancel </summary>
        Warn_OC     = OC | Warn,
        /// <summary> Icon-Button = Infomation-OKCancel </summary>
        Info_OC     = OC | Info,
        /// <summary> Icon-Button = None-OKCancel </summary>
        None_OC     = OC | Default,
        
        /// <summary> Icon-Button = Error-AbortRetryIgnore </summary>
        Err_ARI    = ARI | Err,
        /// <summary> Icon-Button = Question-AbortRetryIgnore </summary>
        Ques_ARI    = ARI | Ques,
        /// <summary> Icon-Button = Warning-AbortRetryIgnore </summary>
        Warn_ARI    = ARI | Warn,
        /// <summary> Icon-Button = Infomation-AbortRetryIgnore </summary>
        Info_ARI    = ARI | Info,
        /// <summary> Icon-Button = None-AbortRetryIgnore </summary>
        None_ARI    = ARI | Default,
        
        /// <summary> Icon-Button = Error-YesNoCancel </summary>
        Err_YNC    = YNC | Err,
        /// <summary> Icon-Button = Question-YesNoCancel </summary>
        Ques_YNC    = YNC | Ques,
        /// <summary> Icon-Button = Warning-YesNoCancel </summary>
        Warn_YNC    = YNC | Warn,
        /// <summary> Icon-Button = Infomation-YesNoCancel </summary>
        Info_YNC    = YNC | Info,
        /// <summary> Icon-Button = None-YesNoCancel </summary>
        None_YNC    = YNC | Default,
        
        /// <summary> Icon-Button = Error-YesNo </summary>
        Err_YN     = YN | Err,
        /// <summary> Icon-Button = Question-YesNo </summary>
        Ques_YN     = YN | Ques,
        /// <summary> Icon-Button = Warning-YesNo </summary>
        Warn_YN     = YN | Warn,
        /// <summary> Icon-Button = Infomation-YesNo </summary>
        Info_YN     = YN | Info,
        /// <summary> Icon-Button = None-YesNo </summary>
        None_YN     = YN | Default,
            
        /// <summary> Icon-Button = Error-RetryCencal </summary>
        Err_RC     = RC | Err,
        /// <summary> Icon-Button = Question-RetryCencal </summary>
        Ques_RC     = RC | Ques,
        /// <summary> Icon-Button = Warning-RetryCencal </summary>
        Warn_RC     = RC | Warn,
        /// <summary> Icon-Button = Infomation-RetryCencal </summary>
        Info_RC     = RC | Info,
        /// <summary> Icon-Button = None-RetryCencal </summary>
        None_RC     = RC | Default,
    } // public enum MsgType


    /// <summary> Simple Show Message Box </summary>
    public class PGMessageBox {

        /// <summary>
        /// Displays a message box with the specified text, simple icon-buttons, default button.
        /// </summary>
        /// <param name="message"> message to show. </param>
        /// <param name="type"> icon-buttons type. </param>
        /// <param name="defaultButton"> default focus button. </param>
        /// <returns> result of messagebox </returns>
        public static DialogResult Show( string message, MsgType type, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 ){
            return MessageBox.Show( message, TypeToTitle( type ), TypeToButtons( type ), TypeToIcon( type ), defaultButton );
        } // public static DialogResult Show( string message, MsgEXType type, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 )
        
        /// <summary>
        /// Displays a message box with the specified text, title, simple icon-buttons, default button.
        /// </summary>
        /// <param name="message"> message to show. </param>
        /// <param name="title"> title on message box. </param>
        /// <param name="type"> icon-buttons type. </param>
        /// <param name="defaultButton"> default focus button. </param>
        /// <returns> result of messagebox </returns>
        public static DialogResult Show( string message, string title, MsgType type, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 ){
            return MessageBox.Show( message, title, TypeToButtons( type ), TypeToIcon( type ), defaultButton );
        } // public static DialogResult Show( string message, string title, MsgEXType type, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 )
        
        /// <summary>
        /// Displays a message box with the specified text, simple icon-buttons, default button. And auto close when time out.
        /// </summary>
        /// <param name="message"> message to show. </param>
        /// <param name="title"> title of messagebox. </param>
        /// <param name="type"> icon-buttons type. </param>
        /// <param name="timeOut"> millisecond to timeout. </param>
        /// <param name="timeOutValue"> default DialogResult when timeout. </param>
        /// <param name="defaultButton"> default focus button. </param>
        /// <returns> result of messagebox </returns>
        public static DialogResult ShowWithTime( string message, string title, MsgType type, int timeOut, DialogResult timeOutValue = DialogResult.None, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 ){
            var obj = new PGMessageBox();
            return obj._ShowWithTime( message, title, type, timeOut, timeOutValue, defaultButton );
        } // public static DialogResult ShowWithTime( string message, string title, MsgEXType type, int timeOut, DialogResult timeOutValue = DialogResult.None, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 )
        
        #region Show With Time
        
        const string MsgBox_LPClassname = "#32770";
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private Timer mMsgTimer = null;
        
        /// <summary>
        /// Displays a message box with the specified text, simple icon-buttons, default button. And auto close when time out.
        /// </summary>
        /// <param name="message"> message to show. </param>
        /// <param name="title"> title of messagebox. </param>
        /// <param name="type"> icon-buttons type. </param>
        /// <param name="timeOut"> millisecond to timeout. </param>
        /// <param name="timeOutValue"> default DialogResult when timeout. </param>
        /// <param name="defaultButton"> default focus button. </param>
        /// <returns> result of messagebox </returns>
        private DialogResult _ShowWithTime( string message, string title, MsgType type, int timeOut, DialogResult timeOutValue = DialogResult.None, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 ){
            // create timer first.
            mMsgTimer = new Timer( ShowTimeoutCallBack, title, timeOut, Timeout.Infinite );

            // set default value and call message box.
            // if no click by user, MessageBox will not return value?
            DialogResult result = timeOutValue;
            result = MessageBox.Show( message, title, TypeToButtons( type ), TypeToIcon( type ), defaultButton );
            mMsgTimer.Dispose();
            return result;
        } // private DialogResult _ShowWithTime( string message, string title, MsgEXType type, int timeOut, DialogResult timeOutValue = DialogResult.None, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1 )
        
        
        private static void ShowTimeoutCallBack( object title ) {
            IntPtr mbWnd = FindWindow( MsgBox_LPClassname, title.ToString() ); // lpClassName is #32770 for MessageBox
            if ( mbWnd != IntPtr.Zero ) SendMessage( mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero );
        } // private void ShowTimeoutCallBack( object title )


        #endregion

        #region MsgEX To MessageBox Object

        private static string TypeToTitle( MsgType type ) {
            if ( type.HasFlag( MsgType.Err ) )
                return "錯誤";
            else if ( type.HasFlag( MsgType.Ques ) )
                return "詢問";
            else if ( type.HasFlag( MsgType.Warn ) )
                return "警告";
            else if ( type.HasFlag( MsgType.Info ) )
                return "提示";
            else if ( type.HasFlag( MsgType.Default ) )
                return "";
            else
                return "";
        } // private static string TypeToTitle( MsgEXType type )

        private static MessageBoxButtons TypeToButtons( MsgType type ) {
            if ( type.HasFlag( MsgType.O ) )
                return MessageBoxButtons.OK;
            else if ( type.HasFlag( MsgType.OC ) )
                return MessageBoxButtons.OKCancel;
            else if ( type.HasFlag( MsgType.ARI ) )
                return MessageBoxButtons.AbortRetryIgnore;
            else if ( type.HasFlag( MsgType.YNC ) )
                return MessageBoxButtons.YesNoCancel;
            else if ( type.HasFlag( MsgType.YN ) )
                return MessageBoxButtons.YesNo;
            else if ( type.HasFlag( MsgType.RC ) )
                return MessageBoxButtons.RetryCancel;
            else
                return MessageBoxButtons.OK;
        } // private static MessageBoxButtons TypeToButtons( MsgEXType type )

        private static MessageBoxIcon TypeToIcon( MsgType type ) {
            if ( type.HasFlag( MsgType.Err ) )
                return MessageBoxIcon.Error;
            else if ( type.HasFlag( MsgType.Ques ) )
                return MessageBoxIcon.Question;
            else if ( type.HasFlag( MsgType.Warn ) )
                return MessageBoxIcon.Warning;
            else if ( type.HasFlag( MsgType.Info ) )
                return MessageBoxIcon.Information;
            else if ( type.HasFlag( MsgType.Default ) )
                return MessageBoxIcon.None;
            else
                return MessageBoxIcon.None;
        } // private static MessageBoxIcon TypeToIcon( MsgEXType type )

        #endregion



    } // public class PGMessageBox
} // namespace PGCafe
