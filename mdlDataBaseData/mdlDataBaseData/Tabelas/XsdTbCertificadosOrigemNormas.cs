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
    public class XsdTbCertificadosOrigemNormas : DataSet {
        
        private tbCertificadosOrigemNormasDataTable tabletbCertificadosOrigemNormas;
        
        public XsdTbCertificadosOrigemNormas() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected XsdTbCertificadosOrigemNormas(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["tbCertificadosOrigemNormas"] != null)) {
                    this.Tables.Add(new tbCertificadosOrigemNormasDataTable(ds.Tables["tbCertificadosOrigemNormas"]));
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
        public tbCertificadosOrigemNormasDataTable tbCertificadosOrigemNormas {
            get {
                return this.tabletbCertificadosOrigemNormas;
            }
        }
        
        public override DataSet Clone() {
            XsdTbCertificadosOrigemNormas cln = ((XsdTbCertificadosOrigemNormas)(base.Clone()));
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
            if ((ds.Tables["tbCertificadosOrigemNormas"] != null)) {
                this.Tables.Add(new tbCertificadosOrigemNormasDataTable(ds.Tables["tbCertificadosOrigemNormas"]));
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
            this.tabletbCertificadosOrigemNormas = ((tbCertificadosOrigemNormasDataTable)(this.Tables["tbCertificadosOrigemNormas"]));
            if ((this.tabletbCertificadosOrigemNormas != null)) {
                this.tabletbCertificadosOrigemNormas.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "XsdTbCertificadosOrigemNormas";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/XsdTbCertificadosOrigemNormas.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabletbCertificadosOrigemNormas = new tbCertificadosOrigemNormasDataTable();
            this.Tables.Add(this.tabletbCertificadosOrigemNormas);
        }
        
        private bool ShouldSerializetbCertificadosOrigemNormas() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void tbCertificadosOrigemNormasRowChangeEventHandler(object sender, tbCertificadosOrigemNormasRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbCertificadosOrigemNormasDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnnIdTipoCO;
            
            private DataColumn columnnIdNorma;
            
            private DataColumn columnmstrNome;
            
            private DataColumn columnmstrDescricao;
            
            internal tbCertificadosOrigemNormasDataTable() : 
                    base("tbCertificadosOrigemNormas") {
                this.InitClass();
            }
            
            internal tbCertificadosOrigemNormasDataTable(DataTable table) : 
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
            
            internal DataColumn nIdTipoCOColumn {
                get {
                    return this.columnnIdTipoCO;
                }
            }
            
            internal DataColumn nIdNormaColumn {
                get {
                    return this.columnnIdNorma;
                }
            }
            
            internal DataColumn mstrNomeColumn {
                get {
                    return this.columnmstrNome;
                }
            }
            
            internal DataColumn mstrDescricaoColumn {
                get {
                    return this.columnmstrDescricao;
                }
            }
            
            public tbCertificadosOrigemNormasRow this[int index] {
                get {
                    return ((tbCertificadosOrigemNormasRow)(this.Rows[index]));
                }
            }
            
            public event tbCertificadosOrigemNormasRowChangeEventHandler tbCertificadosOrigemNormasRowChanged;
            
            public event tbCertificadosOrigemNormasRowChangeEventHandler tbCertificadosOrigemNormasRowChanging;
            
            public event tbCertificadosOrigemNormasRowChangeEventHandler tbCertificadosOrigemNormasRowDeleted;
            
            public event tbCertificadosOrigemNormasRowChangeEventHandler tbCertificadosOrigemNormasRowDeleting;
            
            public void AddtbCertificadosOrigemNormasRow(tbCertificadosOrigemNormasRow row) {
                this.Rows.Add(row);
            }
            
            public tbCertificadosOrigemNormasRow AddtbCertificadosOrigemNormasRow(int nIdTipoCO, int nIdNorma, string mstrNome, string mstrDescricao) {
                tbCertificadosOrigemNormasRow rowtbCertificadosOrigemNormasRow = ((tbCertificadosOrigemNormasRow)(this.NewRow()));
                rowtbCertificadosOrigemNormasRow.ItemArray = new object[] {
                        nIdTipoCO,
                        nIdNorma,
                        mstrNome,
                        mstrDescricao};
                this.Rows.Add(rowtbCertificadosOrigemNormasRow);
                return rowtbCertificadosOrigemNormasRow;
            }
            
            public tbCertificadosOrigemNormasRow FindBynIdTipoCOnIdNorma(int nIdTipoCO, int nIdNorma) {
                return ((tbCertificadosOrigemNormasRow)(this.Rows.Find(new object[] {
                            nIdTipoCO,
                            nIdNorma})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                tbCertificadosOrigemNormasDataTable cln = ((tbCertificadosOrigemNormasDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new tbCertificadosOrigemNormasDataTable();
            }
            
            internal void InitVars() {
                this.columnnIdTipoCO = this.Columns["nIdTipoCO"];
                this.columnnIdNorma = this.Columns["nIdNorma"];
                this.columnmstrNome = this.Columns["mstrNome"];
                this.columnmstrDescricao = this.Columns["mstrDescricao"];
            }
            
            private void InitClass() {
                this.columnnIdTipoCO = new DataColumn("nIdTipoCO", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdTipoCO);
                this.columnnIdNorma = new DataColumn("nIdNorma", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdNorma);
                this.columnmstrNome = new DataColumn("mstrNome", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnmstrNome);
                this.columnmstrDescricao = new DataColumn("mstrDescricao", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnmstrDescricao);
                this.Constraints.Add(new UniqueConstraint("XsdTbCertificadosOrigemNormasKey1", new DataColumn[] {
                                this.columnnIdTipoCO,
                                this.columnnIdNorma}, true));
                this.columnnIdTipoCO.AllowDBNull = false;
                this.columnnIdNorma.AllowDBNull = false;
            }
            
            public tbCertificadosOrigemNormasRow NewtbCertificadosOrigemNormasRow() {
                return ((tbCertificadosOrigemNormasRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new tbCertificadosOrigemNormasRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(tbCertificadosOrigemNormasRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.tbCertificadosOrigemNormasRowChanged != null)) {
                    this.tbCertificadosOrigemNormasRowChanged(this, new tbCertificadosOrigemNormasRowChangeEvent(((tbCertificadosOrigemNormasRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.tbCertificadosOrigemNormasRowChanging != null)) {
                    this.tbCertificadosOrigemNormasRowChanging(this, new tbCertificadosOrigemNormasRowChangeEvent(((tbCertificadosOrigemNormasRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.tbCertificadosOrigemNormasRowDeleted != null)) {
                    this.tbCertificadosOrigemNormasRowDeleted(this, new tbCertificadosOrigemNormasRowChangeEvent(((tbCertificadosOrigemNormasRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.tbCertificadosOrigemNormasRowDeleting != null)) {
                    this.tbCertificadosOrigemNormasRowDeleting(this, new tbCertificadosOrigemNormasRowChangeEvent(((tbCertificadosOrigemNormasRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovetbCertificadosOrigemNormasRow(tbCertificadosOrigemNormasRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbCertificadosOrigemNormasRow : DataRow {
            
            private tbCertificadosOrigemNormasDataTable tabletbCertificadosOrigemNormas;
            
            internal tbCertificadosOrigemNormasRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tabletbCertificadosOrigemNormas = ((tbCertificadosOrigemNormasDataTable)(this.Table));
            }
            
            public int nIdTipoCO {
                get {
                    return ((int)(this[this.tabletbCertificadosOrigemNormas.nIdTipoCOColumn]));
                }
                set {
                    this[this.tabletbCertificadosOrigemNormas.nIdTipoCOColumn] = value;
                }
            }
            
            public int nIdNorma {
                get {
                    return ((int)(this[this.tabletbCertificadosOrigemNormas.nIdNormaColumn]));
                }
                set {
                    this[this.tabletbCertificadosOrigemNormas.nIdNormaColumn] = value;
                }
            }
            
            public string mstrNome {
                get {
                    try {
                        return ((string)(this[this.tabletbCertificadosOrigemNormas.mstrNomeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbCertificadosOrigemNormas.mstrNomeColumn] = value;
                }
            }
            
            public string mstrDescricao {
                get {
                    try {
                        return ((string)(this[this.tabletbCertificadosOrigemNormas.mstrDescricaoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbCertificadosOrigemNormas.mstrDescricaoColumn] = value;
                }
            }
            
            public bool IsmstrNomeNull() {
                return this.IsNull(this.tabletbCertificadosOrigemNormas.mstrNomeColumn);
            }
            
            public void SetmstrNomeNull() {
                this[this.tabletbCertificadosOrigemNormas.mstrNomeColumn] = System.Convert.DBNull;
            }
            
            public bool IsmstrDescricaoNull() {
                return this.IsNull(this.tabletbCertificadosOrigemNormas.mstrDescricaoColumn);
            }
            
            public void SetmstrDescricaoNull() {
                this[this.tabletbCertificadosOrigemNormas.mstrDescricaoColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbCertificadosOrigemNormasRowChangeEvent : EventArgs {
            
            private tbCertificadosOrigemNormasRow eventRow;
            
            private DataRowAction eventAction;
            
            public tbCertificadosOrigemNormasRowChangeEvent(tbCertificadosOrigemNormasRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public tbCertificadosOrigemNormasRow Row {
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
