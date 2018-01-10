using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGCafe {
    /// <summary> Control Extension </summary>
    public static class ControlExtension {

        #region Clone

        #region ExceptNameList

        /// <summary> names of properties to except when clone the control, copy those property may have some problem, so skip them. </summary>
        public static string[] ExceptNameList = new string[] {
            "Capture", "WindowTarget", "Controls", "Parent", // for all controls
            "ColumnCount", "RowCount", // for DataGridView.
        }; // public static string[] ExceptNameList = new string[]

        #endregion

        /// <summary>
        /// Copy <see cref="Control"/> with public property only.( Does not guarantee correct )
        /// * Some property will be skip to make the clone correct. ( see <see cref="ControlExtension.ExceptNameList"/> )
        /// * Control type should have default constructor to create a new instance.
        /// * if copy fail, return null.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="CopyParent"> copy the Parent property or not. </param>
        /// <param name="CopyChild"> copy the child of Controls property or not. </param>
        /// <param name="CopyDeepChild"> copy each child's child of Controls property or not. </param>
        /// <param name="ExceptScrollBarChild"> because some control will provide scroll bar auto, so should not copy it. </param>
        /// <param name="SetVisibleTrue"> set visible to true for each copy's control and those child. </param>
        public static Control Clone( this Control source,
             bool CopyParent = true, bool CopyChild = false, bool CopyDeepChild = false,
             bool ExceptScrollBarChild = true, bool SetVisibleTrue = false ) {
            try {
                // create instance.
                Type TType = source.GetType();
                Control result = (Control)Activator.CreateInstance( TType );
                
                // get copy property method.
                var copyFrom = typeof( ConvertExtension )
                    .GetMethod( nameof( ConvertExtension.CopyFrom ) ).MakeGenericMethod( TType, TType );
                copyFrom.Invoke( null, new object[] { result, source, true, false, null, ExceptNameList, BindingFlags.Public | BindingFlags.Instance } );

                // set new location.
                result.Location = source.Location;
                if ( SetVisibleTrue ) result.Visible = true;

                // copy parent.
                if ( CopyParent ) result.Parent = source.Parent;

                // copy child.
                if ( CopyChild ) {
                    if ( result is DataGridView ) { // copy column and row of datagridview.
                        result.As<DataGridView>().CloneColumnAndRowFrom( source.As<DataGridView>() );
                    } // if
                    else {
                        foreach ( Control item in source.Controls.OfType<Control>() ) {
                            // because some control will provide scroll bar auto, so should not copy again.
                            if ( ExceptScrollBarChild && item is ScrollBar ) continue ;
                            var newItem = item.Clone( CopyParent: false, CopyChild: CopyDeepChild, CopyDeepChild: true, SetVisibleTrue: SetVisibleTrue );
                            newItem.Parent = result;
                        } // foreach
                    } // else
                } // if



                return result;
            } catch {
                return null;
            } // try-catch
        } // public static Control Clone( this Control source, bool CopyParent = true, ... )

        #region DataGridView : CloneColumn, CloneRow

        /// <summary> 
        /// Copy column of <see cref="DataGridView"/> and return itself.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="From"> From. </param>
        /// <returns> source </returns>
        public static DataGridView CloneColumnFrom( this DataGridView source, DataGridView From ) {
            foreach ( DataGridViewColumn col in From.Columns )
                source.Columns.Add( col.Clone().As<DataGridViewColumn>() );

            return source;
        } // public static DataGridView CloneColumnFrom( this DataGridView source, DataGridView From )


        /// <summary>
        /// Copy row of <see cref="DataGridView"/> and return itself.
        /// Only clone when <see cref="DataGridView.DataSource"/> is null.
        /// Before copy row, should copy column first.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="From"> From. </param>
        /// <returns> source </returns>
        public static DataGridView CloneRowFrom( this DataGridView source, DataGridView From ) {
            // if datasource is not empty, do not copy row data.
            if ( source.DataSource != null )
                return source;

            foreach ( DataGridViewRow row in From.Rows )
                if ( !row.IsNewRow )
                    source.Rows.Add( row.Clone().As<DataGridViewRow>() );

            return source;
        } // public static DataGridView CloneRowFrom( this DataGridView source, DataGridView From )


        /// <summary>
        /// Copy column and row of <see cref="DataGridView"/> and return itself.
        /// Only clone row when <see cref="DataGridView.DataSource"/> is null.
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="From"> From. </param>
        /// <returns> source </returns>
        public static DataGridView CloneColumnAndRowFrom( this DataGridView source, DataGridView From ) {
            return source.CloneColumnFrom( From ).CloneRowFrom( From );
        } // public static DataGridView CloneColumnAndRowFrom( this DataGridView source, DataGridView From )

        #endregion

        #endregion

        /// <summary> Enumrate all childs include itself.( enumrate by pre-order ) </summary>
        /// <param name="source"> source </param>
        /// <returns> <see cref="IEnumerable{Control}"/>  of childs </returns>
        public static IEnumerable<Control> EnumerateDeepChilds( this Control source ) {
            // return source first.
            yield return source;

            if ( !source.HasChildren ) yield break;

            // return each child in source.
            foreach ( var child in source.Controls.Cast<Control>() ) {
                // return child.
                yield return child;

                // return child's child with recursive
                if ( child.HasChildren ) {
                    foreach ( var deepChild in child.EnumerateDeepChilds() )
                        yield return deepChild;
                } // if
            } // foreach ( var child in source.Controls.Cast<Control>() )
        } // public static IEnumerable<Control> EnumerateDeepChilds( this Control source )


        #region DataSource( ComboBox, ListBox, DataGridViewComboBoxColumn )

        #region ListControl( ComboBox, ListBox )

        /// <summary> Set DataSource, DisplayMember, ValueMember in single line. </summary>
        /// <param name="source">The source.</param>
        /// <param name="DataSource">The data source.</param>
        /// <param name="DisplayMember">The display member.</param>
        /// <param name="ValueMember">The value member.</param>
        public static void SetDataSource( this ListControl source, object DataSource, string DisplayMember, string ValueMember ) {
            source.DataSource = DataSource;
            source.DisplayMember = DisplayMember;
            source.ValueMember = ValueMember;
        } // public static void SetDataSource( this ListControl source, object DataSource, string DisplayMember, string ValueMember )
        
        /// <summary> Clear DataSource, DisplayMember, ValueMember in single line. </summary>
        /// <param name="source">The source.</param>
        public static void ClearDataSource( this ListControl source ) {
            source.DataSource = null;
            source.DisplayMember = null;
            source.ValueMember = null;
        } // public static void ClearDataSource( this ListControl source )

        #endregion

        #region DataGridViewComboBoxColumn
        
        /// <summary> Set DataSource, DisplayMember, ValueMember in single line. </summary>
        /// <param name="source">The source.</param>
        /// <param name="DataSource">The data source.</param>
        /// <param name="DisplayMember">The display member.</param>
        /// <param name="ValueMember">The value member.</param>
        public static void SetDataSource( this DataGridViewComboBoxColumn source, object DataSource, string DisplayMember, string ValueMember ) {
            source.DataSource = DataSource;
            source.DisplayMember = DisplayMember;
            source.ValueMember = ValueMember;
        } // public static void SetDataSource( this DataGridViewComboBoxColumn source, object DataSource, string DisplayMember, string ValueMember )
        
        /// <summary> Clear DataSource, DisplayMember, ValueMember in single line. </summary>
        /// <param name="source">The source.</param>
        public static void ClearDataSource( this DataGridViewComboBoxColumn source ) {
            source.DataSource = null;
            source.DisplayMember = null;
            source.ValueMember = null;
        } // public static void ClearDataSource( this DataGridViewComboBoxColumn source )

        #endregion

        #endregion

    } // public static class ControlExtension
} // namespace PGCafe
