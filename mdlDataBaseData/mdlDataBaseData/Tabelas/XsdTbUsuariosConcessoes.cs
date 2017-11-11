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
    public class XsdTbUsuariosConcessoes : DataSet {
        
        private tbUsuariosConcessoesDataTable tabletbUsuariosConcessoes;
        
        public XsdTbUsuariosConcessoes() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected XsdTbUsuariosConcessoes(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["tbUsuariosConcessoes"] != null)) {
                    this.Tables.Add(new tbUsuariosConcessoesDataTable(ds.Tables["tbUsuariosConcessoes"]));
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
        public tbUsuariosConcessoesDataTable tbUsuariosConcessoes {
            get {
                return this.tabletbUsuariosConcessoes;
            }
        }
        
        public override DataSet Clone() {
            XsdTbUsuariosConcessoes cln = ((XsdTbUsuariosConcessoes)(base.Clone()));
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
            if ((ds.Tables["tbUsuariosConcessoes"] != null)) {
                this.Tables.Add(new tbUsuariosConcessoesDataTable(ds.Tables["tbUsuariosConcessoes"]));
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
            this.tabletbUsuariosConcessoes = ((tbUsuariosConcessoesDataTable)(this.Tables["tbUsuariosConcessoes"]));
            if ((this.tabletbUsuariosConcessoes != null)) {
                this.tabletbUsuariosConcessoes.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "XsdTbUsuariosConcessoes";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/XsdTbUsuariosConcessoes.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabletbUsuariosConcessoes = new tbUsuariosConcessoesDataTable();
            this.Tables.Add(this.tabletbUsuariosConcessoes);
        }
        
        private bool ShouldSerializetbUsuariosConcessoes() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void tbUsuariosConcessoesRowChangeEventHandler(object sender, tbUsuariosConcessoesRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbUsuariosConcessoesDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnnIdConcessao;
            
            private DataColumn columnstrConcessao;
            
            private DataColumn columnstrDescricao;
            
            internal tbUsuariosConcessoesDataTable() : 
                    base("tbUsuariosConcessoes") {
                this.InitClass();
            }
            
            internal tbUsuariosConcessoesDataTable(DataTable table) : 
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
            
            internal DataColumn nIdConcessaoColumn {
                get {
                    return this.columnnIdConcessao;
                }
            }
            
            internal DataColumn strConcessaoColumn {
                get {
                    return this.columnstrConcessao;
                }
            }
            
            internal DataColumn strDescricaoColumn {
                get {
                    return this.columnstrDescricao;
                }
            }
            
            public tbUsuariosConcessoesRow this[int index] {
                get {
                    return ((tbUsuariosConcessoesRow)(this.Rows[index]));
                }
            }
            
            public event tbUsuariosConcessoesRowChangeEventHandler tbUsuariosConcessoesRowChanged;
            
            public event tbUsuariosConcessoesRowChangeEventHandler tbUsuariosConcessoesRowChanging;
            
            public event tbUsuariosConcessoesRowChangeEventHandler tbUsuariosConcessoesRowDeleted;
            
            public event tbUsuariosConcessoesRowChangeEventHandler tbUsuariosConcessoesRowDeleting;
            
            public void AddtbUsuariosConcessoesRow(tbUsuariosConcessoesRow row) {
                this.Rows.Add(row);
            }
            
            public tbUsuariosConcessoesRow AddtbUsuariosConcessoesRow(int nIdConcessao, string strConcessao, string strDescricao) {
                tbUsuariosConcessoesRow rowtbUsuariosConcessoesRow = ((tbUsuariosConcessoesRow)(this.NewRow()));
                rowtbUsuariosConcessoesRow.ItemArray = new object[] {
                        nIdConcessao,
                        strConcessao,
                        strDescricao};
                this.Rows.Add(rowtbUsuariosConcessoesRow);
                return rowtbUsuariosConcessoesRow;
            }
            
            public tbUsuariosConcessoesRow FindBynIdConcessao(int nIdConcessao) {
                return ((tbUsuariosConcessoesRow)(this.Rows.Find(new object[] {
                            nIdConcessao})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                tbUsuariosConcessoesDataTable cln = ((tbUsuariosConcessoesDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new tbUsuariosConcessoesDataTable();
            }
            
            internal void InitVars() {
                this.columnnIdConcessao = this.Columns["nIdConcessao"];
                this.columnstrConcessao = this.Columns["strConcessao"];
                this.columnstrDescricao = this.Columns["strDescricao"];
            }
            
            private void InitClass() {
                this.columnnIdConcessao = new DataColumn("nIdConcessao", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdConcessao);
                this.columnstrConcessao = new DataColumn("strConcessao", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnstrConcessao);
                this.columnstrDescricao = new DataColumn("strDescricao", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnstrDescricao);
                this.Constraints.Add(new UniqueConstraint("XsdTbUsuariosConcessoesKey1", new DataColumn[] {
                                this.columnnIdConcessao}, true));
                this.columnnIdConcessao.AllowDBNull = false;
                this.columnnIdConcessao.Unique = true;
            }
            
            public tbUsuariosConcessoesRow NewtbUsuariosConcessoesRow() {
                return ((tbUsuariosConcessoesRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new tbUsuariosConcessoesRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(tbUsuariosConcessoesRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.tbUsuariosConcessoesRowChanged != null)) {
                    this.tbUsuariosConcessoesRowChanged(this, new tbUsuariosConcessoesRowChangeEvent(((tbUsuariosConcessoesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.tbUsuariosConcessoesRowChanging != null)) {
                    this.tbUsuariosConcessoesRowChanging(this, new tbUsuariosConcessoesRowChangeEvent(((tbUsuariosConcessoesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.tbUsuariosConcessoesRowDeleted != null)) {
                    this.tbUsuariosConcessoesRowDeleted(this, new tbUsuariosConcessoesRowChangeEvent(((tbUsuariosConcessoesRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.tbUsuariosConcessoesRowDeleting != null)) {
                    this.tbUsuariosConcessoesRowDeleting(this, new tbUsuariosConcessoesRowChangeEvent(((tbUsuariosConcessoesRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovetbUsuariosConcessoesRow(tbUsuariosConcessoesRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbUsuariosConcessoesRow : DataRow {
            
            private tbUsuariosConcessoesDataTable tabletbUsuariosConcessoes;
            
            internal tbUsuariosConcessoesRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tabletbUsuariosConcessoes = ((tbUsuariosConcessoesDataTable)(this.Table));
            }
            
            public int nIdConcessao {
                get {
                    return ((int)(this[this.tabletbUsuariosConcessoes.nIdConcessaoColumn]));
                }
                set {
                    this[this.tabletbUsuariosConcessoes.nIdConcessaoColumn] = value;
                }
            }
            
            public string strConcessao {
                get {
                    try {
                        return ((string)(this[this.tabletbUsuariosConcessoes.strConcessaoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbUsuariosConcessoes.strConcessaoColumn] = value;
                }
            }
            
            public string strDescricao {
                get {
                    try {
                        return ((string)(this[this.tabletbUsuariosConcessoes.strDescricaoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbUsuariosConcessoes.strDescricaoColumn] = value;
                }
            }
            
            public bool IsstrConcessaoNull() {
                return this.IsNull(this.tabletbUsuariosConcessoes.strConcessaoColumn);
            }
            
            public void SetstrConcessaoNull() {
                this[this.tabletbUsuariosConcessoes.strConcessaoColumn] = System.Convert.DBNull;
            }
            
            public bool IsstrDescricaoNull() {
                return this.IsNull(this.tabletbUsuariosConcessoes.strDescricaoColumn);
            }
            
            public void SetstrDescricaoNull() {
                this[this.tabletbUsuariosConcessoes.strDescricaoColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbUsuariosConcessoesRowChangeEvent : EventArgs {
            
            private tbUsuariosConcessoesRow eventRow;
            
            private DataRowAction eventAction;
            
            public tbUsuariosConcessoesRowChangeEvent(tbUsuariosConcessoesRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public tbUsuariosConcessoesRow Row {
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