﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.510
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace mdlDataBaseData.Tabelas {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class XsdTbStatisticDataManipulators : DataSet {
        
        private tbStatisticDataManipulatorsDataTable tabletbStatisticDataManipulators;
        
        public XsdTbStatisticDataManipulators() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected XsdTbStatisticDataManipulators(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["tbStatisticDataManipulators"] != null)) {
                    this.Tables.Add(new tbStatisticDataManipulatorsDataTable(ds.Tables["tbStatisticDataManipulators"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public tbStatisticDataManipulatorsDataTable tbStatisticDataManipulators {
            get {
                return this.tabletbStatisticDataManipulators;
            }
        }
        
        public override DataSet Clone() {
            XsdTbStatisticDataManipulators cln = ((XsdTbStatisticDataManipulators)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["tbStatisticDataManipulators"] != null)) {
                this.Tables.Add(new tbStatisticDataManipulatorsDataTable(ds.Tables["tbStatisticDataManipulators"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tabletbStatisticDataManipulators = ((tbStatisticDataManipulatorsDataTable)(this.Tables["tbStatisticDataManipulators"]));
            if ((this.tabletbStatisticDataManipulators != null)) {
                this.tabletbStatisticDataManipulators.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "XsdTbStatisticDataManipulators";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/XsdTbStatisticDataManipulators.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabletbStatisticDataManipulators = new tbStatisticDataManipulatorsDataTable();
            this.Tables.Add(this.tabletbStatisticDataManipulators);
        }
        
        private bool ShouldSerializetbStatisticDataManipulators() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void tbStatisticDataManipulatorsRowChangeEventHandler(object sender, tbStatisticDataManipulatorsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbStatisticDataManipulatorsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnnIdDataManipulator;
            
            private DataColumn columnstrName;
            
            private DataColumn columnmstrData;
            
            internal tbStatisticDataManipulatorsDataTable() : 
                    base("tbStatisticDataManipulators") {
                this.InitClass();
            }
            
            internal tbStatisticDataManipulatorsDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn nIdDataManipulatorColumn {
                get {
                    return this.columnnIdDataManipulator;
                }
            }
            
            internal DataColumn strNameColumn {
                get {
                    return this.columnstrName;
                }
            }
            
            internal DataColumn mstrDataColumn {
                get {
                    return this.columnmstrData;
                }
            }
            
            public tbStatisticDataManipulatorsRow this[int index] {
                get {
                    return ((tbStatisticDataManipulatorsRow)(this.Rows[index]));
                }
            }
            
            public event tbStatisticDataManipulatorsRowChangeEventHandler tbStatisticDataManipulatorsRowChanged;
            
            public event tbStatisticDataManipulatorsRowChangeEventHandler tbStatisticDataManipulatorsRowChanging;
            
            public event tbStatisticDataManipulatorsRowChangeEventHandler tbStatisticDataManipulatorsRowDeleted;
            
            public event tbStatisticDataManipulatorsRowChangeEventHandler tbStatisticDataManipulatorsRowDeleting;
            
            public void AddtbStatisticDataManipulatorsRow(tbStatisticDataManipulatorsRow row) {
                this.Rows.Add(row);
            }
            
            public tbStatisticDataManipulatorsRow AddtbStatisticDataManipulatorsRow(int nIdDataManipulator, string strName, string mstrData) {
                tbStatisticDataManipulatorsRow rowtbStatisticDataManipulatorsRow = ((tbStatisticDataManipulatorsRow)(this.NewRow()));
                rowtbStatisticDataManipulatorsRow.ItemArray = new object[] {
                        nIdDataManipulator,
                        strName,
                        mstrData};
                this.Rows.Add(rowtbStatisticDataManipulatorsRow);
                return rowtbStatisticDataManipulatorsRow;
            }
            
            public tbStatisticDataManipulatorsRow FindBynIdDataManipulator(int nIdDataManipulator) {
                return ((tbStatisticDataManipulatorsRow)(this.Rows.Find(new object[] {
                            nIdDataManipulator})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                tbStatisticDataManipulatorsDataTable cln = ((tbStatisticDataManipulatorsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new tbStatisticDataManipulatorsDataTable();
            }
            
            internal void InitVars() {
                this.columnnIdDataManipulator = this.Columns["nIdDataManipulator"];
                this.columnstrName = this.Columns["strName"];
                this.columnmstrData = this.Columns["mstrData"];
            }
            
            private void InitClass() {
                this.columnnIdDataManipulator = new DataColumn("nIdDataManipulator", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdDataManipulator);
                this.columnstrName = new DataColumn("strName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnstrName);
                this.columnmstrData = new DataColumn("mstrData", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnmstrData);
                this.Constraints.Add(new UniqueConstraint("XsdTbStatisticDataManipulatorsKey1", new DataColumn[] {
                                this.columnnIdDataManipulator}, true));
                this.columnnIdDataManipulator.AllowDBNull = false;
                this.columnnIdDataManipulator.Unique = true;
            }
            
            public tbStatisticDataManipulatorsRow NewtbStatisticDataManipulatorsRow() {
                return ((tbStatisticDataManipulatorsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new tbStatisticDataManipulatorsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(tbStatisticDataManipulatorsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.tbStatisticDataManipulatorsRowChanged != null)) {
                    this.tbStatisticDataManipulatorsRowChanged(this, new tbStatisticDataManipulatorsRowChangeEvent(((tbStatisticDataManipulatorsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.tbStatisticDataManipulatorsRowChanging != null)) {
                    this.tbStatisticDataManipulatorsRowChanging(this, new tbStatisticDataManipulatorsRowChangeEvent(((tbStatisticDataManipulatorsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.tbStatisticDataManipulatorsRowDeleted != null)) {
                    this.tbStatisticDataManipulatorsRowDeleted(this, new tbStatisticDataManipulatorsRowChangeEvent(((tbStatisticDataManipulatorsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.tbStatisticDataManipulatorsRowDeleting != null)) {
                    this.tbStatisticDataManipulatorsRowDeleting(this, new tbStatisticDataManipulatorsRowChangeEvent(((tbStatisticDataManipulatorsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovetbStatisticDataManipulatorsRow(tbStatisticDataManipulatorsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbStatisticDataManipulatorsRow : DataRow {
            
            private tbStatisticDataManipulatorsDataTable tabletbStatisticDataManipulators;
            
            internal tbStatisticDataManipulatorsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tabletbStatisticDataManipulators = ((tbStatisticDataManipulatorsDataTable)(this.Table));
            }
            
            public int nIdDataManipulator {
                get {
                    return ((int)(this[this.tabletbStatisticDataManipulators.nIdDataManipulatorColumn]));
                }
                set {
                    this[this.tabletbStatisticDataManipulators.nIdDataManipulatorColumn] = value;
                }
            }
            
            public string strName {
                get {
                    try {
                        return ((string)(this[this.tabletbStatisticDataManipulators.strNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbStatisticDataManipulators.strNameColumn] = value;
                }
            }
            
            public string mstrData {
                get {
                    try {
                        return ((string)(this[this.tabletbStatisticDataManipulators.mstrDataColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbStatisticDataManipulators.mstrDataColumn] = value;
                }
            }
            
            public bool IsstrNameNull() {
                return this.IsNull(this.tabletbStatisticDataManipulators.strNameColumn);
            }
            
            public void SetstrNameNull() {
                this[this.tabletbStatisticDataManipulators.strNameColumn] = System.Convert.DBNull;
            }
            
            public bool IsmstrDataNull() {
                return this.IsNull(this.tabletbStatisticDataManipulators.mstrDataColumn);
            }
            
            public void SetmstrDataNull() {
                this[this.tabletbStatisticDataManipulators.mstrDataColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbStatisticDataManipulatorsRowChangeEvent : EventArgs {
            
            private tbStatisticDataManipulatorsRow eventRow;
            
            private DataRowAction eventAction;
            
            public tbStatisticDataManipulatorsRowChangeEvent(tbStatisticDataManipulatorsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public tbStatisticDataManipulatorsRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
