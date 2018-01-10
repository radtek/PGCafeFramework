#pragma warning disable CS1591
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCafe {
    public static class PGFlag {

        private static Dictionary<object,int> mSuspendDic = new Dictionary<object,int>();

        public static void Suspend( object Key ) {
            if ( mSuspendDic.ContainsKey( Key ) ) mSuspendDic[Key] += 1;
            else mSuspendDic[Key] = 1;
        } // public static void Suspend( object Key )

        public static void Resume( object Key ) {
            if ( mSuspendDic.ContainsKey( Key ) ) {
                if ( mSuspendDic[Key] > 1 ) mSuspendDic[Key] -= 1;
                else if ( mSuspendDic[Key] == 1 ) mSuspendDic.Remove( Key );
            } // if
        } // public static void Resume( object Key )

        public static bool IsSuspend( object Key ) {
            if ( mSuspendDic.ContainsKey( Key ) ) return mSuspendDic[Key] > 0;
            else return false;
        } // public static bool IsSuspend( object Key )

    } // public static class PGFlag
} // namespace PGCafe
