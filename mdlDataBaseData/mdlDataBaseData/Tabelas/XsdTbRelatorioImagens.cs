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
    public class XsdTbRelatorioImagens : DataSet {
        
        private tbRelatorioImagensDataTable tabletbRelatorioImagens;
        
        public XsdTbRelatorioImagens() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected XsdTbRelatorioImagens(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["tbRelatorioImagens"] != null)) {
                    this.Tables.Add(new tbRelatorioImagensDataTable(ds.Tables["tbRelatorioImagens"]));
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
        public tbRelatorioImagensDataTable tbRelatorioImagens {
            get {
                return this.tabletbRelatorioImagens;
            }
        }
        
        public override DataSet Clone() {
            XsdTbRelatorioImagens cln = ((XsdTbRelatorioImagens)(base.Clone()));
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
            if ((ds.Tables["tbRelatorioImagens"] != null)) {
                this.Tables.Add(new tbRelatorioImagensDataTable(ds.Tables["tbRelatorioImagens"]));
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
            this.tabletbRelatorioImagens = ((tbRelatorioImagensDataTable)(this.Tables["tbRelatorioImagens"]));
            if ((this.tabletbRelatorioImagens != null)) {
                this.tabletbRelatorioImagens.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "XsdTbRelatorioImagens";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/XsdTbRelatorioImagens.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabletbRelatorioImagens = new tbRelatorioImagensDataTable();
            this.Tables.Add(this.tabletbRelatorioImagens);
        }
        
        private bool ShouldSerializetbRelatorioImagens() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void tbRelatorioImagensRowChangeEventHandler(object sender, tbRelatorioImagensRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbRelatorioImagensDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnnIdExportador;
            
            private DataColumn columnnIdTipo;
            
            private DataColumn columnnIdRelatorio;
            
            private DataColumn columnnIdimagem;
            
            private DataColumn columnnX1;
            
            private DataColumn columnnY1;
            
            private DataColumn columnnX2;
            
            private DataColumn columnnY2;
            
            private DataColumn columnbVisivelImpressao;
            
            private DataColumn columnnGrupo;
            
            private DataColumn columnnIdImagemIndex;
            
            internal tbRelatorioImagensDataTable() : 
                    base("tbRelatorioImagens") {
                this.InitClass();
            }
            
            internal tbRelatorioImagensDataTable(DataTable table) : 
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
            
            internal DataColumn nIdExportadorColumn {
                get {
                    return this.columnnIdExportador;
                }
            }
            
            internal DataColumn nIdTipoColumn {
                get {
                    return this.columnnIdTipo;
                }
            }
            
            internal DataColumn nIdRelatorioColumn {
                get {
                    return this.columnnIdRelatorio;
                }
            }
            
            internal DataColumn nIdimagemColumn {
                get {
                    return this.columnnIdimagem;
                }
            }
            
            internal DataColumn nX1Column {
                get {
                    return this.columnnX1;
                }
            }
            
            internal DataColumn nY1Column {
                get {
                    return this.columnnY1;
                }
            }
            
            internal DataColumn nX2Column {
                get {
                    return this.columnnX2;
                }
            }
            
            internal DataColumn nY2Column {
                get {
                    return this.columnnY2;
                }
            }
            
            internal DataColumn bVisivelImpressaoColumn {
                get {
                    return this.columnbVisivelImpressao;
                }
            }
            
            internal DataColumn nGrupoColumn {
                get {
                    return this.columnnGrupo;
                }
            }
            
            internal DataColumn nIdImagemIndexColumn {
                get {
                    return this.columnnIdImagemIndex;
                }
            }
            
            public tbRelatorioImagensRow this[int index] {
                get {
                    return ((tbRelatorioImagensRow)(this.Rows[index]));
                }
            }
            
            public event tbRelatorioImagensRowChangeEventHandler tbRelatorioImagensRowChanged;
            
            public event tbRelatorioImagensRowChangeEventHandler tbRelatorioImagensRowChanging;
            
            public event tbRelatorioImagensRowChangeEventHandler tbRelatorioImagensRowDeleted;
            
            public event tbRelatorioImagensRowChangeEventHandler tbRelatorioImagensRowDeleting;
            
            public void AddtbRelatorioImagensRow(tbRelatorioImagensRow row) {
                this.Rows.Add(row);
            }
            
            public tbRelatorioImagensRow AddtbRelatorioImagensRow(int nIdExportador, int nIdTipo, int nIdRelatorio, int nIdimagem, int nX1, int nY1, int nX2, int nY2, bool bVisivelImpressao, short nGrupo, short nIdImagemIndex) {
                tbRelatorioImagensRow rowtbRelatorioImagensRow = ((tbRelatorioImagensRow)(this.NewRow()));
                rowtbRelatorioImagensRow.ItemArray = new object[] {
                        nIdExportador,
                        nIdTipo,
                        nIdRelatorio,
                        nIdimagem,
                        nX1,
                        nY1,
                        nX2,
                        nY2,
                        bVisivelImpressao,
                        nGrupo,
                        nIdImagemIndex};
                this.Rows.Add(rowtbRelatorioImagensRow);
                return rowtbRelatorioImagensRow;
            }
            
            public tbRelatorioImagensRow FindBynIdExportadornIdTiponIdRelatorionIdimagem(int nIdExportador, int nIdTipo, int nIdRelatorio, int nIdimagem) {
                return ((tbRelatorioImagensRow)(this.Rows.Find(new object[] {
                            nIdExportador,
                            nIdTipo,
                            nIdRelatorio,
                            nIdimagem})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                tbRelatorioImagensDataTable cln = ((tbRelatorioImagensDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new tbRelatorioImagensDataTable();
            }
            
            internal void InitVars() {
                this.columnnIdExportador = this.Columns["nIdExportador"];
                this.columnnIdTipo = this.Columns["nIdTipo"];
                this.columnnIdRelatorio = this.Columns["nIdRelatorio"];
                this.columnnIdimagem = this.Columns["nIdimagem"];
                this.columnnX1 = this.Columns["nX1"];
                this.columnnY1 = this.Columns["nY1"];
                this.columnnX2 = this.Columns["nX2"];
                this.columnnY2 = this.Columns["nY2"];
                this.columnbVisivelImpressao = this.Columns["bVisivelImpressao"];
                this.columnnGrupo = this.Columns["nGrupo"];
                this.columnnIdImagemIndex = this.Columns["nIdImagemIndex"];
            }
            
            private void InitClass() {
                this.columnnIdExportador = new DataColumn("nIdExportador", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdExportador);
                this.columnnIdTipo = new DataColumn("nIdTipo", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdTipo);
                this.columnnIdRelatorio = new DataColumn("nIdRelatorio", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdRelatorio);
                this.columnnIdimagem = new DataColumn("nIdimagem", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdimagem);
                this.columnnX1 = new DataColumn("nX1", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnX1);
                this.columnnY1 = new DataColumn("nY1", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnY1);
                this.columnnX2 = new DataColumn("nX2", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnX2);
                this.columnnY2 = new DataColumn("nY2", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnY2);
                this.columnbVisivelImpressao = new DataColumn("bVisivelImpressao", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnbVisivelImpressao);
                this.columnnGrupo = new DataColumn("nGrupo", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnGrupo);
                this.columnnIdImagemIndex = new DataColumn("nIdImagemIndex", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnIdImagemIndex);
                this.Constraints.Add(new UniqueConstraint("XsdTbRelatorioImagensKey1", new DataColumn[] {
                                this.columnnIdExportador,
                                this.columnnIdTipo,
                                this.columnnIdRelatorio,
                                this.columnnIdimagem}, true));
                this.columnnIdExportador.AllowDBNull = false;
                this.columnnIdTipo.AllowDBNull = false;
                this.columnnIdRelatorio.AllowDBNull = false;
                this.columnnIdimagem.AllowDBNull = false;
            }
            
            public tbRelatorioImagensRow NewtbRelatorioImagensRow() {
                return ((tbRelatorioImagensRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new tbRelatorioImagensRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(tbRelatorioImagensRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.tbRelatorioImagensRowChanged != null)) {
                    this.tbRelatorioImagensRowChanged(this, new tbRelatorioImagensRowChangeEvent(((tbRelatorioImagensRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.tbRelatorioImagensRowChanging != null)) {
                    this.tbRelatorioImagensRowChanging(this, new tbRelatorioImagensRowChangeEvent(((tbRelatorioImagensRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.tbRelatorioImagensRowDeleted != null)) {
                    this.tbRelatorioImagensRowDeleted(this, new tbRelatorioImagensRowChangeEvent(((tbRelatorioImagensRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.tbRelatorioImagensRowDeleting != null)) {
                    this.tbRelatorioImagensRowDeleting(this, new tbRelatorioImagensRowChangeEvent(((tbRelatorioImagensRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovetbRelatorioImagensRow(tbRelatorioImagensRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbRelatorioImagensRow : DataRow {
            
            private tbRelatorioImagensDataTable tabletbRelatorioImagens;
            
            internal tbRelatorioImagensRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tabletbRelatorioImagens = ((tbRelatorioImagensDataTable)(this.Table));
            }
            
            public int nIdExportador {
                get {
                    return ((int)(this[this.tabletbRelatorioImagens.nIdExportadorColumn]));
                }
                set {
                    this[this.tabletbRelatorioImagens.nIdExportadorColumn] = value;
                }
            }
            
            public int nIdTipo {
                get {
                    return ((int)(this[this.tabletbRelatorioImagens.nIdTipoColumn]));
                }
                set {
                    this[this.tabletbRelatorioImagens.nIdTipoColumn] = value;
                }
            }
            
            public int nIdRelatorio {
                get {
                    return ((int)(this[this.tabletbRelatorioImagens.nIdRelatorioColumn]));
                }
                set {
                    this[this.tabletbRelatorioImagens.nIdRelatorioColumn] = value;
                }
            }
            
            public int nIdimagem {
                get {
                    return ((int)(this[this.tabletbRelatorioImagens.nIdimagemColumn]));
                }
                set {
                    this[this.tabletbRelatorioImagens.nIdimagemColumn] = value;
                }
            }
            
            public int nX1 {
                get {
                    try {
                        return ((int)(this[this.tabletbRelatorioImagens.nX1Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nX1Column] = value;
                }
            }
            
            public int nY1 {
                get {
                    try {
                        return ((int)(this[this.tabletbRelatorioImagens.nY1Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nY1Column] = value;
                }
            }
            
            public int nX2 {
                get {
                    try {
                        return ((int)(this[this.tabletbRelatorioImagens.nX2Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nX2Column] = value;
                }
            }
            
            public int nY2 {
                get {
                    try {
                        return ((int)(this[this.tabletbRelatorioImagens.nY2Column]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nY2Column] = value;
                }
            }
            
            public bool bVisivelImpressao {
                get {
                    try {
                        return ((bool)(this[this.tabletbRelatorioImagens.bVisivelImpressaoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.bVisivelImpressaoColumn] = value;
                }
            }
            
            public short nGrupo {
                get {
                    try {
                        return ((short)(this[this.tabletbRelatorioImagens.nGrupoColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nGrupoColumn] = value;
                }
            }
            
            public short nIdImagemIndex {
                get {
                    try {
                        return ((short)(this[this.tabletbRelatorioImagens.nIdImagemIndexColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tabletbRelatorioImagens.nIdImagemIndexColumn] = value;
                }
            }
            
            public bool IsnX1Null() {
                return this.IsNull(this.tabletbRelatorioImagens.nX1Column);
            }
            
            public void SetnX1Null() {
                this[this.tabletbRelatorioImagens.nX1Column] = System.Convert.DBNull;
            }
            
            public bool IsnY1Null() {
                return this.IsNull(this.tabletbRelatorioImagens.nY1Column);
            }
            
            public void SetnY1Null() {
                this[this.tabletbRelatorioImagens.nY1Column] = System.Convert.DBNull;
            }
            
            public bool IsnX2Null() {
                return this.IsNull(this.tabletbRelatorioImagens.nX2Column);
            }
            
            public void SetnX2Null() {
                this[this.tabletbRelatorioImagens.nX2Column] = System.Convert.DBNull;
            }
            
            public bool IsnY2Null() {
                return this.IsNull(this.tabletbRelatorioImagens.nY2Column);
            }
            
            public void SetnY2Null() {
                this[this.tabletbRelatorioImagens.nY2Column] = System.Convert.DBNull;
            }
            
            public bool IsbVisivelImpressaoNull() {
                return this.IsNull(this.tabletbRelatorioImagens.bVisivelImpressaoColumn);
            }
            
            public void SetbVisivelImpressaoNull() {
                this[this.tabletbRelatorioImagens.bVisivelImpressaoColumn] = System.Convert.DBNull;
            }
            
            public bool IsnGrupoNull() {
                return this.IsNull(this.tabletbRelatorioImagens.nGrupoColumn);
            }
            
            public void SetnGrupoNull() {
                this[this.tabletbRelatorioImagens.nGrupoColumn] = System.Convert.DBNull;
            }
            
            public bool IsnIdImagemIndexNull() {
                return this.IsNull(this.tabletbRelatorioImagens.nIdImagemIndexColumn);
            }
            
            public void SetnIdImagemIndexNull() {
                this[this.tabletbRelatorioImagens.nIdImagemIndexColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tbRelatorioImagensRowChangeEvent : EventArgs {
            
            private tbRelatorioImagensRow eventRow;
            
            private DataRowAction eventAction;
            
            public tbRelatorioImagensRowChangeEvent(tbRelatorioImagensRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public tbRelatorioImagensRow Row {
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
